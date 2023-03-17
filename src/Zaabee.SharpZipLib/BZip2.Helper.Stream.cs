namespace Zaabee.SharpZipLib;

public static partial class Bzip2Helper
{
    public static MemoryStream Compress(
        Stream inputStream)
    {
        var outputStream = new MemoryStream();
        Compress(inputStream, outputStream);
        return outputStream;
    }

    public static MemoryStream Decompress(
        Stream inputStream)
    {
        var outputStream = new MemoryStream();
        Decompress(inputStream, outputStream);
        return outputStream;
    }

    public static void Compress(
        Stream inputStream,
        Stream outputStream)
    {
        using (var bzip2OutputStream = new BZip2OutputStream(outputStream))
        {
            inputStream.CopyTo(bzip2OutputStream);
            bzip2OutputStream.IsStreamOwner = false;
        }
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static void Decompress(
        Stream inputStream,
        Stream outputStream)
    {
        using (var bzip2InputStream = new BZip2InputStream(inputStream))
        {
            bzip2InputStream.CopyTo(outputStream);
            bzip2InputStream.IsStreamOwner = false;
        }
        inputStream.TrySeek(0, SeekOrigin.Begin);
        outputStream.TrySeek(0, SeekOrigin.Begin);
    }
}