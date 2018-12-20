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
    [Cmdlet(VerbsCommon.Get, "NameProcess")]
    public class GetNameProcess : PSCmdlet
    {
        private int _counter;

        [Parameter(ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public string[] Names { get; set; }

        protected override void BeginProcessing()
        {
            _counter = 1;
            Console.WriteLine($"Inside {MethodBase.GetCurrentMethod().Name} of {this.GetType().Name}");
        }

        protected override void ProcessRecord()
        {
            if (_counter++ == 2)
            {
                throw new Exception("Intentionally thrown an exception to study the behaviour of phase 2. Will the next record be processed?? or the entire pipeline will fail?");
            }
            Console.WriteLine($"Inside {MethodBase.GetCurrentMethod().Name} of {this.GetType().Name}");
            if (Names == null)
            {
                WriteObject(Process.GetProcesses(), true);
            }
            else
            {
                foreach (var name in Names)
                {
                    var output = Process.GetProcessesByName(name);
                    WriteObject(output, true);
                }
            }
        }

        protected override void EndProcessing()
        {
            Console.WriteLine($"Inside {MethodBase.GetCurrentMethod().Name} of {this.GetType().Name}");
        }
    }
}
