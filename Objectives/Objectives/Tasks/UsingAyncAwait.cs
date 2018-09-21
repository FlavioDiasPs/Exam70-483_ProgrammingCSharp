using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ImplementingThreads_1_1.Tasks
{
    public static class UsingAyncAwait
    {

        public static async Task RunAsyncOperation()
        {
            string result = await DownloadContent();
            Console.WriteLine(result);
        }

        public static async Task<string> DownloadContent()
        {
            using (var client = new HttpClient())            
                return await client.GetStringAsync("http://www.microsoft.com");                       
        }
    }    
}
