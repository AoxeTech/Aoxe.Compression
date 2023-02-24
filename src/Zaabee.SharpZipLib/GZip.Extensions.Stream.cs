namespace Zaabee.SharpZipLib;

public static partial class GzipExtensions
{
    public static void ToGZip(
        this Stream rawStream,
        Stream outputStream,
        bool isStreamOwner = GzipHelper.IsStreamOwner) =>
        GzipHelper.Compress(rawStream, outputStream, isStreamOwner);

    public static void UnGZip(
        this Stream compressedStream,
        Stream outputStream,
        bool isStreamOwner = GzipHelper.IsStreamOwner) =>
        GzipHelper.Decompress(compressedStream, outputStream, isStreamOwner);

    public static MemoryStream ToGZip(
        this Stream rawStream)
    {
        var outputStream = new MemoryStream();
        rawStream.ToGZip(outputStream, false);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }

    public static MemoryStream UnGZip(this Stream compressedStream)
    {
        var outputStream = new MemoryStream();
        compressedStream.UnGZip(outputStream, false);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }
}