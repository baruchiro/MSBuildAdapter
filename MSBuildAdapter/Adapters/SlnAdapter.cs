using System;
using System.Collections.Generic;
using System.Linq;
using MSBuildAdapter.Parsers;

namespace MSBuildAdapter.Adapters
{

    public class SlnAdapter
    {
        private string slnPath;

        public SlnAdapter(string slnPath)
        {
            this.slnPath = slnPath;
        }

        public IEnumerable<ProjectAdapter> GetProjects()
        {
            var slnParser = new SlnParser();
            return slnParser.Parse(this.slnPath).Select(p => new ProjectAdapter(p));
        }

        public IEnumerable<ProjectAdapter> GetProjectDependencies(string projectPath)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProjectAdapter> GetProjectDepends(string projectPath)
        {
            throw new NotImplementedException();
        }
    }
}