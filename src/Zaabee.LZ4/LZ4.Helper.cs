namespace Zaabee.LZ4;

public class Lz4Helper
{
    public static byte[] ToLz4(byte[] bytes, LZ4Level level = LZ4Level.L00_FAST)
    {
        var target = new byte[LZ4Codec.MaximumOutputSize(bytes.Length) + 4].AsSpan();
        var size = BitConverter.GetBytes(bytes.Length).AsSpan();
        size.CopyTo(target);
        var compressedBytesSize = LZ4Codec.Encode(bytes, target.Slice(4), level);
        return target.Slice(0, compressedBytesSize + 4).ToArray();
    }

    public static byte[] UnLz4(byte[] bytes)
    {
        var source = bytes.AsSpan();
        var size = source.Slice(0, 4).ToArray();
        var length = BitConverter.ToInt32(size, 0);
        var target = new byte[length].AsSpan();
        var decoded = LZ4Codec.Decode(source.Slice(4), target);
        return target.Slice(0, decoded).ToArray();
    }
}