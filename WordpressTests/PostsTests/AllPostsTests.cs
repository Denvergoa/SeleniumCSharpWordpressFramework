using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;
using WordpressAutomation.Workflows;

namespace WordpressTests.PostsTests
{
    [TestClass]
    public class AllPostsTests : WordpressTest
    {
        [TestMethod]
        public void Added_Posts_Show_Up()
        {
            //Go to posts, get post count, store
            ListsPostPage.GoTo(PostType.Posts);
            ListsPostPage.StoreCount();
            
            //Add a new post
            PostCreator.CreatePost();
 
            //Go to posts, get a new post count
            ListsPostPage.GoTo(PostType.Posts);
            Assert.AreEqual(ListsPostPage.PreviousPostCount + 1,ListsPostPage.CurrentPostCount, "Count of posts did not increase" );

            //Check for added post
            Assert.IsTrue(ListsPostPage.DoesPostExistWithTitle(PostCreator.PreviousTitle));
            
            //Trash post(clean up)
            ListsPostPage.TrashPost(PostCreator.PreviousTitle);
            Assert.AreEqual(ListsPostPage.PreviousPostCount, ListsPostPage.CurrentPostCount, "Could not trash post");
        }

        [TestMethod]
        public void Can_Search_Posts()
        {
            //Create a new post
            PostCreator.CreatePost();
         
            //Search for post
            ListsPostPage.SearchForPost(PostCreator.PreviousTitle);

            //Check that post show up in results
            Assert.IsTrue(ListsPostPage.DoesPostExistWithTitle(PostCreator.PreviousTitle));

            //Clean up(Trash post)
            ListsPostPage.TrashPost(PostCreator.PreviousTitle);
        }
    }
}


// Can activate excerpt mode


// Single post selections

// Can select a post by title
// Can select a post by Edit
// Can select a post by QuickEdit
// Can trash a post
// Can view a post
// Can filter by author
// Can filter by category
// Can filter by tag
// Can go to post comments

// Bulk actions

// Can edit multiple posts
// Can trash multiple posts
// Can select all posts

// Drop down filters

// Can filter by month
// Can filter by category
// Can view published only
// Can view drafts only
// Can view trash only

// Can search posts