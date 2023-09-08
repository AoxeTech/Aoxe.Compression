namespace Zaabee.LZ4;

public sealed class Lz4Compressor : ICompressor
{
    private readonly LZ4Level _level;
    private readonly int _extraMemory;
    private readonly bool _interactive;
    private readonly LZ4DecoderSettings? _settings;

    public Lz4Compressor(
        LZ4Level level = Lz4Helper.Level,
        int extraMemory = Lz4Helper.ExtraMemory,
        bool interactive = Lz4Helper.Interactive,
        LZ4DecoderSettings? settings = Lz4Helper.Settings)
    {
        _interactive = interactive;
        _settings = settings;
        _extraMemory = extraMemory;
        _level = level;
    }

    public ValueTask<MemoryStream> CompressAsync(
        Stream rawStream,
        CancellationToken cancellationToken = default) =>
        rawStream.ToLz4Async(_level, _extraMemory, cancellationToken);

    public ValueTask<MemoryStream> DecompressAsync(
        Stream compressedStream,
        CancellationToken cancellationToken = default) =>
        compressedStream.UnLz4Async(_settings, _interactive, cancellationToken);

    public ValueTask CompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default) =>
        inputStream.ToLz4Async(outputStream, _level, _extraMemory, cancellationToken);

    public ValueTask DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default) =>
        inputStream.UnLz4Async(outputStream, _settings, _interactive, cancellationToken);

    public byte[] Compress(byte[] rawBytes) =>
        rawBytes.ToLz4(_level, _extraMemory);

    public byte[] Decompress(byte[] compressedBytes) =>
        compressedBytes.UnLz4(_settings, _interactive);

    public MemoryStream Compress(Stream rawStream) =>
        rawStream.ToLz4(_level, _extraMemory);

    public MemoryStream Decompress(Stream compressedStream) =>
        compressedStream.UnLz4(_settings, _interactive);

    public void Compress(
        Stream inputStream,
        Stream outputStream) =>
        inputStream.ToLz4(outputStream, _level, _extraMemory);

    public void Decompress(
        Stream inputStream,
        Stream outputStream) =>
        inputStream.UnLz4(outputStream, _settings, _interactive);
}