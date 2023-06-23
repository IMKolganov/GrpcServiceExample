using System.Numerics;

namespace GrpcServiceExample.Services.Untils;

public class BigIntegerWrapper
{
    public BigIntegerWrapper()
    {
    }

    public BigIntegerWrapper(BigInteger value)
    {
        Value = value;
    }

    public BigInteger Value { get; set; } = BigInteger.Zero;
}