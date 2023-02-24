namespace Zaabee.SharpZipLib;

public static partial class GzipHelper
{
    public static void Compress(
        Stream inputStream,
        Stream outputStream,
        bool isStreamOwner = false)
    {
        using var gzipOutputStream = new GZipOutputStream(outputStream);
        inputStream.CopyTo(gzipOutputStream);
        gzipOutputStream.IsStreamOwner = isStreamOwner;
    }

    public static void Decompress(
        Stream inputStream,
        Stream outputStream,
        bool isStreamOwner = false)
    {
        using var gzipInputStream = new GZipInputStream(inputStream);
        gzipInputStream.CopyTo(outputStream);
        gzipInputStream.IsStreamOwner = isStreamOwner;
    }
}