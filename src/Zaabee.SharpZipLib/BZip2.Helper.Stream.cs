namespace Zaabee.SharpZipLib;

public static partial class Bzip2Helper
{
    public static void Compress(
        Stream inputStream,
        Stream outputStream,
        bool isStreamOwner = IsStreamOwner)
    {
        using var bzip2OutputStream = new BZip2OutputStream(outputStream);
        inputStream.CopyTo(bzip2OutputStream);
        bzip2OutputStream.IsStreamOwner = isStreamOwner;
        inputStream.TrySeek(0, SeekOrigin.Begin);
    }

    public static void Decompress(
        Stream inputStream,
        Stream outputStream,
        bool isStreamOwner = IsStreamOwner)
    {
        using var bzip2InputStream = new BZip2InputStream(inputStream);
        bzip2InputStream.CopyTo(outputStream);
        bzip2InputStream.IsStreamOwner = isStreamOwner;
        inputStream.TrySeek(0, SeekOrigin.Begin);
    }
}