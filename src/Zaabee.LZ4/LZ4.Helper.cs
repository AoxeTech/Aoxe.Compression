namespace Zaabee.LZ4;

public class Lz4Helper
{
    public static byte[] ToLz4(
        byte[] rawBytes,
        LZ4Level level = LZ4Level.L00_FAST,
        int extraMemory = 0)
    {
        var compressStream = new MemoryStream();
        ToLz4(new MemoryStream(rawBytes), compressStream, level, extraMemory, false);
        return compressStream.ToArray();
    }

    public static byte[] UnLz4(
        byte[] rawBytes,
        LZ4DecoderSettings? settings = null,
        bool interactive = false)
    {
        var decompressStream = new MemoryStream();
        UnLz4(new MemoryStream(rawBytes), decompressStream, settings, false, interactive);
        return decompressStream.ToArray();
    }

    public static void ToLz4(
        Stream rawStream,
        Stream compressStream,
        LZ4Level level = LZ4Level.L00_FAST,
        int extraMemory = 0,
        bool leaveOpen = true)
    {
        using var lz4Stream = LZ4Stream.Encode(compressStream, level, extraMemory, leaveOpen);
        rawStream.CopyTo(lz4Stream);

        rawStream.Flush();
        lz4Stream.Flush();
    }

    public static void UnLz4(
        Stream compressStream,
        Stream decompressStream,
        LZ4DecoderSettings? settings = null,
        bool leaveOpen = true,
        bool interactive = false)
    {
        using var lz4Stream = LZ4Stream.Decode(compressStream, settings, leaveOpen, interactive);
        lz4Stream.CopyTo(decompressStream);

        compressStream.Flush();
        lz4Stream.Flush();
    }

    public static async Task ToLz4Async(
        Stream rawStream,
        Stream compressStream,
        LZ4Level level = LZ4Level.L00_FAST,
        int extraMemory = 0,
        bool leaveOpen = true)
    {

#if NETSTANDARD2_0
        using var lz4Stream = LZ4Stream.Encode(compressStream, level, extraMemory, leaveOpen);
#else
        await using var lz4Stream = LZ4Stream.Encode(compressStream, level, extraMemory, leaveOpen);
#endif
        await rawStream.CopyToAsync(lz4Stream);

        await rawStream.FlushAsync();
        lz4Stream.Flush();
    }

    public static async Task UnLz4Async(
        Stream compressStream,
        Stream decompressStream,
        LZ4DecoderSettings? settings = null,
        bool leaveOpen = true,
        bool interactive = false)
    {
#if NETSTANDARD2_0
        using var lz4Stream = LZ4Stream.Decode(compressStream, settings, leaveOpen, interactive);
#else
        await using var lz4Stream = LZ4Stream.Decode(compressStream, settings, leaveOpen, interactive);
#endif
        await lz4Stream.CopyToAsync(decompressStream);

        await compressStream.FlushAsync();
        lz4Stream.Flush();
    }
}