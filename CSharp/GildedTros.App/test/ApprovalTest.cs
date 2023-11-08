using System;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;
using Xunit;

namespace GildedTros.App
{
    [UseReporter(typeof(DiffReporter))]
    public class ApprovalTest
    {
        [Fact]
        public void ThirtyDays()
        {
            var outputStringBuilder = new StringBuilder();
            Console.SetOut(new StringWriter(outputStringBuilder));

            Program.Main(new string[] { });

            var output = outputStringBuilder.ToString();
            Approvals.Verify(output);
        }
    }
}
