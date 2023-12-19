namespace Zaabee.SharpZipLib;

public static partial class DeflateExtensions
{
    public static void ToDeflate(this Stream rawStream, Stream outputStream) =>
        DeflateHelper.Compress(rawStream, outputStream);

    public static void UnDeflate(this Stream compressedStream, Stream outputStream) =>
        DeflateHelper.Decompress(compressedStream, outputStream);

    public static MemoryStream ToDeflate(this Stream rawStream) =>
        DeflateHelper.Compress(rawStream);

    public static MemoryStream UnDeflate(this Stream compressedStream) =>
        DeflateHelper.Decompress(compressedStream);
}
