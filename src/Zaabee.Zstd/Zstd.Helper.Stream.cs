namespace Zaabee.Zstd;

public static partial class ZstdHelper
{
    public static MemoryStream Compress(Stream inputStream, int level = Level)
    {
        var outputStream = new MemoryStream();
        Compress(inputStream, outputStream, level);
        return outputStream;
    }

    public static MemoryStream Decompress(Stream inputStream)
    {
        var outputStream = new MemoryStream();
        Decompress(inputStream, outputStream);
        return outputStream;
    }

    public static void Compress(Stream inputStream, Stream outputStream, int level = Level)
    {
        var inputBytes = inputStream.ReadToEnd();
        var outputBytes = Compress(inputBytes, level);
#if NETSTANDARD2_0
        outputStream.Write(outputBytes, 0, outputBytes.Length);
#else
        outputStream.Write(outputBytes);
#endif
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static void Decompress(Stream inputStream, Stream outputStream)
    {
        var inputBytes = inputStream.ReadToEnd();
        var outputBytes = Decompress(inputBytes);
#if NETSTANDARD2_0
        outputStream.Write(outputBytes, 0, outputBytes.Length);
#else
        outputStream.Write(outputBytes);
#endif
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }
}
