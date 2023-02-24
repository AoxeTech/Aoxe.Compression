namespace Zaabee.Brotli;

public static partial class BrotliExtensions
{
    public static async Task ToBrotliAsync(this Stream rawStream, Stream outputStream) =>
        await BrotliHelper.CompressAsync(rawStream, outputStream);

    public static async Task UnBrotliAsync(this Stream compressedStream, Stream outputStream) =>
        await BrotliHelper.DecompressAsync(compressedStream, outputStream);

    public static async Task<MemoryStream> ToBrotliAsync(this Stream rawStream)
    {
        var outputStream = new MemoryStream();
        await rawStream.ToBrotliAsync(outputStream);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }

    public static async Task<MemoryStream> UnBrotliAsync(this Stream compressedStream)
    {
        var outputStream = new MemoryStream();
        await compressedStream.UnBrotliAsync(outputStream);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }
}