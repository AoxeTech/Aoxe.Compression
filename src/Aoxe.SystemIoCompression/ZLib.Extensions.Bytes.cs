#if NET6_0_OR_GREATER
namespace Aoxe.SystemIoCompression;

public static partial class ZLibExtensions
{
    public static byte[] ToZLib(
        this byte[] rawBytes,
        CompressionLevel compressionLevel = CompressionLevel.Optimal
    ) => ZLibHelper.Compress(rawBytes, compressionLevel);

    public static byte[] UnZLib(this byte[] compressedBytes) =>
        ZLibHelper.Decompress(compressedBytes);
}
#endif
