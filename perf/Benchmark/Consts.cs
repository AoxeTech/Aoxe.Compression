namespace Benchmark;

public static class Consts
{
    public static readonly byte[] RawBytes = new byte[1024 * 10];
    public static readonly MemoryStream RawStream = new(RawBytes);
}
