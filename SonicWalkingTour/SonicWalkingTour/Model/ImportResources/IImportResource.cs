using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace SonicWalkingTour.Model.ImportResources
{
    public interface IImportResource
    {

        public Task<string> ImportFileResouce( string file);

        public Stream GetStreamFromFile(string path, string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream(path + filename);
            return stream;
        }

    }
}
