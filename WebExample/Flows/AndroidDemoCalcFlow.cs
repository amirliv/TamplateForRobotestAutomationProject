using Robotest.LAInfra;
using Robotest.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using Robotest.WinApp;
using System.Reflection;
using OpenQA.Selenium.Appium.Android;
using Robotest.Mobile;

namespace Robotest.Flows
{
    class AndroidDemoCalcFlow
    {
        public AndroidDemoCalcFlow(EnvObj envObj)
        {
            CalcDemoAndroid clacAndroidDemo = new CalcDemoAndroid(envObj);
            clacAndroidDemo.Sum();
        }

    }
}
