using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgrammingClassLibrary
{
    /// <summary>
    /// 自定義Exception 超過最大請求總數時拋出例外
    /// </summary>
    public class ExceedMaxServicesException : Exception
    {
        /// <summary>
        /// 拋出超出最大請求數例外資訊
        /// </summary>
        /// <param name="maxServiceNum">最大請求數量</param>
        public ExceedMaxServicesException(int maxServiceNum) : base($"Current demanding Services exceeds Maximum Services number {maxServiceNum}!!!")
        {
        }
    }
}
