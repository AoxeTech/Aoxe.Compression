namespace Zaabee.Snappy;

public static partial class SnappyExtensions
{
    public static byte[] ToSnappy(this byte[] rawBytes) => SnappyHelper.Compress(rawBytes);

    public static byte[] UnSnappy(this byte[] compressedBytes) =>
        SnappyHelper.Decompress(compressedBytes);
}
