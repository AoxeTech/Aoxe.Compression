namespace Zaabee.Compressor.Abstractions;

public partial interface ICompressor
{
    MemoryStream Compress(Stream rawStream);
    void Compress(Stream inputStream, Stream outputStream);
    MemoryStream Decompress(Stream compressedStream);
    void Decompress(Stream inputStream, Stream outputStream);
}