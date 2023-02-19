using Grpc.Core;

namespace GrpcServer.Services
{
    public class CustomerService : Customer.CustomerBase

    {
        private readonly ILogger<CustomerService> _loggger;

        public CustomerService(ILogger<CustomerService> logger)
        {
            _loggger = logger;
        }
        public override Task<CustomerModel> GetCustomerInfo(CustomerLookUpModel request, ServerCallContext context)
        {
            CustomerModel output = new();
            output.FirstName = "Murad";
            output.LastName = "Azimzada";
            output.EmailAddress = "muradazimzada321@gmail.com";
            output.Age = 20;
            output.IsAlive = true;
            if (request.UserId == 1)
            {
                output.FirstName = "Murad";
                output.LastName = "Azimzada";
                output.EmailAddress = "muradazimzada321@gmail.com";
                output.Age = 20;
                output.IsAlive = true;
            }
            else
            {

                output.FirstName = "Murad";
                output.LastName = "Azimzada2";
                output.EmailAddress = "muradazimzada321@gmail.com";
                output.Age = 20;
                output.IsAlive = true;
            }

            return Task.FromResult(output);
        }

        public override async Task GetNewCustomers(
            NewCustomerRequest request,
            IServerStreamWriter<CustomerModel> responseStream,
            ServerCallContext context)
        {
            List<CustomerModel> customers = new List<CustomerModel>
            {
                new CustomerModel
                {
                    FirstName = "Murad",
                    LastName = "Azimzada",
                    EmailAddress = "muradazimzada321@gmail.com",
                    Age = 20,
                    IsAlive = true
                }, new CustomerModel
                {
                    FirstName = "Murad",
                    LastName = "Alizade",
                    EmailAddress = "muradalizade@gmail.com",
                    Age = 20,
                    IsAlive = true
                }, new CustomerModel
                {
                    FirstName = "Murad",
                    LastName = "Hesenzade",
                    EmailAddress = "muradhesenzade321@gmail.com",
                    Age = 20,
                    IsAlive = true
                }, new CustomerModel
                {
                    FirstName = "Murad",
                    LastName = "Aghayev",
                    EmailAddress = "muradaghayev321@gmail.com",
                    Age = 20,
                    IsAlive = true
                }, new CustomerModel
                {
                    FirstName = "Murad",
                    LastName = "Dadashov",
                    EmailAddress = "muraddadashov@gmail.com",
                    Age = 20,
                    IsAlive = true
                }, new CustomerModel
                {
                    FirstName = "Murad",
                    LastName = "Talibli",
                    EmailAddress = "muradtalib@gmail.com",
                    Age = 20,
                    IsAlive = false
                },
            };

            foreach (var customer in customers)
            {
                //await Task.Delay(500);
                await responseStream.WriteAsync(customer);
            }
        }
    }
}
