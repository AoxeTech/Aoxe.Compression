namespace Aoxe.SharpZipLib;

public static partial class GzipExtensions
{
    public static byte[] ToGZip(this byte[] rawBytes) => GzipHelper.Compress(rawBytes);

    public static byte[] UnGZip(this byte[] compressedBytes) =>
        GzipHelper.Decompress(compressedBytes);
}
