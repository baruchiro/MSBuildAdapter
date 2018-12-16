using System;
using System.Linq;
using System.IO;
using Xunit;

using MSBuildAdapter.Adapters;

namespace MSBuildAdapter.UnitTests
{
    public class ProjectTests
    {
        private static readonly string TEST_SOURCES = "TestFiles";

        [Fact]
        public void ProjectProps_GetFramework()
        {
            var projects = TestUtils.projects.Select(p => new ProjectAdapter(Path.Combine(p.Value.Path) + Path.PathSeparator + p.Key + ".csproj"));
        }
    }
}
