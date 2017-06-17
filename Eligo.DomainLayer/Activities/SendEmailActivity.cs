using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.DomainLayer.Activities
{
    public sealed class SendEmailActivity : CodeActivity<DateTime>
    {
        [RequiredArgument]
        public InArgument<string> SenderConfigurationName { get; set; }

        //specifies the In/Out arguments for this activity
        [RequiredArgument]
        public InArgument<string> Subject { get; set; }

        [RequiredArgument]
        public InArgument<string> Body { get; set; }

        [RequiredArgument]
        public InArgument<string> To { get; set; }

        protected override DateTime Execute(CodeActivityContext context)
        {
            return DateTime.Now;
        }
    }
}
