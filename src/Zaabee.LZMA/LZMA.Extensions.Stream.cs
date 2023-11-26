namespace Zaabee.LZMA;

public static partial class LzmaExtensions
{
    public static void ToLzma(this Stream rawStream, Stream outputStream) =>
        LzmaHelper.Compress(rawStream, outputStream);

    public static void UnLzma(this Stream compressedStream, Stream outputStream) =>
        LzmaHelper.Decompress(compressedStream, outputStream);

    public static MemoryStream ToLzma(this Stream rawStream) => LzmaHelper.Compress(rawStream);

    public static MemoryStream UnLzma(this Stream compressedStream) =>
        LzmaHelper.Decompress(compressedStream);
}
