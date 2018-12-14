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
            string[] expectedProjects = {
                "ApplicationCore",
                "Infrastructure",
                "Web",
                "WebRazorPages",
                "FunctionalTests",
                "IntegrationTests",
                "UnitTests"
                };


            var slnParser = new SlnParser();
            var projects = slnParser.Parse(Path.Combine(TEST_SOURCES, "eShopOnWeb", "eShopOnWeb.sln")).ToList();

            Assert.Equal(expectedProjects.Length, projects.Count());
            foreach (var expected in expectedProjects)
            {
                Assert.True(projects.Any(p => p.EndsWith(expected + ".csproj")), $"'{expected}' not exist in \n[{string.Join('\n', projects)}]");
            }
        }
    }
}
