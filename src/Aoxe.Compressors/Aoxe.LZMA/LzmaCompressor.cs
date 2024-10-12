namespace Aoxe.LZMA;

public sealed class LzmaCompressor : ICompressor
{
    public ValueTask<MemoryStream> CompressAsync(
        Stream rawStream,
        CancellationToken cancellationToken = default
    ) => rawStream.ToLzmaAsync(cancellationToken: cancellationToken);

    public ValueTask<MemoryStream> DecompressAsync(
        Stream compressedStream,
        CancellationToken cancellationToken = default
    ) => compressedStream.UnLzmaAsync(cancellationToken: cancellationToken);

    public ValueTask CompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => inputStream.ToLzmaAsync(outputStream, cancellationToken: cancellationToken);

    public ValueTask DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => inputStream.UnLzmaAsync(outputStream, cancellationToken: cancellationToken);

    public byte[] Compress(byte[] rawBytes) => rawBytes.ToLzma();

    public byte[] Decompress(byte[] compressedBytes) => compressedBytes.UnLzma();

    public MemoryStream Compress(Stream rawStream) => rawStream.ToLzma();

    public MemoryStream Decompress(Stream compressedStream) => compressedStream.UnLzma();

    public void Compress(Stream inputStream, Stream outputStream) =>
        inputStream.ToLzma(outputStream);

    public void Decompress(Stream inputStream, Stream outputStream) =>
        inputStream.UnLzma(outputStream);
}
