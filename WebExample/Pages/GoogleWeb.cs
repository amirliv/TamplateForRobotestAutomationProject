using Robotest.LAInfra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Robotest.LAInfra.Operations;

namespace Robotest.Pages
{
    class GoogleWeb
    {
        string editBoxtoGoogleXpath = @".//input[@aria-label='Search']";
        string clickSearchXpath = @".//input[@value='Google Search']";

        public EnvObj envObj;

        public GoogleWeb(EnvObj envObj)
        {
            this.envObj = envObj;
        }

        public void SearchGoogle(string stringToGoogle)
        {
            envObj.reporter.Info(envObj, LAInfra.ConstValues.strStartMethod, MethodBase.GetCurrentMethod().Name, "");

            envObj.CreateDriver(ConstValues.driversPath, envObj.browser_num);

            for (int i = 0; i < 2; i++)
            {
                envObj.operations.Navigate(envObj, @"https://www.google.com/", "");
                    
                envObj.operations.InputEditBox(envObj, BY.XPath, editBoxtoGoogleXpath, stringToGoogle, 3, "");
                    
                envObj.operations.ClickElement(envObj, BY.XPath, clickSearchXpath, 3, "");

            }
        } 
    }
}
