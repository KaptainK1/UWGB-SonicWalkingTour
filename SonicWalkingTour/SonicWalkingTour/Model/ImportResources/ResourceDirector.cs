using System;
namespace SonicWalkingTour.Model.ImportResources
{
    public class ResourceDirector
    {
        private IResourceBuilder resourceBuilder;

        public ResourceDirector(IResourceBuilder builder)
        {
            resourceBuilder = builder;
        }

        public void loadTextResources()
        {
            resourceBuilder.buildAudioResources();
        }

        public void loadAudioResources()
        {
            resourceBuilder.buildAudioResources();
        }
    }
}
