#if !NETSTANDARD2_0
namespace Zaabee.SystemIoCompression;

public static partial class BrotliHelper
{
    public static MemoryStream Compress(Stream inputStream)
    {
        var outputStream = new MemoryStream();
        Compress(inputStream, outputStream);
        return outputStream;
    }

    public static MemoryStream Decompress(Stream inputStream)
    {
        var outputStream = new MemoryStream();
        Decompress(inputStream, outputStream);
        return outputStream;
    }

    public static void Compress(Stream inputStream, Stream outputStream)
    {
        using (var brotliOutputStream = new BrotliStream(outputStream, CompressionMode.Compress, true))
        {
            inputStream.CopyTo(brotliOutputStream);
        }
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static void Decompress(Stream inputStream, Stream outputStream)
    {
        using (var brotliInputStream = new BrotliStream(inputStream, CompressionMode.Decompress, true))
        {
            brotliInputStream.CopyTo(outputStream);
        }
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }
}
#endif