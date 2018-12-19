using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Xunit;

using MSBuildAdapter.Adapters;

namespace MSBuildAdapter.UnitTests
{
    public class ProjectTests
    {
        public static readonly IEnumerable<object[]> projects = TestUtils.projects.Select(p => new[] { p.Key, p.Value });


        [Fact]
        public void ProjectProps_GetFramework()
        {
            var projects = TestUtils.projects.Select(p => new ProjectAdapter(Path.Combine(p.Value.Path) + Path.PathSeparator + p.Key + ".csproj"));
        }
    }
}
