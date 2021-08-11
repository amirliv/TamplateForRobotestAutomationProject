//using Robotest.LAInfra;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;


//namespace Robotest.WinApp
//{
//    class Calc
//    {
//        public EnvObj envObj;

//        public Calc(EnvObj envObj)
//        {
//            this.envObj = envObj;
//        }
//        public void Sum()
//        {
//            envObj.methods.KillProcess("calc1.exe");
//            envObj.reporter.Info(envObj, LAInfra.ConstValues.strStartMethod, MethodBase.GetCurrentMethod().Name, "");
//            envObj.methods.AutoItBusy(envObj, 10);
//            Thread.Sleep(600);
//            envObj.autoit.Run("calc1.exe");
//            envObj.autoit.WinWaitActive("Calculator","",10);
//            envObj.autoit.WinActive("Calculator");
//            for (int i = 0; i < 25; i++)
//            {

//                envObj.reporter.Info(envObj, "button 2", "Click the number 1", "");
//                envObj.autoit.ControlClick("Calculator", "", "Button5", "Left");
//                Thread.Sleep(300);
//                envObj.reporter.Info(envObj, "button 2", "Click the number 2 (12)", "");
//                envObj.autoit.ControlClick("Calculator", "", "Button11", "Left");
//                Thread.Sleep(300);
//                envObj.reporter.Info(envObj, "button 2", "Click the + button", "");
//                envObj.autoit.ControlClick("Calculator", "", "Button23", "Left");
//                Thread.Sleep(300);
//                envObj.reporter.Info(envObj, "button 2", "Click the number 3", "");
//                envObj.autoit.ControlClick("Calculator", "", "Button16", "Left");
//                Thread.Sleep(300);
//                envObj.reporter.Info(envObj, "button 2", "Click the Equal button (=)", "");
//                envObj.autoit.ControlClick("Calculator", "", "Button28", "Left");
//                string a = envObj.autoit.ControlGetText(@"Calculator", "", "#327701");

//                envObj.reporter.Passed(envObj, "button 2", "Recived the excpected resoults: 15", "");
//                Thread.Sleep(400);
//            }
//            //envObj.autoit.WinClose("Calculator");
//            envObj.methods.AutoItFree();
//        }








//    }
//}
