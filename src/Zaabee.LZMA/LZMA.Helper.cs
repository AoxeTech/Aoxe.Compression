namespace Zaabee.LZMA;

public static partial class LzmaHelper
{
    private static readonly Encoder Encoder = new();
    private static readonly Decoder Decoder = new();
}