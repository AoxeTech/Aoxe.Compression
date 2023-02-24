namespace Zaabee.SharpZipLib;

public static partial class GzipExtensions
{
    public static void ToGZip(this Stream rawStream, Stream outputStream) =>
        GzipHelper.Compress(rawStream, outputStream);

    public static void UnGZip(this Stream compressedStream, Stream outputStream) =>
        GzipHelper.Decompress(compressedStream, outputStream);

    public static MemoryStream ToGZip(this Stream rawStream)
    {
        var outputStream = new MemoryStream();
        rawStream.ToGZip(outputStream);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }

    public static MemoryStream UnGZip(this Stream compressedStream)
    {
        var outputStream = new MemoryStream();
        compressedStream.UnGZip(outputStream);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }
}