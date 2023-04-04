namespace Zaabee.XZ;

public class XzCompressor : ICompressor
{
    private readonly int _threads;
    private readonly uint _preset;

    public XzCompressor(
        int threads = XzHelper.Threads,
        uint preset = XzHelper.Preset)
    {
        _threads = threads;
        _preset = preset;
    }

    public async Task<MemoryStream> CompressAsync(
        Stream rawStream,
        CancellationToken cancellationToken = default) =>
        await rawStream.ToXzAsync(_threads, _preset, cancellationToken);

    public async Task<MemoryStream> DecompressAsync(
        Stream compressedStream,
        CancellationToken cancellationToken = default) =>
        await compressedStream.UnXzAsync(cancellationToken);

    public async Task CompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default) =>
        await inputStream.ToXzAsync(outputStream, _threads, _preset, cancellationToken);

    public async Task DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default) =>
        await inputStream.UnXzAsync(outputStream, cancellationToken);

    public byte[] Compress(byte[] rawBytes) =>
        rawBytes.ToXz();

    public byte[] Decompress(byte[] compressedBytes) =>
        compressedBytes.UnXz();

    public MemoryStream Compress(Stream rawStream) =>
        rawStream.ToXz(_threads, _preset);

    public MemoryStream Decompress(Stream compressedStream) =>
        compressedStream.UnXz();

    public void Compress(
        Stream inputStream,
        Stream outputStream) =>
        inputStream.ToXz(outputStream, _threads, _preset);

    public void Decompress(
        Stream inputStream,
        Stream outputStream) =>
        inputStream.UnXz(outputStream);
}