#if NET6_0_OR_GREATER
namespace Aoxe.SystemIoCompression;

public static partial class ZLibHelper
{
    public static byte[] Compress(
        byte[] rawBytes,
        CompressionLevel compressionLevel = CompressionLevel.Optimal
    )
    {
        var outputStream = new MemoryStream();
        using (var zLibOutputStream = new ZLibStream(outputStream, compressionLevel, true))
            rawBytes.WriteTo(zLibOutputStream);
        return outputStream.ToArray();
    }

    public static byte[] Decompress(byte[] compressedBytes)
    {
        var outputStream = new MemoryStream();
        using (
            var zLibInputStream = new ZLibStream(
                compressedBytes.ToMemoryStream(),
                CompressionMode.Decompress,
                true
            )
        )
            zLibInputStream.CopyTo(outputStream);
        return outputStream.ToArray();
    }
}
#endif
