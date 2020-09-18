using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace SonicWalkingTour.Model.ImportResources
{
    class ImportMusicFile : IImportMusicResource
    {
        private string path;

        public ImportMusicFile(string path)
        {
            this.path = path;
        }

        public Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream(path + filename);
            return stream;
        }
    }
}
