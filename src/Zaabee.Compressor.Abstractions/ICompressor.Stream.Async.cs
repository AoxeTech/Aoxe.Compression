namespace Zaabee.Compressor.Abstractions;

public partial interface ICompressor
{
    Task CompressAsync(Stream inputStream, Stream outputStream);
    Task DecompressAsync(Stream inputStream, Stream outputStream);
}