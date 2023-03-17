namespace Zaabee.SharpZipLib;

public static partial class GzipExtensions
{
    public static void ToGZip(
        this Stream rawStream,
        Stream outputStream) =>
        GzipHelper.Compress(rawStream, outputStream);

    public static void UnGZip(
        this Stream compressedStream,
        Stream outputStream) =>
        GzipHelper.Decompress(compressedStream, outputStream);

    public static MemoryStream ToGZip(this Stream rawStream) =>
        GzipHelper.Compress(rawStream);

    public static MemoryStream UnGZip(this Stream compressedStream) =>
        GzipHelper.Decompress(compressedStream);
}