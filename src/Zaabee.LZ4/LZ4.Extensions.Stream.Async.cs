namespace Zaabee.LZ4;

public static partial class Lz4Extensions
{
    public static async Task ToLz4Async(this Stream rawStream, Stream outputStream) =>
        await Lz4Helper.CompressAsync(rawStream, outputStream);

    public static async Task UnLz4Async(this Stream compressedStream, Stream outputStream) =>
        await Lz4Helper.DecompressAsync(compressedStream, outputStream);

    public static async Task<MemoryStream> ToLz4Async(this Stream rawStream)
    {
        var outputStream = new MemoryStream();
        await rawStream.ToLz4Async(outputStream);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }

    public static async Task<MemoryStream> UnLz4Async(this Stream compressedStream)
    {
        var outputStream = new MemoryStream();
        await compressedStream.UnLz4Async(outputStream);
        outputStream.TrySeek(0, SeekOrigin.Begin);
        return outputStream;
    }
}