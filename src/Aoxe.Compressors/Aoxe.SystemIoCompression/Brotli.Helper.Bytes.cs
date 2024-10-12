#if !NETSTANDARD2_0
namespace Aoxe.SystemIoCompression;

public static partial class BrotliHelper
{
    public static byte[] Compress(
        byte[] rawBytes,
        CompressionLevel compressionLevel = CompressionLevel.Optimal
    )
    {
        var outputStream = new MemoryStream();
        using (var brotliOutputStream = new BrotliStream(outputStream, compressionLevel, true))
            rawBytes.WriteTo(brotliOutputStream);
        return outputStream.ToArray();
    }

    public static byte[] Decompress(byte[] compressedBytes)
    {
        var outputStream = new MemoryStream();
        using (
            var brotliInputStream = new BrotliStream(
                compressedBytes.ToMemoryStream(),
                CompressionMode.Decompress,
                true
            )
        )
            brotliInputStream.CopyTo(outputStream);
        return outputStream.ToArray();
    }
}
#endif
