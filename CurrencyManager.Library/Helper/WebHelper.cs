using System;

namespace CurrencyManager.Library.Helper
{
    public static class WebHelper
    {
        public static string DownloadHtml(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                Task<HttpResponseMessage> responseTask = client.GetAsync(url);
                responseTask.Wait();

                responseTask.Result.EnsureSuccessStatusCode(); // Throw an exception if the status code is not successful
                Task<string> resultTask = responseTask.Result.Content.ReadAsStringAsync();
                resultTask.Wait();

                return resultTask.Result;
            }
        }
    }
}