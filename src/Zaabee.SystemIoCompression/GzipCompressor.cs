namespace Zaabee.SystemIoCompression;

public sealed class GzipCompressor(CompressionLevel compressionLevel = CompressionLevel.Optimal) : ICompressor
{
    public ValueTask<MemoryStream> CompressAsync(
        Stream rawStream,
        CancellationToken cancellationToken = default
    ) => rawStream.ToGZipAsync(compressionLevel, cancellationToken);

    public ValueTask<MemoryStream> DecompressAsync(
        Stream compressedStream,
        CancellationToken cancellationToken = default
    ) => compressedStream.UnGZipAsync(cancellationToken);

    public ValueTask CompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => inputStream.ToGZipAsync(outputStream, compressionLevel, cancellationToken);

    public ValueTask DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        CancellationToken cancellationToken = default
    ) => inputStream.UnGZipAsync(outputStream, cancellationToken);

    public byte[] Compress(byte[] rawBytes) => rawBytes.ToGZip(compressionLevel);

    public byte[] Decompress(byte[] compressedBytes) => compressedBytes.UnGZip();

    public MemoryStream Compress(Stream rawStream) => rawStream.ToGZip(compressionLevel);

    public MemoryStream Decompress(Stream compressedStream) => compressedStream.UnGZip();

    public void Compress(Stream inputStream, Stream outputStream) =>
        inputStream.ToGZip(outputStream, compressionLevel);

    public void Decompress(Stream inputStream, Stream outputStream) =>
        inputStream.UnGZip(outputStream);
}