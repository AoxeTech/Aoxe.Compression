namespace Zaabee.LZMA;

public static partial class LzmaExtensions
{
    public static async Task ToLzmaAsync(
        this Stream rawStream,
        Stream outputStream) =>
        await LzmaHelper.CompressAsync(rawStream, outputStream);

    public static async Task UnLzmaAsync(
        this Stream compressedStream,
        Stream outputStream) =>
        await LzmaHelper.DecompressAsync(compressedStream, outputStream);

    public static async Task<MemoryStream> ToLzmaAsync(
        this Stream rawStream) =>
        await LzmaHelper.CompressAsync(rawStream);

    public static async Task<MemoryStream> UnLzmaAsync(
        this Stream compressedStream) =>
        await LzmaHelper.DecompressAsync(compressedStream);
}