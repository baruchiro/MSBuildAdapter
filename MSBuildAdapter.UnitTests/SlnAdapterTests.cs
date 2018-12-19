using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Xunit;

using MSBuildAdapter.Adapters;

namespace MSBuildAdapter.UnitTests
{
    public class SlnAdapterTests
    {
        public static readonly IEnumerable<object[]> projects = TestUtils.projects.Select(p => new[] { p.Key, p.Value });
        private static readonly string workDir = Directory.GetCurrentDirectory();
        private SlnAdapter slnAdapter;

        public SlnAdapterTests()
        {
            var slnPath = Path.Combine(TestUtils.TEST_SOURCES, "eShopOnWeb", "eShopOnWeb.sln");
            Assert.True(File.Exists(slnPath), $"The file {slnPath} not exist");
            slnAdapter = new SlnAdapter(slnPath);
        }

        [Fact]
        public void ParseSln_GetAllProjects()
        {
            var projects = slnAdapter.GetProjects().Select(p => p.Name).ToList();

            Assert.Equal(TestUtils.projects.Keys.Count, projects.Count());
            foreach (var expected in TestUtils.projects.Keys)
            {
                Assert.Contains(expected, projects);
            }
        }

        [Theory]
        [MemberData(nameof(projects))]
        public void GetProjectDependencies_GetFirstLevel(string project, dynamic props)
        {
            //Given
            var projectPath = Path.Combine(TestUtils.TEST_SOURCES, "eShopOnWeb", string.Join(Path.PathSeparator, props.Path), project + ".csproj");
            Assert.True(File.Exists(projectPath), $"The file {projectPath} not exist");

            var expectedDependenciesNames = props.Dependencies;

            //When
            IList<ProjectAdapter> dependencies = slnAdapter.GetProjectDependencies(projectPath).ToList();

            //Then
            Assert.Equal(expectedDependenciesNames.Length, dependencies.Count());
            foreach (var depend in expectedDependenciesNames)
            {
                Assert.Contains(dependencies, d => d.Name.Equals(depend));
            }
        }

        [Theory]
        [MemberData(nameof(projects))]
        public void GetProjectDepends_GetFirstLevel(string project, dynamic props)
        {
            //Given
            var projectPath = Path.Combine(TestUtils.TEST_SOURCES, "eShopOnWeb", props.Path, project + ".csproj");
            Assert.True(File.Exists(projectPath));

            //When
            var dependencies = slnAdapter.GetProjectDepends(projectPath);

            //Then
            foreach (var depend in dependencies)
            {
                Assert.True(TestUtils.projects[depend.Name].Dependencies.Contain(project));
            }
        }
    }
}
