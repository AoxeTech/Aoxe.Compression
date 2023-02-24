namespace Zaabee.SharpZipLib;

public static partial class Bzip2Extensions
{
    public static void ToBZip2(
        this Stream rawStream,
        Stream outputStream,
        bool isStreamOwner = GzipHelper.IsStreamOwner) =>
        Bzip2Helper.Compress(rawStream, outputStream, isStreamOwner);

    public static void UnBZip2(
        this Stream compressedStream,
        Stream outputStream,
        bool isStreamOwner = GzipHelper.IsStreamOwner) =>
        Bzip2Helper.Decompress(compressedStream, outputStream, isStreamOwner);

    public static MemoryStream ToBZip2(this Stream rawStream)
    {
        var outputStream = new MemoryStream();
        rawStream.ToBZip2(outputStream, false);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }

    public static MemoryStream UnBZip2(this Stream compressedStream)
    {
        var outputStream = new MemoryStream();
        compressedStream.UnBZip2(outputStream, false);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }
}