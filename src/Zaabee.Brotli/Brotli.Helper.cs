using BrotliStream = Brotli.BrotliStream;

namespace Zaabee.Brotli;

public class BrotliHelper
{
    public static byte[] ToBrotli(
        byte[] rawBytes,
        uint quality = 5,
        uint window = 22)=>
        rawBytes.CompressToBrotli(quality, window);

    public static byte[] UnBrotli(byte[] compressedBytes)=>
        compressedBytes.DecompressFromBrotli();

    public static void ToBrotli(
        Stream rawStream,
        Stream compressStream,
        uint quality = 5,
        uint window = 22,
        bool leaveOpen = true)
    {
        using var brotliStream = new BrotliStream(compressStream, CompressionMode.Compress, leaveOpen);
        brotliStream.SetQuality(quality);
        brotliStream.SetWindow(window);
        rawStream.CopyTo(brotliStream);
        rawStream.Flush();
        brotliStream.Flush();
    }

    public static void UnBrotli(
        Stream compressStream,
        Stream decompressStream,
        bool leaveOpen = true)
    {
        using var brotliStream = new BrotliStream(compressStream, CompressionMode.Decompress, leaveOpen);
        brotliStream.CopyTo(decompressStream);
        decompressStream.Flush();
        brotliStream.Flush();
    }

    public static async Task ToBrotliAsync(
        Stream rawStream,
        Stream compressStream,
        uint quality = 5,
        uint window = 22,
        bool leaveOpen = true)
    {
#if NETSTANDARD2_0
        using var brotliStream = new BrotliStream(compressStream, CompressionMode.Compress, leaveOpen);
#else
        await using var brotliStream = new BrotliStream(compressStream, CompressionMode.Compress, leaveOpen);
#endif
        brotliStream.SetQuality(quality);
        brotliStream.SetWindow(window);
        await rawStream.CopyToAsync(brotliStream);
        await rawStream.FlushAsync();
        brotliStream.Flush();
    }

    public static async Task UnBrotliAsync(
        Stream compressStream,
        Stream decompressStream,
        bool leaveOpen = true)
    {
#if NETSTANDARD2_0
        using var brotliStream = new BrotliStream(compressStream, CompressionMode.Decompress, leaveOpen);
#else
        await using var brotliStream = new BrotliStream(compressStream, CompressionMode.Decompress, leaveOpen);
#endif
        await brotliStream.CopyToAsync(decompressStream);
        await decompressStream.FlushAsync();
        brotliStream.Flush();
    }
}