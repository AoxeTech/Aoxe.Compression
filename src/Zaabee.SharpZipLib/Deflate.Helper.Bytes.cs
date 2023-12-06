namespace Zaabee.SharpZipLib;

public static partial class DeflateHelper
{
    public static byte[] Compress(byte[] rawBytes)
    {
        var outputStream = new MemoryStream();
        using (var deflateOutputStream = new DeflaterOutputStream(outputStream))
            rawBytes.WriteTo(deflateOutputStream);
        return outputStream.ToArray();
    }

    public static byte[] Decompress(byte[] compressedBytes)
    {
        var outputStream = new MemoryStream();
        using (var deflateInputStream = new InflaterInputStream(new MemoryStream(compressedBytes)))
            deflateInputStream.CopyTo(outputStream);
        return outputStream.ToArray();
    }
}
