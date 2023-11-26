namespace Zaabee.Snappy;

public static partial class SnappyExtensions
{
    public static void ToSnappy(this Stream rawStream, Stream outputStream) =>
        SnappyHelper.Compress(rawStream, outputStream);

    public static void UnSnappy(this Stream compressedStream, Stream outputStream) =>
        SnappyHelper.Decompress(compressedStream, outputStream);

    public static MemoryStream ToSnappy(this Stream rawStream) => SnappyHelper.Compress(rawStream);

    public static MemoryStream UnSnappy(this Stream compressedStream) =>
        SnappyHelper.Decompress(compressedStream);
}
