namespace Zaabee.SharpZipLib;

public static partial class Bzip2Extensions
{
    public static void ToBZip2(this Stream rawStream, Stream outputStream) =>
        Bzip2Helper.Compress(rawStream, outputStream);

    public static void UnBZip2(this Stream compressedStream, Stream outputStream) =>
        Bzip2Helper.Decompress(compressedStream, outputStream);

    public static MemoryStream ToBZip2(this Stream rawStream) => Bzip2Helper.Compress(rawStream);

    public static MemoryStream UnBZip2(this Stream compressedStream) =>
        Bzip2Helper.Decompress(compressedStream);
}
