namespace Zaabee.LZ4;

public static partial class Lz4Extensions
{
    public static byte[] ToLz4(this byte[] rawBytes) =>
        Lz4Helper.Compress(rawBytes);

    public static byte[] UnLz4(this byte[] compressedBytes) =>
        Lz4Helper.Decompress(compressedBytes);
}