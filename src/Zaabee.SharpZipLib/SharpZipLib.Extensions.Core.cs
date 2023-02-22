namespace Zaabee.SharpZipLib;

public static partial class SharpZipLibExtensions
{
    internal static void CompressToStream(Stream outputStream, byte[] rawData)
    {
#if NETSTANDARD2_0
        outputStream.Write(rawData, 0, rawData.Length);
#else
        outputStream.Write(rawData);
#endif
    }

    internal static void DecompressFromStream(Stream inputStream, Stream resultStream)
    {
        var decompressBytes = inputStream.ReadToEnd();
#if NETSTANDARD2_0
        resultStream.Write(decompressBytes, 0, decompressBytes.Length);
#else
        resultStream.Write(decompressBytes);
#endif
    }

    internal static async Task CompressToStreamAsync(Stream outputStream, byte[] rawData)
    {
#if NETSTANDARD2_0
        await outputStream.WriteAsync(rawData, 0, rawData.Length);
#else
        await outputStream.WriteAsync(rawData);
#endif
    }

    internal static async Task DecompressFromStreamAsync(Stream inputStream, Stream resultStream)
    {
        var decompressBytes = await inputStream.ReadToEndAsync();
#if NETSTANDARD2_0
        await resultStream.WriteAsync(decompressBytes, 0, decompressBytes.Length);
#else
        await resultStream.WriteAsync(decompressBytes);
#endif
    }
}