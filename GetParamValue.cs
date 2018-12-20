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
    [Cmdlet(VerbsCommon.Get, "ParamValue")]
    public class GetParamValue : PSCmdlet
    {
        [Parameter]
        public SwitchParameter Enumerate { get; set; }

        protected override void BeginProcessing()
        {
            Console.WriteLine($"Inside {MethodBase.GetCurrentMethod().Name} of {this.GetType().Name}");
        }

        protected override void ProcessRecord()
        {
            Console.WriteLine($"Inside {MethodBase.GetCurrentMethod().Name} of {this.GetType().Name}");
            var names = new[] { "explorer", "svchost", "devenv", "registry", "notepad++" };
            WriteObject(names, Enumerate);
        }

        protected override void EndProcessing()
        {
            Console.WriteLine($"Inside {MethodBase.GetCurrentMethod().Name} of {this.GetType().Name}");
        }
    }
}
