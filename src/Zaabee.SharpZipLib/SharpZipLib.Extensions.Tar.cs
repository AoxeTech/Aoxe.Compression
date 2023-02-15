namespace Zaabee.SharpZipLib;

public static partial class SharpZipLibExtensions
{
    private static readonly Encoding DefaultEncoding = Encoding.UTF8;

    public static byte[] CompressTar(this byte[] rawData)
    {
        return CompressTarToStream(rawData).ToArray();
    }

    public static byte[] UnTar(byte[] bytes)
    {
        return UnTarFromStream(new MemoryStream(bytes)).ToArray();
    }

    public static MemoryStream CompressTarToStream(this byte[] rawData, Encoding? encoding = null)
    {
        var ms = new MemoryStream();
        var outputStream = new TarOutputStream(ms, encoding ?? DefaultEncoding);
        CompressToStream(outputStream, rawData);
        outputStream.Close();
        return ms;
    }

    public static MemoryStream UnTarFromStream(this Stream rawStream, Encoding? encoding = null)
    {
        var inputStream = new TarInputStream(rawStream, encoding ?? DefaultEncoding);
        var ms = DecompressFromStream(inputStream);
        inputStream.Close();
        return ms;
    }

    public static async Task<MemoryStream> CompressTarToStreamAsync(this byte[] rawData, Encoding? encoding = null)
    {
        var ms = new MemoryStream();
        var outputStream = new TarOutputStream(ms, encoding ?? DefaultEncoding);
        await CompressToStreamAsync(outputStream, rawData);
        outputStream.Close();
        return ms;
    }

    public static async Task<MemoryStream> UnTarFromStreamAsync(this Stream rawStream, Encoding? encoding = null)
    {
        var inputStream = new TarInputStream(rawStream, encoding ?? DefaultEncoding);
        var ms = await DecompressFromStreamAsync(inputStream);
        inputStream.Close();
        return ms;
    }
}