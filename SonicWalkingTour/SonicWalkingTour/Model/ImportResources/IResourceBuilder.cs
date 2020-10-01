using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SonicWalkingTour.Model.ImportResources
{
    public interface IResourceBuilder
    {

        Task buildTextResourcesAsync();

        Task buildAudioResources();

        public string getTextValue(string page);

        public Dictionary<string, string> getHashTable();

    }
}
