using System;
using System.IO;

namespace SonicWalkingTour.Model.ImportResources
{
    public interface IImportMusicResource
    {
        Stream GetStreamFromFile(string filename);
    }

}
