using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace AsyncProgrammingClassLibrary
{
    /// <summary>
    /// Post 服務物件可接收真物件與假測試物件
    /// </summary>
    public class CustomReportService : IReportClient
    {
        /// <summary>
        /// 自訂報表主機列隊
        /// </summary>
        private List<IReportClient> ClientList;

        /// <summary>
        /// post 任務緩衝queue
        /// </summary>
        private BlockingCollection<PostData> BlockQueue;

        /// <summary>
        /// Constuctor 用來初始化主機列表
        /// </summary>
        /// <param name="clientList">主機列表</param>
        public CustomReportService(List<IReportClient> clientList, List<int> maxService)
        {
            ClientList = clientList;
            BlockQueue = new BlockingCollection<PostData>();
            if (clientList.Count != maxService.Count)
            {
                throw new Exception();
            }
            for (int i = 0; i < clientList.Count; i++)
            {
                for (int j = 0; j < maxService[i]; j++)
                {
                    int thread_id = i+1;
                    IReportClient client = clientList[i];
                    Task.Run(() => RunConsumer(client, thread_id));
                }
            }
            Console.WriteLine("Start Run Dispatcher!");
        }

        /// <summary>
        /// Run Service Method
        /// </summary>
        /// <param name="postBody">api post body</param>
        /// <returns></returns>  
        public async Task<CustomReportResponseBody> PostCustomReport(CustomReportPostBody postBody)
        {
            TaskCompletionSource<CustomReportResponseBody> task = new TaskCompletionSource<CustomReportResponseBody>();
            PostData queueData = new PostData(postBody, task);
            BlockQueue.Add(queueData);
            Console.WriteLine("Post processed!");
            return await task.Task;
        }

        /// <summary>
        /// 消費者方法
        /// </summary>
        /// <param name="client">執行主機</param>
        /// <param name="clientIndex">執行主機編號</param>
        private void RunConsumer(IReportClient client, int clientIndex)
        {
            PostData data = null;
            while (!BlockQueue.IsCompleted)
            {
                data = BlockQueue.Take();
                if (data != null)
                {
                    var result = client.PostCustomReport(data.PostBody);
                    data.TaskResult.SetResult(result.Result);
                    Console.WriteLine($"Client {clientIndex} Procces completed!");
                }
            }
        }

        /// <summary>
        /// 釋放緩衝區方法
        /// </summary>
        public void Dispose()
        {
            BlockQueue.Dispose();
        }
    }
}
