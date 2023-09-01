namespace Zaabee.LZMA;

public static partial class LzmaHelper
{
    public static byte[] Compress(
        byte[] rawBytes)
    {
        var outputStream = new MemoryStream();
        Compress(new MemoryStream(rawBytes), outputStream);
        return outputStream.ToArray();
    }

    public static byte[] Decompress(
        byte[] compressedBytes)
    {
        var outputStream = new MemoryStream();
        Decompress(new MemoryStream(compressedBytes), outputStream);
        return outputStream.ToArray();
    }
}