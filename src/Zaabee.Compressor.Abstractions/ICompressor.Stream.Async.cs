namespace Zaabee.Compressor.Abstractions;

public partial interface ICompressor
{
    Task<MemoryStream> CompressAsync(Stream rawStream, CancellationToken cancellationToken = default);
    Task CompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default);
    Task<MemoryStream> DecompressAsync(Stream compressedStream, CancellationToken cancellationToken = default);
    Task DecompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default);
}