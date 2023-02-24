namespace Zaabee.Brotli;

public static partial class BrotliExtensions
{
    public static void ToBrotli(this Stream rawStream, Stream outputStream) =>
        BrotliHelper.Compress(rawStream, outputStream);

    public static void UnBrotli(this Stream compressedStream, Stream outputStream) =>
        BrotliHelper.Decompress(compressedStream, outputStream);

    public static MemoryStream ToBrotli(this Stream rawStream)
    {
        var outputStream = new MemoryStream();
        rawStream.ToBrotli(outputStream);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }

    public static MemoryStream UnBrotli(this Stream compressedStream)
    {
        var outputStream = new MemoryStream();
        compressedStream.UnBrotli(outputStream);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }
}