using Robotest.LAInfra;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Robotest.Mobile
{
    class CalcDemoAndroid
    {
        public EnvObj envObj;

        public CalcDemoAndroid(EnvObj envObj)
        {
            this.envObj = envObj;
        }
        public void Sum()
        {

            envObj.reporter.Info(envObj, LAInfra.ConstValues.strStartMethod, MethodBase.GetCurrentMethod().Name, "");

            string AndroidID = @"com.sec.android.app.popupcalculator:id/bt_01";
            envObj.AndroidOperations.ClickElement(envObj, AndroidOperations.BY.Id, AndroidID, 3, "clicking '1' button");

            //  accessibility id    Plus
            //  id  com.sec.android.app.popupcalculator:id / bt_add
            //  xpath	//android.widget.Button[@content-desc="Plus"]
            AndroidID = @"com.sec.android.app.popupcalculator:id/bt_add";
            envObj.AndroidOperations.ClickElement(envObj, AndroidOperations.BY.Id, AndroidID, 3, "clicking '+' button");

            AndroidID = @"com.sec.android.app.popupcalculator:id/bt_03";
            envObj.AndroidOperations.ClickElement(envObj, AndroidOperations.BY.Id, AndroidID, 3, "clicking '3' button");

            string AccessibilityId = @"Equal";
            envObj.AndroidOperations.ClickElement(envObj, AndroidOperations.BY.AccessibilityId, AccessibilityId, 3, "clicking 'equal' button");

            AndroidID = @"com.sec.android.app.popupcalculator:id/txtCalc";
            string a = envObj.AndroidOperations.GetElementText(envObj, AndroidOperations.BY.Id, AndroidID, 3, "Getting the output");

            if (a == "4")
                envObj.reporter.Passed(envObj, AndroidID, @"recived:'4', as expected ",a);

            //envObj.AndroidDriver.FindElementByAccessibilityId("Plus").Click();
            //envObj.AndroidDriver.FindElementById("com.sec.android.app.popupcalculator:id/bt_03").Click();
            //envObj.AndroidDriver.FindElementByAccessibilityId("Equal").Click();
            //AndroidElement a = envObj.AndroidDriver.FindElementById("com.sec.android.app.popupcalculator:id/txtCalc");

            //xpath = @".//input[@value='Google Search']";
            //envObj.operations.ClickElement(envObj, BY.XPath, xpath, 3, "");


        }
    }
}
