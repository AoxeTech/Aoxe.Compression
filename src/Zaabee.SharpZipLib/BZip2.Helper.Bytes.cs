namespace Zaabee.SharpZipLib;

public static partial class Bzip2Helper
{
    public static byte[] Compress(byte[] rawBytes)
    {
        var outputStream = new MemoryStream();
        using (var bzip2OutputStream = new BZip2OutputStream(outputStream))
            rawBytes.WriteTo(bzip2OutputStream);
        return outputStream.ToArray();
    }

    public static byte[] Decompress(byte[] compressedBytes)
    {
        var outputStream = new MemoryStream();
        using (var bzip2InputStream = new BZip2InputStream(new MemoryStream(compressedBytes)))
            bzip2InputStream.CopyTo(outputStream);
        return outputStream.ToArray();
    }
}