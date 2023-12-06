#if !NETSTANDARD2_0
namespace Zaabee.SystemIoCompression;

public static partial class BrotliHelper
{
    public static byte[] Compress(byte[] rawBytes)
    {
        var outputStream = new MemoryStream();
        using (var brotliOutputStream = new BrotliStream(outputStream, CompressionMode.Compress, true))
            rawBytes.WriteTo(brotliOutputStream);
        return outputStream.ToArray();
    }

    public static byte[] Decompress(byte[] compressedBytes)
    {
        var outputStream = new MemoryStream();
        using (var brotliInputStream = new BrotliStream(compressedBytes.ToMemoryStream(), CompressionMode.Decompress, true))
            brotliInputStream.CopyTo(outputStream);
        return outputStream.ToArray();
    }
}
#endif