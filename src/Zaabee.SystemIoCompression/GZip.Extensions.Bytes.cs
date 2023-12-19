namespace Zaabee.SystemIoCompression;

public static partial class GzipExtensions
{
    public static byte[] ToGZip(
        this byte[] rawBytes,
        CompressionLevel compressionLevel = CompressionLevel.Optimal
    ) => GzipHelper.Compress(rawBytes, compressionLevel);

    public static byte[] UnGZip(this byte[] compressedBytes) =>
        GzipHelper.Decompress(compressedBytes);
}
