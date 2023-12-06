namespace Zaabee.SystemIoCompression;

public sealed class DeflateCompressor : ICompressor
{
    public ValueTask<MemoryStream> CompressAsync(
        Stream rawStream,
        CancellationToken cancellationToken = default
    ) => rawStream.ToDeflateAsync(cancellationToken);

    public ValueTask<MemoryStream> DecompressAsync(
        Stream compressedStream,
        CancellationToken cancellationToken = default
    ) => compressedStream.UnDeflateAsync(cancellationToken);

    public ValueTask CompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => inputStream.ToDeflateAsync(outputStream, cancellationToken);

    public ValueTask DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => inputStream.UnDeflateAsync(outputStream, cancellationToken);

    public byte[] Compress(byte[] rawBytes) => rawBytes.ToDeflate();

    public byte[] Decompress(byte[] compressedBytes) => compressedBytes.UnDeflate();

    public MemoryStream Compress(Stream rawStream) => rawStream.ToDeflate();

    public MemoryStream Decompress(Stream compressedStream) => compressedStream.UnDeflate();

    public void Compress(Stream inputStream, Stream outputStream) =>
        inputStream.ToDeflate(outputStream);

    public void Decompress(Stream inputStream, Stream outputStream) =>
        inputStream.UnDeflate(outputStream);
}
