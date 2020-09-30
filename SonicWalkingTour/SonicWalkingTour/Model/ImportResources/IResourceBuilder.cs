using System;
namespace SonicWalkingTour.Model.ImportResources
{
    public interface IResourceBuilder
    {

        System.Threading.Tasks.Task buildTextResourcesAsync();

        void buildAudioResources();

    }
}
