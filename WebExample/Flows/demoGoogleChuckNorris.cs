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
    class demoGoogleChuckNorris
    {
        public demoGoogleChuckNorris(EnvObj envObj)
        {

            GoogleWeb google = new GoogleWeb(envObj);
            google.SearchGoogle("Chuck Norris");
            
        }

    }
}
