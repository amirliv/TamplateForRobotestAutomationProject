using Robotest.Flows;
using Robotest.Functions;
using Robotest.LAInfra;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using System.Diagnostics;
using System.Net;
using System.Threading;


namespace Robotest
{
    class Program
    {
        private static readonly object pathToFile;

        static void Main(string[] args)
        {

            LAInfra.Methods.createExcecutionsFolderIfNotExist();
            DateTime dateTime = DateTime.Now;
            ConstValues.reportsPath = ConstValues.reportsPath + "AutomationReports" + dateTime.Year + "-" + (dateTime.Month) + "-" + dateTime.Day + "_" + dateTime.Hour + "-" + dateTime.Minute;
            ConstValues.flowsReportPath = ConstValues.reportsPath + "/FlowsReport";
            Directory.CreateDirectory(ConstValues.reportsPath);
            StreamWriter flowsReport = new StreamWriter(ConstValues.flowsReportPath, true);
            flowsReport.WriteLine("Flows Report");
            flowsReport.WriteLine("Report - " + dateTime.ToString());
            flowsReport.WriteLine("---------------------------------------------------------------");
            flowsReport.Dispose();

            List<Task> threadsList = new List<Task>();
            List<EnvObj> envmnsList = Execution.GetExecutionsData(ConstValues.execsPath, ConstValues.reportsPath, ConstValues.driversPath, flowsReport, ConstValues.flowsReportPath);

            //envmnsList[0].methods.KillAll();
            //Thread.Sleep(5000);

            foreach (EnvObj env in envmnsList)
            {
                Task task = Task.Factory.StartNew(() => Execute(env));
      
                threadsList.Add(task);
            }

            Task.WaitAll(threadsList.ToArray());
            envmnsList[0].methods.KillBrowsers();
            System.Threading.Thread.Sleep(1000);
            string report = Execution.CreateSummaryHTML(flowsReport, ConstValues.flowsReportPath);
            string mailingList = Execution.ReadFromDT(envmnsList[0].DTPath, "Mailing_list");
            Execution.SendGmail(mailingList, "Summary Report", report);
        }
        

        public static void Execute(object envObject)
        {
            EnvObj envObj = (EnvObj)envObject;
            try
            {
                foreach (String test in envObj.GetTestSet())
                {
                    envObj.excecutionStatus = 0;
                    envObj.firstRun = true;
                    envObj.SetCurrentFlow(test);
                    excecuteFlow(envObj, test);

                    if (envObj.excecutionStatus > 1)//if the first run failed, excecute it again
                    {
                        envObj.excecutionStatus = 0;
                        envObj.firstRun = false;
                        excecuteFlow(envObj, envObj.currentFlow);
                    }
                }
            }
            catch (FailsCountException ex)
            {
                try
                {
                    if (envObj.excecutionStatus > 1)//if the first run failed, excecute it again
                    {
                        envObj.excecutionStatus = 0;
                        envObj.firstRun = false;
                        excecuteFlow(envObj, envObj.currentFlow);
                    }
                }
                catch (FailsCountException e)
                {

                }
            }
            Execution.AfterExe(envObj);
        }

        public static void excecuteFlow(EnvObj envObj, string test)
        {

            envObj.methods.startingFlow(envObj);

            try
            {
                switch (test)
                {
                    //case "DisableUserBySecurityAdmin": new DisableUserBySecurityAdmin(envObj); break;

                    case "AndroidDemoCalcFlow": new AndroidDemoCalcFlow(envObj); break;
                    case "demoGoogleChuckNorris": new demoGoogleChuckNorris(envObj);break;
                    case "demoGoogleElvis": new demoGoogleElvis(envObj); break;
                    case "demoAmazonAddToCart": new demoAmazonAddToCart(envObj); break;
                    case "demoAmazonEchoDot": new demoAmazonEchoDot(envObj); break;

                    default: envObj.reporter.Failed(envObj, "No test set with name: " + test, "", "No test set with name: " + test); break;
                }
            }
            catch (FailsCountException ex)
            {
                envObj.reporter.Info(envObj, " Too many failures", " Too many failures!!", "");
                throw new FailsCountException(ex.counter);
            }

            finally
            {
                envObj.reporter.Info(envObj, LAInfra.ConstValues.strEndFlow, " " + envObj.GetCurrentFlow(), LAInfra.ConstValues.strStatus + envObj.GetexcecutionStatus().ToString());
            }
            }

        }
}
