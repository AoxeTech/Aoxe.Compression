namespace Zaabee.LZMA;

public static partial class LzmaExtensions
{
    public static byte[] ToLzma(
        this byte[] rawBytes) =>
        LzmaHelper.Compress(rawBytes);

    public static byte[] UnLzma(
        this byte[] compressedBytes) =>
        LzmaHelper.Decompress(compressedBytes);
}