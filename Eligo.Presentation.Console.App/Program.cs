using Eligo.DomainLayer.Customer.Activies.UserSummaryActivities;
using Eligo.DomainLayer.Customer.Models;
using System.Activities;

namespace Eligo.Presentation.Console.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var userActivity1 = new GetUserSummaryByIdActivity()
            {
                UserId = 1
            };

            var userSummary = WorkflowInvoker.Invoke(userActivity1);

            //var userSummary = new UserSummaryDto()
            //{
            //    ID = 1,
            //    FirstName = "Baris",
            //    LastName = "Kalaycioglu",
            //    EmailAddress = "baris@ydyazilim.com"
            //};

            //var userActivity2 = new SetUserByUserSummary()
            //{
            //    UserSummary = userSummary
            //};

            //WorkflowInvoker.Invoke(userActivity2);
        }
    }
}
