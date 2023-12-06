namespace Zaabee.SystemIoCompression;

public sealed class GzipCompressor : ICompressor
{
    public ValueTask<MemoryStream> CompressAsync(
        Stream rawStream,
        CancellationToken cancellationToken = default
    ) => rawStream.ToGZipAsync(cancellationToken);

    public ValueTask<MemoryStream> DecompressAsync(
        Stream compressedStream,
        CancellationToken cancellationToken = default
    ) => compressedStream.UnGZipAsync(cancellationToken);

    public ValueTask CompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => inputStream.ToGZipAsync(outputStream, cancellationToken);

    public ValueTask DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => inputStream.UnGZipAsync(outputStream, cancellationToken);

    public byte[] Compress(byte[] rawBytes) => rawBytes.ToGZip();

    public byte[] Decompress(byte[] compressedBytes) => compressedBytes.UnGZip();

    public MemoryStream Compress(Stream rawStream) => rawStream.ToGZip();

    public MemoryStream Decompress(Stream compressedStream) => compressedStream.UnGZip();

    public void Compress(Stream inputStream, Stream outputStream) =>
        inputStream.ToGZip(outputStream);

    public void Decompress(Stream inputStream, Stream outputStream) =>
        inputStream.UnGZip(outputStream);
}
