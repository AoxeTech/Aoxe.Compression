namespace Zaabee.Compressor.Abstractions;

public partial interface ICompressor
{
    MemoryStream Compress(Stream rawStream);
    MemoryStream Decompress(Stream compressedStream);
    void Compress(Stream inputStream, Stream outputStream, bool leaveOpen = CompressorConsts.LeaveOpen);
    void Decompress(Stream inputStream, Stream outputStream, bool leaveOpen = CompressorConsts.LeaveOpen);
}