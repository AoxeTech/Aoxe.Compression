namespace Aoxe.SystemIoCompression;

public static partial class GzipExtensions
{
    public static void ToGZip(
        this Stream rawStream,
        Stream outputStream,
        CompressionLevel compressionLevel = CompressionLevel.Optimal
    ) => GzipHelper.Compress(rawStream, outputStream, compressionLevel);

    public static void UnGZip(this Stream compressedStream, Stream outputStream) =>
        GzipHelper.Decompress(compressedStream, outputStream);

    public static MemoryStream ToGZip(
        this Stream rawStream,
        CompressionLevel compressionLevel = CompressionLevel.Optimal
    ) => GzipHelper.Compress(rawStream, compressionLevel);

    public static MemoryStream UnGZip(this Stream compressedStream) =>
        GzipHelper.Decompress(compressedStream);
}
