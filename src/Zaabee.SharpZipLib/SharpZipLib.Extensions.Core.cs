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
        var data = new byte[128];
#if NETSTANDARD2_0
        int count;
        while ((count = inputStream.Read(data, 0, data.Length)) != 0)
            resultStream.Write(data, 0, count);
#else
        while (inputStream.Read(data) != 0)
            resultStream.Write(data);
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
        var data = new byte[128];
        int count;
#if NETSTANDARD2_0
        while ((count = await inputStream.ReadAsync(data, 0, data.Length)) != 0)
            await resultStream.WriteAsync(data, 0, count);
#else
        while ((count = await inputStream.ReadAsync(data)) != 0)
            await resultStream.WriteAsync(data.AsMemory(0, count));
#endif
    }
}