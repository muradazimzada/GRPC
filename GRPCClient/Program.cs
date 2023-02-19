using Grpc.Core;
using Grpc.Net.Client;
using GrpcServer;

namespace GRPCClient
{
    internal class Program
    {
        async static Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7123");
            var customerClient = new Customer.CustomerClient(channel);

            var clientRequest = new CustomerLookUpModel { UserId = 1 };
            var clientResponse = await customerClient.GetCustomerInfoAsync(clientRequest);

            Console.WriteLine(clientResponse);
            Console.WriteLine("Async Call -> ");

            using (var call = customerClient.GetNewCustomers(new NewCustomerRequest()))
            {
                while (await call.ResponseStream.MoveNext())
                {
                    var currentCustomer = call.ResponseStream.Current;

                    Console.WriteLine($"Firstame: {currentCustomer.FirstName} \n Lastname: {currentCustomer.LastName} \n Email: {currentCustomer.EmailAddress} \n Age: {currentCustomer.Age}");
                }
            }

            Console.ReadLine();

        }
    }
}