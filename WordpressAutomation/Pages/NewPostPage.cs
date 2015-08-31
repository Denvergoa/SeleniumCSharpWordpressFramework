using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WordpressAutomation
{
    public class NewPostPage
    {
        public static void GoTo()
        {
            //Refactor: Should we make a general menu navigation?
            LeftNavigation.Posts.AddNew.Select();



            
        }

        public static CreatePostCommand CreatePost(string title)
        {
            return new CreatePostCommand(title);
        }

        public static void GoToNewPost()
        {
            var message = Driver.Instance.FindElement(By.Id("message"));
            var newPostLink = Driver.Instance.FindElement(By.XPath(".//*[@id='message']/p/a"));
            newPostLink.Click();
        }

        public static bool IsInEditMode()
        {
            var editMode = Driver.Instance.FindElement(By.XPath(".//*[@id='wpbody-content']/div[3]/h1"));
            return editMode.Text != null;
        }

        public static string Title
        {
            get { var title = Driver.Instance.FindElement(By.Id("title"));
                if (title != null)
                    return title.GetAttribute("value");
                return String.Empty;
            }
            
        }
    }

    public class CreatePostCommand
    {
        private readonly string title;
        private string body;

        public CreatePostCommand(string title)
        {
            this.title = title;

        }

        public CreatePostCommand WithBody(string body)
        {
            this.body = body;
            return this;
        }

        public void Publish()
        {
            Driver.Instance.FindElement(By.Id("title")).SendKeys(title);

            Driver.Instance.SwitchTo().Frame("content_ifr");
            Driver.Instance.SwitchTo().ActiveElement().SendKeys(body);
            Driver.Instance.SwitchTo().DefaultContent();

            Thread.Sleep(5000);
            //Driver.Wait(TimeSpan.FromSeconds(10));
           

            Driver.Instance.FindElement(By.Id("publish")).Click();
        }
    }
}
