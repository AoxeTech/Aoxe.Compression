namespace Zaabee.XZ;

public static partial class XzHelper
{
    public static byte[] Compress(byte[] rawBytes)
    {
        var outputStream = new MemoryStream();
        Compress(new MemoryStream(rawBytes), outputStream);
        return outputStream.ToArray();
    }

    public static byte[] Decompress(byte[] compressedBytes)
    {
        var outputStream = new MemoryStream();
        Decompress(new MemoryStream(compressedBytes), outputStream);
        return outputStream.ToArray();
    }
}
