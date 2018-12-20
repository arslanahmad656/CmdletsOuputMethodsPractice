using System.Management.Automation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imanami.Groups.Management.Commands.Get.Practice
{
    [CLSCompliant(false)]
    [Cmdlet(VerbsCommon.Get, "ProgressInfo")]
    public class GetProgressInfoCommand : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            var outerProgress = new ProgressRecord(1, "Incrementing outer loop", "Updating");
            var innerProgress = new ProgressRecord(2, "Incrementing inner loop", "Updating");
            for (int i = 0; i < 100; i++)
            {
                outerProgress.PercentComplete = i;
                outerProgress.StatusDescription = $"{i}% complete";
                WriteProgress(outerProgress);
                for (int j = 0; j < 30; j++)
                {
                    innerProgress.PercentComplete = (int)Math.Ceiling((double)j / 30 * 100);
                    innerProgress.PercentComplete = innerProgress.PercentComplete > 100 ? 100 : innerProgress.PercentComplete;
                    innerProgress.StatusDescription = $"{innerProgress.PercentComplete}% complete";
                    WriteProgress(innerProgress);
                }
            }
        }
    }
}
