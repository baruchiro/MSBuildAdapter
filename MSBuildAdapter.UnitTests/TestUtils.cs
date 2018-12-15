using System;
using System.Linq;
using System.Collections.Generic;
using MSBuildAdapter;

namespace MSBuildAdapter.UnitTests
{
    class TestUtils
    {
        public static readonly Dictionary<string, dynamic> projects =
            new Dictionary<string, dynamic>()
            {
                {"ApplicationCore", new {Path = new[] {"src"}, TargetFramework = new[] {Framework.netstandard20}}},
                {"Infrastructure", new { Path = new[] {"src"}, TargetFramework = new[] {Framework.netstandard20}}},
                {"Web", new {Path = new[] {"src"}, TargetFramework = new[] {Framework.netcoreapp21} }},
                {"WebRazorPages", new {Path = new[] {"src"}, TargetFramework = new[] {Framework.netcoreapp21} }},
                {"FunctionalTests", new {Path = new[] {"tests"}, TargetFramework = new[] {Framework.netcoreapp21} }},
                {"IntegrationTests", new {Path = new[] {"tests"}, TargetFramework = new[] {Framework.netcoreapp21} }},
                {"UnitTests", new {Path = new[] {"tests"}, TargetFramework = new[] {Framework.netcoreapp21} }}
            };
    }
}