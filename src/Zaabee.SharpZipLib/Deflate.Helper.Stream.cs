namespace Zaabee.SharpZipLib;

public static partial class DeflateHelper
{
    public static MemoryStream Compress(Stream inputStream)
    {
        var outputStream = new MemoryStream();
        Compress(inputStream, outputStream);
        return outputStream;
    }

    public static MemoryStream Decompress(Stream inputStream)
    {
        var outputStream = new MemoryStream();
        Decompress(inputStream, outputStream);
        return outputStream;
    }

    public static void Compress(Stream inputStream, Stream outputStream)
    {
        using (var deflateOutputStream = new DeflaterOutputStream(outputStream))
        {
            inputStream.CopyTo(deflateOutputStream);
            deflateOutputStream.IsStreamOwner = false;
        }
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static void Decompress(Stream inputStream, Stream outputStream)
    {
        using (var deflateInputStream = new InflaterInputStream(inputStream))
        {
            deflateInputStream.CopyTo(outputStream);
            deflateInputStream.IsStreamOwner = false;
        }
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }
}
