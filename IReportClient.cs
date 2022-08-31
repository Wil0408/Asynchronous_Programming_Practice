using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgrammingClassLibrary
{
    /// <summary>
    /// 定義Report client 介面實作方法
    /// </summary>
    public interface IReportClient
    {
        /// <summary>
        /// api/CustomReport post method
        /// </summary>
        /// <param name="postBody">api post body</param>
        /// <returns></returns>
        public Task<CustomReportResponseBody> PostCustomReport(CustomReportPostBody postBody);
    }
}
