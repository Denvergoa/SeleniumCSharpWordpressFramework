using OpenQA.Selenium;

namespace WordpressAutomation
{
    public class DashboardPage
    {
        public static bool IsAt
        {
            //Refactor: Can we create a general IsAt for all pages?
            get { var h2s = Driver.Instance.FindElements(By.TagName("h2"));
                if (h2s.Count > 0)
                    return h2s[0].Text == "Dashboard";
                else return false;
            }
        
        }
    }
}
