namespace Zaabee.SharpZipLib;

public static partial class SharpZipLibExtensions
{
    public static byte[] CompressGZip(this byte[] rawData)
    {
        return CompressGZipToStream(rawData).ToArray();
    }

    public static byte[] UnGZip(this byte[] bytes)
    {
        return UnGZipFromStream(new MemoryStream(bytes)).ToArray();
    }

    public static MemoryStream CompressGZipToStream(this byte[] rawData)
    {
        var ms = new MemoryStream();
        var outputStream = new GZipOutputStream(ms);
        CompressToStream(outputStream, rawData);
        outputStream.Close();
        return ms;
    }

    public static MemoryStream UnGZipFromStream(this Stream rawStream)
    {
        var inputStream = new GZipInputStream(rawStream);
        var ms = DecompressFromStream(inputStream);
        inputStream.Close();
        return ms;
    }

    public static async Task<MemoryStream> CompressGZipToStreamAsync(this byte[] rawData)
    {
        var ms = new MemoryStream();
        var outputStream = new GZipOutputStream(ms);
        await CompressToStreamAsync(outputStream, rawData);
        outputStream.Close();
        return ms;
    }

    public static async Task<MemoryStream> UnGZipFromStreamAsync(this Stream rawStream)
    {
        var inputStream = new GZipInputStream(rawStream);
        var ms = await DecompressFromStreamAsync(inputStream);
        inputStream.Close();
        return ms;
    }
}