namespace Zaabee.SystemIoCompression;

public static partial class DeflateExtensions
{
    public static void ToDeflate(
        this Stream rawStream,
        Stream outputStream,
        CompressionLevel compressionLevel = CompressionLevel.Optimal
    ) => DeflateHelper.Compress(rawStream, outputStream, compressionLevel);

    public static void UnDeflate(this Stream compressedStream, Stream outputStream) =>
        DeflateHelper.Decompress(compressedStream, outputStream);

    public static MemoryStream ToDeflate(
        this Stream rawStream,
        CompressionLevel compressionLevel = CompressionLevel.Optimal
    ) => DeflateHelper.Compress(rawStream, compressionLevel);

    public static MemoryStream UnDeflate(this Stream compressedStream) =>
        DeflateHelper.Decompress(compressedStream);
}
