namespace Aoxe.SharpZipLib;

public static partial class GzipHelper
{
    public static byte[] Compress(byte[] rawBytes)
    {
        var outputStream = new MemoryStream();
        using (var gzipOutputStream = new GZipOutputStream(outputStream))
            rawBytes.WriteTo(gzipOutputStream);
        return outputStream.ToArray();
    }

    public static byte[] Decompress(byte[] compressedBytes)
    {
        var outputStream = new MemoryStream();
        using (var gzipInputStream = new GZipInputStream(new MemoryStream(compressedBytes)))
            gzipInputStream.CopyTo(outputStream);
        return outputStream.ToArray();
    }
}
