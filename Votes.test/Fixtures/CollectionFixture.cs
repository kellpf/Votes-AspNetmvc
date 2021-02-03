using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Votes.Selenium.test.Fixtures
{
    [CollectionDefinition("Chrome Driver")]
    public class CollectionFixture : ICollectionFixture<TestFixture>
    {
    }
}
