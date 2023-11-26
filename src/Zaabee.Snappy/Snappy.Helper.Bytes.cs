namespace Zaabee.Snappy;

public static partial class SnappyHelper
{
    public static byte[] Compress(byte[] rawBytes) => IronSnappy.Snappy.Encode(rawBytes);

    public static byte[] Decompress(byte[] compressedBytes) =>
        IronSnappy.Snappy.Decode(compressedBytes);
}
