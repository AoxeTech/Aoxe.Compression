namespace Aoxe.XZ;

public static partial class XzHelper
{
    public static MemoryStream Compress(
        Stream inputStream,
        int threads = Threads,
        uint preset = Preset
    )
    {
        var outputStream = new MemoryStream();
        Compress(inputStream, outputStream, threads, preset);
        return outputStream;
    }

    public static MemoryStream Decompress(Stream inputStream)
    {
        var outputStream = new MemoryStream();
        Decompress(inputStream, outputStream);
        return outputStream;
    }

    public static void Compress(
        Stream inputStream,
        Stream outputStream,
        int threads = Threads,
        uint preset = Preset
    )
    {
        using (var xzOutputStream = new XZOutputStream(outputStream, threads, preset, true))
            inputStream.CopyTo(xzOutputStream);
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static void Decompress(Stream inputStream, Stream outputStream)
    {
        using (var xzInputStream = new XZInputStream(inputStream, true))
            xzInputStream.CopyTo(outputStream);
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }
}
