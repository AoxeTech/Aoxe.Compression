namespace Zaabee.SharpZipLib;

public static partial class GzipExtensions
{
    public static async Task ToGZipAsync(this Stream rawStream, Stream outputStream) =>
        await GzipHelper.CompressAsync(rawStream, outputStream);

    public static async Task UnGZipAsync(this Stream compressedStream, Stream outputStream) =>
        await GzipHelper.DecompressAsync(compressedStream, outputStream);

    public static async Task<MemoryStream> ToGZipAsync(this Stream rawStream)
    {
        var outputStream = new MemoryStream();
        await rawStream.ToGZipAsync(outputStream);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }

    public static async Task<MemoryStream> UnGZipAsync(this Stream compressedStream)
    {
        var outputStream = new MemoryStream();
        await compressedStream.UnGZipAsync(outputStream);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }
}