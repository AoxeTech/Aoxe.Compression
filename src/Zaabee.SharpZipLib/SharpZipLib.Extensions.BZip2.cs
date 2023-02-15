namespace Zaabee.SharpZipLib;

public static partial class SharpZipLibExtensions
{
    public static byte[] CompressBZip2(this byte[] rawData)
    {
        return CompressBZip2ToStream(rawData).ToArray();
    }

    public static byte[] UnBZip2(byte[] bytes)
    {
        return UnBZip2FromStream(new MemoryStream(bytes)).ToArray();
    }

    public static MemoryStream CompressBZip2ToStream(this byte[] rawData)
    {
        var ms = new MemoryStream();
        var outputStream = new BZip2OutputStream(ms);
        CompressToStream(outputStream, rawData);
        outputStream.Close();
        return ms;
    }

    public static MemoryStream UnBZip2FromStream(this Stream rawStream)
    {
        var inputStream = new BZip2InputStream(rawStream);
        var ms = DecompressFromStream(inputStream);
        inputStream.Close();
        return ms;
    }

    public static async Task<MemoryStream> CompressBZip2ToStreamAsync(this byte[] rawData)
    {
        var ms = new MemoryStream();
        var outputStream = new BZip2OutputStream(ms);
        await CompressToStreamAsync(outputStream, rawData);
        outputStream.Close();
        return ms;
    }

    public static async Task<MemoryStream> UnBZip2FromStreamAsync(this Stream rawStream)
    {
        var inputStream = new BZip2InputStream(rawStream);
        var ms = await DecompressFromStreamAsync(inputStream);
        inputStream.Close();
        return ms;
    }
}