using System;
using System.Linq;
using System.IO;
using Xunit;

using MSBuildAdapter.Parsers;

namespace MSBuildAdapter.UnitTests
{
    public class SlnParserTests
    {
        private static readonly string TEST_SOURCES = "TestData";

        [Fact]
        public void ParseSln_GetAllProjects()
        {
            var slnParser = new SlnParser();
            var projects = slnParser.Parse(Path.Combine(TEST_SOURCES, "eShopOnWeb", "eShopOnWeb.sln")).ToList();

            Assert.Equal(TestUtils.projects.Keys.Count, projects.Count());
            foreach (var expected in TestUtils.projects.Keys)
            {
                Assert.True(projects.Any(p => p.EndsWith(expected + ".csproj")), $"'{expected}' not exist in \n[{string.Join('\n', projects)}]");
            }
        }
    }
}
