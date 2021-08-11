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
    class demoAmazonAddToCart
    {
        public demoAmazonAddToCart(EnvObj envObj)
        {
            Amazon amazon = new Amazon(envObj);
            amazon.addToCart();
        }

    }
}
