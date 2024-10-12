namespace Aoxe.LZ4;

public sealed class Lz4Compressor(
    LZ4Level level = Lz4Helper.Level,
    int extraMemory = Lz4Helper.ExtraMemory,
    bool interactive = Lz4Helper.Interactive,
    LZ4DecoderSettings? settings = Lz4Helper.Settings
) : ICompressor
{
    public ValueTask<MemoryStream> CompressAsync(
        Stream rawStream,
        CancellationToken cancellationToken = default
    ) => rawStream.ToLz4Async(level, extraMemory, cancellationToken);

    public ValueTask<MemoryStream> DecompressAsync(
        Stream compressedStream,
        CancellationToken cancellationToken = default
    ) => compressedStream.UnLz4Async(settings, interactive, cancellationToken);

    public ValueTask CompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => inputStream.ToLz4Async(outputStream, level, extraMemory, cancellationToken);

    public ValueTask DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => inputStream.UnLz4Async(outputStream, settings, interactive, cancellationToken);

    public byte[] Compress(byte[] rawBytes) => rawBytes.ToLz4(level, extraMemory);

    public byte[] Decompress(byte[] compressedBytes) =>
        compressedBytes.UnLz4(settings, interactive);

    public MemoryStream Compress(Stream rawStream) => rawStream.ToLz4(level, extraMemory);

    public MemoryStream Decompress(Stream compressedStream) =>
        compressedStream.UnLz4(settings, interactive);

    public void Compress(Stream inputStream, Stream outputStream) =>
        inputStream.ToLz4(outputStream, level, extraMemory);

    public void Decompress(Stream inputStream, Stream outputStream) =>
        inputStream.UnLz4(outputStream, settings, interactive);
}
