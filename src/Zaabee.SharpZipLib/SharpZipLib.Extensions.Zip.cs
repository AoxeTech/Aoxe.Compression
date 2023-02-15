namespace Zaabee.SharpZipLib;

public static partial class SharpZipLibExtensions
{
    public static byte[] CompressZip(this byte[] rawData)
    {
        return CompressZipToStream(rawData).ToArray();
    }

    public static byte[] UnZip(byte[] bytes)
    {
        return UnZipFromStream(new MemoryStream(bytes)).ToArray();
    }

    public static MemoryStream CompressZipToStream(this byte[] rawData)
    {
        var ms = new MemoryStream();
        var outputStream = new ZipOutputStream(ms);
        CompressToStream(outputStream, rawData);
        outputStream.Close();
        return ms;
    }

    public static MemoryStream UnZipFromStream(this Stream rawStream)
    {
        var inputStream = new ZipInputStream(rawStream);
        var ms = DecompressFromStream(inputStream);
        inputStream.Close();
        return ms;
    }

    public static async Task<MemoryStream> CompressZipToStreamAsync(this byte[] rawData)
    {
        var ms = new MemoryStream();
        var outputStream = new ZipOutputStream(ms);
        await CompressToStreamAsync(outputStream, rawData);
        outputStream.Close();
        return ms;
    }

    public static async Task<MemoryStream> UnZipFromStreamAsync(this Stream rawStream)
    {
        var inputStream = new ZipInputStream(rawStream);
        var ms = await DecompressFromStreamAsync(inputStream);
        inputStream.Close();
        return ms;
    }
}