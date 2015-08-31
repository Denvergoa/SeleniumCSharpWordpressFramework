using System;
using System.Text;

namespace WordpressAutomation.Workflows
{
    public class PostCreator
    {
        public static void CreatePost()
        {
            NewPostPage.GoTo();

            PreviousTitle = CreateTitle();
            PreviousBody = CreateBody();

            NewPostPage.CreatePost(PreviousTitle).WithBody(PreviousBody).Publish();
        }

        private static string CreateBody()
        {
            return CreateRandomString() + ", body";
        }

        private static string CreateRandomString()
        {
            var s = new StringBuilder();

            var random = new Random();
            var cycles = random.Next(5 + 1);

            for (int i = 0; i < cycles; i++)
            {
                s.Append(Words[random.Next(Words.Length)]);
                s.Append(" ");
                s.Append(Articles[random.Next(Articles.Length)]);
                s.Append(" ");
                s.Append(Words[random.Next(Words.Length)]);
                s.Append(" ");
            }
            return s.ToString();
        }

        private static string [] Words = new[]
        {
            "boy",
            "cat",
            "dog",
            "rabbit",
            "baseball",
            "throw",
            "find",
            "scary",
            "mustard"
        };

        private static string[] Articles = new[]
        {
            "the",
            "an",
            "a",
            "and",
            "of",
            "to",
            "it",
            "as",
            "off"
        };


        private static string CreateTitle()
        {
            return CreateRandomString() + ", title";
        }

        public static string PreviousBody { get; set;  }

        public static string PreviousTitle { get; set; }

        public static void Initialize()
        {
            PreviousTitle = null;
            PreviousBody = null;
        }

        public static void Cleanup()
        {
            if (CreatedPost)
            {
                TrashPost();
            }
        }

        private static void TrashPost()
        {
            ListsPostPage.TrashPost(PreviousTitle);
            Initialize();
        }

        protected static bool CreatedPost
        {
            get { return !String.IsNullOrEmpty(PreviousTitle); }
            
        }
    }

        
}
