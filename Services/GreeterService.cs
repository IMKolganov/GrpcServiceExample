using System.Numerics;
using Grpc.Core;
using GrpcServiceExample;
using GrpcServiceExample.Services.Untils;

namespace GrpcServiceExample.Services;

public class GreeterService : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;
    private static readonly BigIntegerWrapper UniqueIdWrapper = new();

    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        lock (UniqueIdWrapper)
        {
            UniqueIdWrapper.Value++;
            return Task.FromResult(new HelloReply
            {
                Message = $"Hello {request.Name} your unique bigint value {UniqueIdWrapper.Value}"
            });
        }
    }
}