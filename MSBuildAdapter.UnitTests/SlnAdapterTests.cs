using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Xunit;

using MSBuildAdapter.Parsers;

namespace MSBuildAdapter.UnitTests
{
    public class SlnAdapterTests
    {
        public static readonly IEnumerable<object[]> projects = TestUtils.projects.Select(p => new[] { p.Key, p.Value });
        private static readonly string TEST_SOURCES = "TestData";
        private SlnAdapter slnAdapter;

        public SlnAdapterTests()
        {
            var slnPath = Path.Combine(TEST_SOURCES, "eShopOnWeb", "eShopOnWeb.sln");
            slnAdapter = new SlnAdapter(slnPath);
        }

        [Fact]
        public void ParseSln_GetAllProjects()
        {
            var projects = slnAdapter.GetProjects();

            Assert.Equal(TestUtils.projects.Keys.Count, projects.Count());
            foreach (var expected in TestUtils.projects.Keys)
            {
                Assert.True(projects.Any(p => p.EndsWith(expected + ".csproj")), $"'{expected}' not exist in \n[{string.Join('\n', projects)}]");
            }
        }

        [Theory]
        [MemberData(nameof(projects))]
        public void GetProjectDependencies_GetFirstLevel(string project, dynamic props)
        {
            //Given
            var projectPath = Path.Combine(TEST_SOURCES, "eShopOnWeb", props.Path, project + ".csproj");
            Assert.True(File.Exists(projectPath));

            var expectedDependenciesNames = props.Dependencies;

            //When
            var dependencies = slnAdapter.GetProjectDependencies(projectPath);

            //Then
            Assert.Equal(expectedDependenciesNames.Length, dependencies.Count());
            foreach (var depend in expectedDependenciesNames)
            {
                Assert.True(dependencies.Any(d => d.EndWith(depend + ".csproj")));
            }
        }

        [Theory]
        [MemberData(nameof(projects))]
        public void GetProjectDepends_GetFirstLevel(string project, dynamic props)
        {
            //Given
            var projectPath = Path.Combine(TEST_SOURCES, "eShopOnWeb", props.Path, project + ".csproj");
            Assert.True(File.Exists(projectPath));

            //When
            var dependencies = slnAdapter.GetProjectDepends(projectPath);

            //Then
            foreach (var depend in dependencies.Select(Path.GetFileNameWithoutExtension))
            {
                Assert.True(TestUtils.projects[depend].Dependencies.Contain(project));
            }
        }
    }
}
