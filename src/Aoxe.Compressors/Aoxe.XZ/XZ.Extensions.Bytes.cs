namespace Aoxe.XZ;

public static partial class XzExtensions
{
    public static byte[] ToXz(this byte[] rawBytes) => XzHelper.Compress(rawBytes);

    public static byte[] UnXz(this byte[] compressedBytes) => XzHelper.Decompress(compressedBytes);
}
