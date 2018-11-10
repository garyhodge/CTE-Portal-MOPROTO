using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit;
using NUnit.Framework;
using NUnit.Framework.Internal;
using NUnit.Framework.Interfaces;

namespace Appius.Core.Testing
{
    /// <summary>
    /// Custom name attribute for nunit tests
    /// </summary>
    public class TestNameAttribute : NUnitAttribute, IApplyToTest
    {
        public string Name { get; set; }

        public TestNameAttribute(string TestName)
        {
            this.Name = TestName;
        }

        public void ApplyToTest(Test Test)
        {
            Test.Properties.Add("Name", Name);
        }
    }
}
