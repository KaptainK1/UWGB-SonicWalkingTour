using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace SonicWalkingTour.Model.ImportResources
{
    public class ImportTextFileLocal : IImportResource
    {

        private string path;

        public ImportTextFileLocal(string path)
        {
            this.path = path;
        }

        public async Task<char[]> ImportFileResouce(string file)
        {
            StreamReader fileToRead = new StreamReader(((IImportResource)this).GetStreamFromFile(path,file));
            Char[] buffer;

            using (fileToRead)
            {
                buffer = new Char[(int)fileToRead.BaseStream.Length];
                await fileToRead.ReadAsync(buffer, 0, (int)fileToRead.BaseStream.Length);
            }
            return buffer;
        }
    }
}
