namespace Zaabee.SharpZipLib;

public class Bzip2Compressor : ICompressor
{
    private readonly bool _isStreamOwner;

    public Bzip2Compressor(bool isStreamOwner = Bzip2Helper.IsStreamOwner)
    {
        _isStreamOwner = isStreamOwner;
    }

    public async Task<MemoryStream> CompressAsync(Stream rawStream) =>
        await rawStream.ToBZip2Async();

    public async Task<MemoryStream> DecompressAsync(Stream compressedStream) =>
        await compressedStream.UnBZip2Async();

    public async Task CompressAsync(
        Stream inputStream,
        Stream outputStream,
        bool leaveOpen = CompressorConsts.LeaveOpen) =>
        await inputStream.ToBZip2Async(outputStream, !leaveOpen);

    public async Task DecompressAsync(
        Stream inputStream,
        Stream outputStream,
        bool leaveOpen = CompressorConsts.LeaveOpen) =>
        await inputStream.UnBZip2Async(outputStream, !leaveOpen);

    public byte[] Compress(byte[] rawBytes) =>
        rawBytes.ToBZip2();

    public byte[] Decompress(byte[] compressedBytes) =>
        compressedBytes.UnBZip2();

    public MemoryStream Compress(Stream rawStream) =>
        rawStream.ToBZip2();

    public MemoryStream Decompress(Stream compressedStream) =>
        compressedStream.UnBZip2();

    public void Compress(
        Stream inputStream,
        Stream outputStream,
        bool leaveOpen = CompressorConsts.LeaveOpen) =>
        inputStream.ToBZip2(outputStream, !leaveOpen);

    public void Decompress(
        Stream inputStream,
        Stream outputStream,
        bool leaveOpen = CompressorConsts.LeaveOpen) =>
        inputStream.UnBZip2(outputStream, !leaveOpen);
}