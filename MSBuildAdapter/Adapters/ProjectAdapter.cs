using System.IO;

namespace MSBuildAdapter.Adapters
{
    public class ProjectAdapter
    {
        private string path;
        public string Name => Path.GetFileNameWithoutExtension(path);

        public ProjectAdapter(string path)
        {
            this.path = path;
        }


    }
}