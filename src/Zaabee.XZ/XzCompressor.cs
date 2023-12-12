namespace Zaabee.XZ;

public sealed class XzCompressor(
    int threads = XzHelper.Threads,
    uint preset = XzHelper.Preset)
    : ICompressor
{
    public ValueTask<MemoryStream> CompressAsync(
        Stream rawStream,
        CancellationToken cancellationToken = default
    ) => rawStream.ToXzAsync(threads, preset, cancellationToken);

    public ValueTask<MemoryStream> DecompressAsync(
        Stream compressedStream,
        CancellationToken cancellationToken = default
    ) => compressedStream.UnXzAsync(cancellationToken);

    public ValueTask CompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => inputStream.ToXzAsync(outputStream, threads, preset, cancellationToken);

    public ValueTask DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => inputStream.UnXzAsync(outputStream, cancellationToken);

    public byte[] Compress(byte[] rawBytes) => rawBytes.ToXz();

    public byte[] Decompress(byte[] compressedBytes) => compressedBytes.UnXz();

    public MemoryStream Compress(Stream rawStream) => rawStream.ToXz(threads, preset);

    public MemoryStream Decompress(Stream compressedStream) => compressedStream.UnXz();

    public void Compress(Stream inputStream, Stream outputStream) =>
        inputStream.ToXz(outputStream, threads, preset);

    public void Decompress(Stream inputStream, Stream outputStream) =>
        inputStream.UnXz(outputStream);
}
