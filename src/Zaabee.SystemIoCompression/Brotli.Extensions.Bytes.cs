#if !NETSTANDARD2_0
namespace Zaabee.SystemIoCompression;

public static partial class BrotliExtensions
{
    public static byte[] ToBrotli(this byte[] rawBytes) => BrotliHelper.Compress(rawBytes);

    public static byte[] UnBrotli(this byte[] compressedBytes) =>
        BrotliHelper.Decompress(compressedBytes);
}
#endif