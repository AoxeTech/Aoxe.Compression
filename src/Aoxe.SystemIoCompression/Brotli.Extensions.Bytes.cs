#if !NETSTANDARD2_0
namespace Aoxe.SystemIoCompression;

public static partial class BrotliExtensions
{
    public static byte[] ToBrotli(
        this byte[] rawBytes,
        CompressionLevel compressionLevel = CompressionLevel.Optimal
    ) => BrotliHelper.Compress(rawBytes, compressionLevel);

    public static byte[] UnBrotli(this byte[] compressedBytes) =>
        BrotliHelper.Decompress(compressedBytes);
}
#endif
