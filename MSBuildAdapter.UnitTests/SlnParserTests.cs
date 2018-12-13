using System;
using System.Linq;
using System.IO;
using Xunit;

using MSBuildAdapter.Parsers;

namespace MSBuildAdapter.UnitTests
{
    public class SlnParserTests
    {
        private static readonly string TEST_SOURCES = "TestFiles";

        [Fact]
        public void ParseSln_GetAllProjects()
        {
            string[] expectedProjects = { "MSBuildAdapter.UnitTests.csproj", "MSBuildAdapter.csproj" };


            var slnParser = new SlnParser();
            var projects = slnParser.Parse(Path.Combine(TEST_SOURCES, "Sln.sln")).ToList();

            Assert.Equal(projects.Count(), expectedProjects.Length);
            Assert.All(projects, p => expectedProjects.Any(e => e.EndsWith(p)));
        }
    }
}
