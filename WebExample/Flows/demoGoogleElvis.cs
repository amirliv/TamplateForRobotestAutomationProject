using Robotest.LAInfra;
using Robotest.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robotest.Flows
{
    class demoGoogleElvis
    {
        public demoGoogleElvis(EnvObj envObj)
        {

            GoogleWeb google = new GoogleWeb(envObj);
            google.SearchGoogle("ELVIS");
            
        }

    }
}
