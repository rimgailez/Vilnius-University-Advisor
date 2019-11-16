using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VUA_api.Scraper
{
    public class MessageSender : Hub
    {
        public void StartScraper() 
        {
            //ScraperMain scraperMain = new ScraperMain(DataMaster.GetInstance().jsonReaderWriter.projectPath);
            //scraperMain.ObjectsScraped += OnObjectsScraped;
            //scraperMain.StartScrap();
        }

        private void OnObjectsScraped(object sender, string message)
        {
            Clients.All.SendAsync("progress", message);
        }
    }
}
