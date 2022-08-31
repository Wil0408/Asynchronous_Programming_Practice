using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgrammingClassLibrary
{
    /// <summary>
    /// 用於緩衝等待空閒主機執行的postBody、TaskCompletionSource 資訊物件
    /// </summary>
    public class PostData
    {
        /// <summary>
        /// post 物件
        /// </summary>
        public CustomReportPostBody PostBody { get; set; }

        /// <summary>
        /// 使用TaskCompletionSource使得Task能在空閒主機執行post method後完成
        /// </summary>
        public TaskCompletionSource<CustomReportResponseBody> TaskResult { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="postBody">post 物件</param>
        /// <param name="taskResult">TaskCompletionSource</param>
        public PostData(CustomReportPostBody postBody, TaskCompletionSource<CustomReportResponseBody> taskResult)
        {
            PostBody = postBody;
            TaskResult = taskResult;
        }
    }
}
