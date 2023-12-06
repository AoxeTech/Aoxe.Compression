namespace Zaabee.SystemIoCompression;

public static partial class DeflateHelper
{
    public static byte[] Compress(byte[] rawBytes)
    {
        var outputStream = new MemoryStream();
        using (var deflateOutputStream = new DeflateStream(outputStream, CompressionMode.Compress, true))
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
