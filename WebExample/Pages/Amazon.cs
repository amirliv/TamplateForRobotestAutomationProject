using Robotest.LAInfra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Robotest.LAInfra.Operations;

namespace Robotest.Pages
{
    class Amazon
    {
        //Add to Cart
        string id = @"twotabsearchtextbox";
        string asearchbox = @"//input[@id='twotabsearchtextbox']";
        string suggestion1 = @"//div[@id='issDiv3']";
        string secoundOption = @".//div[@class='s-main-slot s-result-list s-search-results sg-row']/div[@data-index='2']";
        string buyNowID = @"add-to-cart-button";
        string ProceedToID = @"nav-cart-count-container";


        //EchoDot
        string menuXpath = @"//a[@id='nav-hamburger-menu']/i";
        string helpMenuXpath = @"//a[@class='hmenu-item'][normalize-space()='Customer Service']";
        string digitalServicesSuportXpath = @"//h3[contains(text(),'Digital Services and Device Support')]";
        string digitalServicesDeviceSupportheadlineXpath = @"//*[@class='h1headding' and contains(text(),'Digital Services and Device Support')]";
        string echoFamilyXpath = @"//p[contains(text(),'Echo Family')]";
        string echoDotWithClockXpath = @"//*[@class= 'deviceselect' and contains(.,'Echo Dot with clock')]";
 



        public EnvObj envObj;

        public Amazon(EnvObj envObj)
        {
            this.envObj = envObj;
        }

        public void addToCart()
        {
            envObj.reporter.Info(envObj, LAInfra.ConstValues.strStartMethod, MethodBase.GetCurrentMethod().Name, "");

            envObj.CreateDriver(ConstValues.driversPath, envObj.browser_num);

            envObj.operations.Navigate(envObj, @"https://www.amazon.com/", "");

            envObj.operations.InputEditBox(envObj, BY.ID, id, "drone 4k", 15, "fill the search field");

            envObj.operations.ClickElement(envObj, BY.XPath, suggestion1, 15, "Click button");

            envObj.operations.ClickElement(envObj, BY.XPath, secoundOption, 15, "click the secound product");

            envObj.operations.ClickElement(envObj, BY.ID, buyNowID, 15, "click the secound product");

            envObj.operations.ClickElement(envObj, BY.ID, ProceedToID, 15, "proceed to cart");

        }

        public void echoDot()
        {
            envObj.reporter.Info(envObj, LAInfra.ConstValues.strStartMethod, MethodBase.GetCurrentMethod().Name, "");

            envObj.CreateDriver(ConstValues.driversPath, envObj.browser_num);

            envObj.operations.Navigate(envObj, @"https://www.amazon.com/", "");

            envObj.operations.ClickBuggyElement(envObj, BY.XPath, menuXpath,15 , Operations.Action.Failing, 4, "Help Button");

            envObj.operations.ClickElement(envObj, BY.XPath, helpMenuXpath, 20, "Manage Prime button");

            envObj.operations.ClickElement(envObj, BY.XPath, digitalServicesSuportXpath, 15, "Digital Services and Device Support");

            envObj.operations.CheckIfObjectExist(envObj, BY.XPath, digitalServicesDeviceSupportheadlineXpath, 10, Operations.Action.Failing, "Verify that this headline displayed");

            envObj.operations.ClickElement(envObj, BY.XPath, echoFamilyXpath, 15, "Click 'Eco Family'");

            envObj.operations.ClickElement(envObj, BY.XPath, echoDotWithClockXpath, 15, "click the product");

        }
    }
}
