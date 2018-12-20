using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Diagnostics;
using System.Reflection;

namespace Imanami.Groups.Management.Commands.Get.Practice
{
    [CLSCompliant(false)]
    [Cmdlet(VerbsCommon.Get, "ErrorObject")]
    public class GetErrorObject : PSCmdlet
    {
        [Parameter]
        public SwitchParameter Terminating { get; set; }

        protected override void ProcessRecord()
        {
            if (Terminating)
            {
                ThrowTerminatingError(new ErrorRecord(new Exception("It's an exception that is thrown intentionally since to demonstrate ThrowTerminatingException"), "", ErrorCategory.OpenError, "The target object"));
            }
            else
            {
                WriteError(new ErrorRecord(new Exception("It's an exception that is thrown intentionally since to demonstrate ThrowTerminatingException"), "", ErrorCategory.OpenError, "The target object"));
            }

            Console.WriteLine("This is the statement after writing/throwing error.");
            Console.WriteLine("There are verbose and debug lines after this line which will not be displayed unless -verbose and -debug parameters are specified.");
            WriteVerbose("Verbose is hidden by default and is shown only when -verbose parameter is specified when invoking cmdlet.");
            WriteDebug("This is the debug information displayed only when -debug switch is present.");
            WriteWarning("This is the warning message!");
        }
    }
}
