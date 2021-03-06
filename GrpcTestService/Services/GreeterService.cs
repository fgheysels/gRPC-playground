using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.Collections;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace GrpcTestService
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }

        public override Task<MessageResponse> GetMessage(MessageRequest request, ServerCallContext context)
        {
            var response = new MessageResponse();

            for (int i = 0; i < request.Count; i++)
            {
                response.Answer.Add(request.Msg);
            }

            return Task.FromResult(response);
        }

        //override 
    }
}
