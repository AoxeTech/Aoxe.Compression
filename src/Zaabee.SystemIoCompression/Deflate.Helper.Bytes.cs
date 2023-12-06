namespace Zaabee.SystemIoCompression;

public static partial class DeflateHelper
{
    public static byte[] Compress(byte[] rawBytes, CompressionLevel compressionLevel = CompressionLevel.Optimal)
    {
        var outputStream = new MemoryStream();
        using (var deflateOutputStream = new DeflateStream(outputStream, compressionLevel, true))
            rawBytes.WriteTo(deflateOutputStream);
        return outputStream.ToArray();
    }

    public static byte[] Decompress(byte[] compressedBytes)
    {
        var outputStream = new MemoryStream();
        using (var deflateInputStream = new DeflateStream(compressedBytes.ToMemoryStream(), CompressionMode.Decompress, true))
            deflateInputStream.CopyTo(outputStream);
        return outputStream.ToArray();
    }
}