using CefSharp;
using CefSharp.OffScreen;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VUA_api.Scraper
{
    class Fetcher
    {
        ChromiumWebBrowser browser = new ChromiumWebBrowser();
        public async Task<string> GetTimetableText(String url)
        {
            while (!browser.IsBrowserInitialized) ;
            await LoadPageAsync(browser, url).ContinueWith(prevTask => prevTask.Wait());
            await Task.Delay(3000); 
            var html = await browser.GetSourceAsync();
            return html;
        }
        public async Task<string> GetFacultyHtml(String url)
        {
            while (!browser.IsBrowserInitialized) ;
            await LoadPageAsync(browser, url).ContinueWith(prevTask => prevTask.Wait());
            var html = await browser.GetSourceAsync();
            return html;
        }
        public static Task LoadPageAsync(IWebBrowser browser, string address = null)
        {
            var tcs = new TaskCompletionSource<bool>();
            EventHandler<LoadingStateChangedEventArgs> handler = null;
            handler += (sender, args) =>
            {
                //Wait for while page to finish loading not just the first frame
                if (!args.IsLoading)
                {
                    browser.LoadingStateChanged -= handler;
                    tcs.TrySetResult(true);
                }
            };
            browser.LoadingStateChanged += handler;
            if (!string.IsNullOrEmpty(address)) { browser.Load(address); }
            return tcs.Task;
        }
    }
}
