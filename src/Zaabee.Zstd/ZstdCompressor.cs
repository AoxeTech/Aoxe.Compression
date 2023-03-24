namespace Zaabee.Zstd;

public sealed class ZstdCompressor : ICompressor
{
    private readonly int _level;

    public ZstdCompressor(int level = ZstdHelper.Level)
    {
        _level = level;
    }

    public async Task<MemoryStream> CompressAsync(
        Stream rawStream,
        CancellationToken cancellationToken = default) =>
        await rawStream.ToZstdAsync(_level, cancellationToken);

    public async Task<MemoryStream> DecompressAsync(
        Stream compressedStream,
        CancellationToken cancellationToken = default) =>
        await compressedStream.UnZstdAsync(cancellationToken);

    public async Task CompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default) =>
        await inputStream.ToZstdAsync(outputStream, _level, cancellationToken);

    public async Task DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default) =>
        await inputStream.UnZstdAsync(outputStream, cancellationToken);

    public byte[] Compress(byte[] rawBytes) =>
        rawBytes.ToZstd(_level);

    public byte[] Decompress(byte[] compressedBytes) =>
        compressedBytes.UnZstd();

    public MemoryStream Compress(Stream rawStream) =>
        rawStream.ToZstd(_level);

    public MemoryStream Decompress(Stream compressedStream) =>
        compressedStream.UnZstd();

    public void Compress(
        Stream inputStream,
        Stream outputStream) =>
        inputStream.ToZstd(outputStream, _level);

    public void Decompress(
        Stream inputStream,
        Stream outputStream) =>
        inputStream.UnZstd(outputStream);
}