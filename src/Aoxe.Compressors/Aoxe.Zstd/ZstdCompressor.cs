namespace Aoxe.Zstd;

public sealed class ZstdCompressor(int level = ZstdHelper.Level) : ICompressor
{
    public ValueTask<MemoryStream> CompressAsync(
        Stream rawStream,
        CancellationToken cancellationToken = default
    ) => rawStream.ToZstdAsync(level, cancellationToken);

    public ValueTask<MemoryStream> DecompressAsync(
        Stream compressedStream,
        CancellationToken cancellationToken = default
    ) => compressedStream.UnZstdAsync(cancellationToken);

    public ValueTask CompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => inputStream.ToZstdAsync(outputStream, level, cancellationToken);

    public ValueTask DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => inputStream.UnZstdAsync(outputStream, cancellationToken);

    public byte[] Compress(byte[] rawBytes) => rawBytes.ToZstd(level);

    public byte[] Decompress(byte[] compressedBytes) => compressedBytes.UnZstd();

    public MemoryStream Compress(Stream rawStream) => rawStream.ToZstd(level);

    public MemoryStream Decompress(Stream compressedStream) => compressedStream.UnZstd();

    public void Compress(Stream inputStream, Stream outputStream) =>
        inputStream.ToZstd(outputStream, level);

    public void Decompress(Stream inputStream, Stream outputStream) =>
        inputStream.UnZstd(outputStream);
}
