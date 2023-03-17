namespace Zaabee.Brotli;

public sealed class BrotliCompressor : ICompressor
{
    private readonly uint _quality;
    private readonly uint _window;

    public BrotliCompressor(
        uint quality = BrotliHelper.Quality,
        uint window = BrotliHelper.Window)
    {
        _quality = quality;
        _window = window;
    }

    public async Task<MemoryStream> CompressAsync(Stream rawStream) =>
        await rawStream.ToBrotliAsync(_quality, _window);

    public async Task<MemoryStream> DecompressAsync(Stream compressedStream) =>
        await compressedStream.UnBrotliAsync();

    public async Task CompressAsync(
        Stream inputStream,
        Stream outputStream) =>
        await inputStream.ToBrotliAsync(outputStream, _quality, _window);

    public async Task DecompressAsync(
        Stream inputStream,
        Stream outputStream) =>
        await inputStream.UnBrotliAsync(outputStream);

    public byte[] Compress(byte[] rawBytes) =>
        rawBytes.ToBrotli(_quality, _window);

    public byte[] Decompress(byte[] compressedBytes) =>
        compressedBytes.UnBrotli();

    public MemoryStream Compress(Stream rawStream) =>
        rawStream.ToBrotli(_quality, _window);

    public MemoryStream Decompress(Stream compressedStream) =>
        compressedStream.UnBrotli();

    public void Compress(
        Stream inputStream,
        Stream outputStream) =>
        inputStream.ToBrotli(outputStream, _quality, _window);

    public void Decompress(
        Stream inputStream,
        Stream outputStream) =>
        inputStream.UnBrotli(outputStream);
}