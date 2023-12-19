namespace Zaabee.SystemIoCompression;

public static partial class GzipHelper
{
    public static byte[] Compress(
        byte[] rawBytes,
        CompressionLevel compressionLevel = CompressionLevel.Optimal
    )
    {
        var outputStream = new MemoryStream();
        using (var gzipOutputStream = new GZipStream(outputStream, compressionLevel, true))
            rawBytes.WriteTo(gzipOutputStream);
        return outputStream.ToArray();
    }

    public static byte[] Decompress(byte[] compressedBytes)
    {
        var outputStream = new MemoryStream();
        using (
            var gzipInputStream = new GZipStream(
                compressedBytes.ToMemoryStream(),
                CompressionMode.Decompress,
                true
            )
        )
            gzipInputStream.CopyTo(outputStream);
        return outputStream.ToArray();
    }
}
