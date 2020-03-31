using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcTestService;

namespace GrpcTestClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var channel = GrpcChannel.ForAddress("https://localhost:5001"))
            {
                var client = new Greeter.GreeterClient(channel);
                var reply = await client.SayHelloAsync(
                    new HelloRequest { Name = "GreeterClient" });
                Console.WriteLine("Greeting: " + reply.Message);

                var answer = await client.GetMessageAsync(new MessageRequest() { Count = 17, Msg = "Hi Frederik" });

                Console.WriteLine("The answer of the GetMessage operation:");
                Console.WriteLine(answer.Answer);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
