using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WordpressAutomation
{
    public class PostPage
    {
        public static string Title
        {
            get { var title = Driver.Instance.FindElement(By.ClassName("entry-title"));
                if (title != null)
                    return title.Text;
                return String.Empty;

            }
          
        }
    }
}
