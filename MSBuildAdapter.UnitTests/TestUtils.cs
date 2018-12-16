using System;
using System.Linq;
using System.Collections.Generic;
using MSBuildAdapter;
using System.Collections;

namespace MSBuildAdapter.UnitTests
{
    class TestUtils
    {
        public static readonly Dictionary<string, dynamic> projects =
            new Dictionary<string, dynamic>()
            {
                {
                    "ApplicationCore", new
                    {
                        Path = new[] {"src"},
                        TargetFramework = new[] {Framework.netstandard20},
                        Dependencies = new string[0]
                    }
                },
                {
                    "Infrastructure", new
                    {
                        Path = new[] {"src"},
                        TargetFramework = new[] {Framework.netstandard20},
                        Dependencies = new[] {"ApplicationCore"}
                    }
                },
                {
                    "Web", new
                    {
                        Path = new[] {"src"},
                        TargetFramework = new[] {Framework.netcoreapp21},
                        Dependencies = new[] {"ApplicationCore", "Infrastructure"}
                    }
                },
                {
                    "WebRazorPages", new
                    {
                        Path = new[] {"src"},
                        TargetFramework = new[] {Framework.netcoreapp21},
                        Dependencies = new[] {"ApplicationCore", "Infrastructure"}
                    }
                },
                {
                    "FunctionalTests", new
                    {
                        Path = new[] {"tests"},
                        TargetFramework = new[] {Framework.netcoreapp21},
                        Dependencies = new[] {"ApplicationCore", "WebRazorPages", "Web"}
                    }
                },
                {
                    "IntegrationTests", new
                    {
                        Path = new[] {"tests"},
                        TargetFramework = new[] {Framework.netcoreapp21},
                        Dependencies = new[] {"Web", "UnitTests"}
                    }
                },
                {
                    "UnitTests", new
                    {
                        Path = new[] {"tests"},
                        TargetFramework = new[] {Framework.netcoreapp21},
                        Dependencies = new[] {"ApplicationCore", "Web"}
                    }
                }
            };
    }
}