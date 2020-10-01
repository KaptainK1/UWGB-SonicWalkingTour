using System;
using System.Collections.Generic;

namespace SonicWalkingTour.Model.ImportResources
{
    public class ResourceDirector
    {
        private IResourceBuilder resourceBuilder;

        public ResourceDirector(IResourceBuilder builder)
        {
            resourceBuilder = builder;
        }

        public async void loadTextResources()
        {
           await resourceBuilder.buildTextResourcesAsync();
        }

        public void loadAudioResources()
        {
            resourceBuilder.buildAudioResources();
        }

        public string getFileText(string page)
        {
            return resourceBuilder.getTextValue(page);
        }

        public Dictionary<string, string> getHashTable()
        {
            return resourceBuilder.getHashTable();
        }
    }
}
