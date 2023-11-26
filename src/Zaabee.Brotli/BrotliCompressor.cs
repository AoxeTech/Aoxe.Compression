namespace Zaabee.Brotli;

public sealed class BrotliCompressor : ICompressor
{
    private readonly uint _quality;
    private readonly uint _window;

    public BrotliCompressor(uint quality = BrotliHelper.Quality, uint window = BrotliHelper.Window)
    {
        _quality = quality;
        _window = window;
    }

    public ValueTask<MemoryStream> CompressAsync(
        Stream rawStream,
        CancellationToken cancellationToken = default
    ) => rawStream.ToBrotliAsync(_quality, _window, cancellationToken);

    public ValueTask<MemoryStream> DecompressAsync(
        Stream compressedStream,
        CancellationToken cancellationToken = default
    ) => compressedStream.UnBrotliAsync(cancellationToken);

    public ValueTask CompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => inputStream.ToBrotliAsync(outputStream, _quality, _window, cancellationToken);

    public ValueTask DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => inputStream.UnBrotliAsync(outputStream, cancellationToken);

    public byte[] Compress(byte[] rawBytes) => rawBytes.ToBrotli(_quality, _window);

    public byte[] Decompress(byte[] compressedBytes) => compressedBytes.UnBrotli();

    public MemoryStream Compress(Stream rawStream) => rawStream.ToBrotli(_quality, _window);

    public MemoryStream Decompress(Stream compressedStream) => compressedStream.UnBrotli();

    public void Compress(Stream inputStream, Stream outputStream) =>
        inputStream.ToBrotli(outputStream, _quality, _window);

    public void Decompress(Stream inputStream, Stream outputStream) =>
        inputStream.UnBrotli(outputStream);
}
