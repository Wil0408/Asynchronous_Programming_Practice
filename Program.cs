using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using AsyncProgrammingClassLibrary;

static class Program
{
    /// <summary>
    /// Main function
    /// </summary>
    /// <returns></returns>
    [STAThread]
    static void Main()
    {
        // 請求數量
        const int NumTasks = 10;

        List<IReportClient> clientList = new List<IReportClient>();
        List<int> maxService = new List<int>();
        //clientList.Add(new ReportClient("http://192.168.10.146:5000/api/CustomReport"));
        //maxService.Add(30);
        //clientList.Add(testClient);
        //maxService.Add(50);
        clientList.Add(new TestReportClient(1000));
        maxService.Add(1);
        clientList.Add(new TestReportClient(1000));
        maxService.Add(1);
        clientList.Add(new TestReportClient(1000));
        maxService.Add(1);

        CustomReportService testCustomReportService = new CustomReportService(clientList, maxService);

        CustomReportPostBody testPostBody = new CustomReportPostBody();
        testPostBody.Dtno = 5493;
        testPostBody.Ftno = 0;
        testPostBody.Params = "AssignID=00878;AssignDate=20200101-99999999;DTOrder=2;MTPeriod=2;";
        testPostBody.KeyMap = string.Empty;
        testPostBody.AssignSpid = string.Empty;

        var tasks = new List<Task>();
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        for (int i = 0; i < NumTasks; i++)
        {
            tasks.Add(testCustomReportService.PostCustomReport(testPostBody));
        }
        Task taskAfterAllCompleted = Task.WhenAll(tasks);
        taskAfterAllCompleted.Wait();

        stopWatch.Stop();
        TimeSpan timeSpan = stopWatch.Elapsed;

        string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}:{3:00}",
            timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
        Console.WriteLine(elapsedTime);
    }
}
