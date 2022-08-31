using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AsyncProgrammingClassLibrary
{
    /// <summary>
    /// /api/CustomReport post response body definition
    /// </summary>
    public class CustomReportResponseBody
    {
        [JsonProperty(PropertyName = "isCompleted")]
        /// <summary>
        /// isCompleted
        /// </summary>
        public bool isCompleted { get; set; }

        [JsonProperty(PropertyName = "isFaulted")]
        /// <summary>
        /// isFaulted
        /// </summary>
        public bool isFaulted { get; set; }

        [JsonProperty(PropertyName = "signature")]
        /// <summary>
        /// signature
        /// </summary>
        public string? signature { get; set; }

        [JsonProperty(PropertyName = "exception")]
        /// <summary>
        /// exception
        /// </summary>
        public string? exception { get; set; }

        [JsonProperty(PropertyName = "result")]
        /// <summary>
        /// result
        /// </summary>
        public string? result { get; set; }
    }
}
