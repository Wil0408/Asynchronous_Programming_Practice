using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgrammingClassLibrary
{
    /// <summary>
    /// Fake Report Client object
    /// </summary>
    public class TestReportClient : IReportClient
    {
        /// <summary>
        /// 單一服務平均回應時間
        /// </summary>
        private int AverageResponseTime;

        /// <summary>
        /// Constructor 初始化假物件設訂定平均回應時間
        /// </summary>
        public TestReportClient(int avgResponseTime)
        {
            AverageResponseTime = avgResponseTime;
        }

        /// <summary>
        /// Constructor 初始化假物件使用預設平均回應時間
        /// </summary>
        public TestReportClient()
        {
            AverageResponseTime = 200;
        }

        /// <summary>
        /// 設定假物件服務平均回應時間與最大請求數量
        /// </summary>
        /// <param name="averageResponseTIme">平均回應時間</param>
        /// <param name="maxTotalTaskNum">最大同時請求數量</param>
        public void TestServiceSetting(int averageResponseTIme)
        {
            AverageResponseTime = averageResponseTIme;
        }

        /// <summary>
        /// api/Custom fake post method
        /// </summary>
        /// <param name="postBody">api post body</param>
        /// <returns></returns>
        /// <exception cref="ExceedMaxServicesException">超出最大請求數量拋出例外</exception>
        public async Task<CustomReportResponseBody?> PostCustomReport(CustomReportPostBody postBody)
        {
            // 假物件回傳post body
            CustomReportResponseBody body = new CustomReportResponseBody();
            body.isCompleted = true;
            body.isFaulted = false;
            body.signature = "99.95";
            body.exception = string.Empty;
            body.result = "Test Success!";

            // 假物件請求處理時間
            await Task.Delay(AverageResponseTime);

            return body;
        }
    }
}
