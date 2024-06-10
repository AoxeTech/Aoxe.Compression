namespace Aoxe.SystemIoCompression;

public static partial class DeflateExtensions
{
    public static byte[] ToDeflate(
        this byte[] rawBytes,
        CompressionLevel compressionLevel = CompressionLevel.Optimal
    ) => DeflateHelper.Compress(rawBytes, compressionLevel);

    public static byte[] UnDeflate(this byte[] compressedBytes) =>
        DeflateHelper.Decompress(compressedBytes);
}
