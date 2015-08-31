using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;

namespace WordpressTests
{
    [TestClass]
    public class LoginTests : WordpressTest
    {

        [TestMethod]
        public void Admin_Can_User_Login()
        {
            
            Assert.IsTrue(DashboardPage.IsAt, "Failed to login");       
        }

    }
}
