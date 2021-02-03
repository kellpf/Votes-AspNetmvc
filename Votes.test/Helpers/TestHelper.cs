using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Votes.Selenium.test
{
    public static class TestHelper
    {
        public static string ExecuteFolder => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }
}
