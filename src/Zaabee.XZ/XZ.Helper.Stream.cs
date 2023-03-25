namespace Zaabee.XZ;

public static partial class XzHelper
{
    public static MemoryStream Compress(
        Stream inputStream,
        int threads = Threads,
        uint preset = Preset,
        bool levelOpen = LevelOpen)
    {
        var outputStream = new MemoryStream();
        Compress(inputStream, outputStream,threads,preset,levelOpen);
        return outputStream;
    }

    public static MemoryStream Decompress(
        Stream inputStream,
        bool levelOpen = LevelOpen)
    {
        var outputStream = new MemoryStream();
        Decompress(inputStream, outputStream,levelOpen);
        return outputStream;
    }

    public static void Compress(
        Stream inputStream,
        Stream outputStream,
        int threads = Threads,
        uint preset = Preset,
        bool levelOpen = LevelOpen)
    {
        using (var xzOutputStream = new XZOutputStream(outputStream, threads, preset, levelOpen))
            inputStream.CopyTo(xzOutputStream);
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static void Decompress(
        Stream inputStream,
        Stream outputStream,
        bool levelOpen = LevelOpen)
    {
        using (var xzInputStream = new XZInputStream(inputStream, levelOpen))
            xzInputStream.CopyTo(outputStream);
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }
}