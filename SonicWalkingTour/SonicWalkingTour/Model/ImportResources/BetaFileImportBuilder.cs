using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SonicWalkingTour.Model.ImportResources
{
    public class BetaFileImportBuilder : IResourceBuilder
    {
        IImportResource importTextResource;
        IImportMusicResource importMusicResource;
        private Dictionary<string, string> valuePairs;
        private List<string> pages;


        public BetaFileImportBuilder()
        {
            importTextResource = new ImportTextFileLocal("SonicWalkingTour.SharedAssets.Text.");
            importMusicResource = new ImportMusicFile("SonicWalkingTour.SharedAssets.Audio.");

            valuePairs = new Dictionary<string, string>();

            pages = new List<string> {
                "MapPage",
                "PinDetailPage",
                "RegisterPage",
                "RoutePage"
            };

        }

        public async Task buildAudioResources()
        {
            //throw new NotImplementedException();
        }

        public async Task buildTextResourcesAsync()
        {
            //contain a list of tasks with return type of char[]
            List<Task<string>> tasks = new List<Task<string>>();

            //add the tasks to the list
            tasks.Add(importTextResource.ImportFileResouce("mapPageHelpText.txt"));
            tasks.Add(importTextResource.ImportFileResouce("detailPageHelpText.txt"));
            tasks.Add(importTextResource.ImportFileResouce("registrationPageHelpText.txt"));
            tasks.Add(importTextResource.ImportFileResouce("routePageHelpText.txt"));

            //wait until all tasks are done fetching the text from the files
            var results = await Task.WhenAll(tasks);

            int i = 0;
            //go through each
            foreach(var item in results)
            {
                valuePairs.Add(pages[i], item);
                i++;
            }

            //valuePairs.Add(typeof(PinDetailPage), await Task.Run (() => importTextResource.ImportFileResouce("detailPageHelpText.txt").Result));
            //valuePairs.Add(typeof(MapPage), importTextResource.ImportFileResouce("mapPageHelpText.txt").Result);
            //valuePairs.Add(typeof(RegisterPage), importTextResource.ImportFileResouce("registrationPageHelpText.txt").Result);
            //valuePairs.Add(typeof(RoutePage), importTextResource.ImportFileResouce("routePageHelpText.txt").Result);


        }

        public Dictionary<string, string> getHashTable()
        {
            return valuePairs;
        }

        public string getTextValue(string page)
        {
            string value;
            if (valuePairs.TryGetValue(page, out value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        //public void addPair(Type page)
        //{
        //    valuePairs.Add(page, )
        //}

        /*
        public Task loadLocalResource(string path)
        {
            return;
        }
        */
    }
}
