using System;
using System.Collections.Generic;

namespace SonicWalkingTour.Model.ImportResources
{
    public class BetaFileImportBuilder : IResourceBuilder
    {
        IImportResource importTextResource;
        IImportMusicResource importMusicResource;
        private Dictionary<Type, char[]> valuePairs;

        public BetaFileImportBuilder()
        {
            importTextResource = new ImportTextFileLocal("SonicWalkingTour.SharedAssets.Text.");
            importMusicResource = new ImportMusicFile("SonicWalkingTour.SharedAssets.Audio.");

        }

        public void buildAudioResources()
        {
            throw new NotImplementedException();
        }

        public async System.Threading.Tasks.Task buildTextResourcesAsync()
        {
            valuePairs.Add(typeof(RegisterPage), await importTextResource.ImportFileResouce("TestFile.txt"));

        }
    }
}
