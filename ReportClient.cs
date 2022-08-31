using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AsyncProgrammingClassLibrary
{
    /// <summary>
    /// Report Client object
    /// </summary>
    public class ReportClient : IReportClient
    {
        /// <summary>
        /// httpclient object
        /// </summary>
        private readonly HttpClient client;

        /// <summary>
        /// Constructor
        /// </summary>
        public ReportClient(string uri)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(uri);
        }

        /// <summary>
        /// api/CustomReport post method
        /// </summary>
        /// <param name="postBody">api post body</param>
        /// <returns></returns>
        public async Task<CustomReportResponseBody?> PostCustomReport(CustomReportPostBody postBody)
        {
            string jsonBody = JsonConvert.SerializeObject(postBody);
            var postContent = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(string.Empty, postContent);
            string? content = await result.Content.ReadAsStringAsync();
            CustomReportResponseBody? resultBody = JsonConvert.DeserializeObject<CustomReportResponseBody>(content);
            return resultBody;
        }
    }
}
