namespace Zaabee.SharpZipLib;

public static partial class GzipExtensions
{
    public static async Task ToGZipAsync(
        this Stream rawStream,
        Stream outputStream,
        bool isStreamOwner = GzipHelper.IsStreamOwner) =>
        await GzipHelper.CompressAsync(rawStream, outputStream, isStreamOwner);

    public static async Task UnGZipAsync(
        this Stream compressedStream,
        Stream outputStream,
        bool isStreamOwner = GzipHelper.IsStreamOwner) =>
        await GzipHelper.DecompressAsync(compressedStream, outputStream, isStreamOwner);

    public static async Task<MemoryStream> ToGZipAsync(this Stream rawStream)
    {
        var outputStream = new MemoryStream();
        await rawStream.ToGZipAsync(outputStream, false);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }

    public static async Task<MemoryStream> UnGZipAsync(this Stream compressedStream)
    {
        var outputStream = new MemoryStream();
        await compressedStream.UnGZipAsync(outputStream, false);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }
}