using System.Linq;
using Xunit;
using ZendeskSearch.Model;
using ZendeskSearch.Search;

namespace ZendeskSearchUnitTest
{
    public class TestZendeskSearcherSearchUsers : UnitTestFixture
    {
        [Fact]
        public void Test_Search_User_By_Id_Found_0()
        {
            var criteria = new SearchCriteria
            {
                SearchSubject = typeof(User),
                SearchTerm = "_id",
                SearchValue = "76"
            };

            var searcher = GetService<IZendeskSearcher>();
            var users = searcher.Search(dataset, criteria);
            
            Assert.Empty(users);
        }
        
        [Fact]
        public void Test_Search_User_By_Id_Found_1()
        {
            var criteria = new SearchCriteria
            {
                SearchSubject = typeof(User),
                SearchTerm = "_id",
                SearchValue = "1"
            };

            var searcher = GetService<IZendeskSearcher>();
            var users = searcher.Search(dataset, criteria);
            
            Assert.Single(users);
        }
        
        [Fact]
        public void Test_Search_User_By_Name_Found_0()
        {
            var criteria = new SearchCriteria
            {
                SearchSubject = typeof(User),
                SearchTerm = "name",
                SearchValue = "Jack Ryan"
            };

            var searcher = GetService<IZendeskSearcher>();
            var users = searcher.Search(dataset, criteria);
            
            Assert.Empty(users);
        }
        
        [Fact]
        public void Test_Search_User_By_Name_Found_1()
        {
            var criteria = new SearchCriteria
            {
                SearchSubject = typeof(User),
                SearchTerm = "name",
                SearchValue = "Francisca Rasmussen"
            };

            var searcher = GetService<IZendeskSearcher>();
            var users = searcher.Search(dataset, criteria);
            
            Assert.Single(users);
        }
        
        [Fact]
        public void Test_Search_User_By_OrganizationId_Found_4()
        {
            var criteria = new SearchCriteria
            {
                SearchSubject = typeof(User),
                SearchTerm = "organization_id",
                SearchValue = "119"
            };

            var searcher = GetService<IZendeskSearcher>();
            var users = searcher.Search(dataset, criteria);
            
            Assert.Equal(4, users.Count());
        }
        
        [Fact]
        public void Test_Search_User_By_Suspended_Found_36()
        {
            var criteria = new SearchCriteria
            {
                SearchSubject = typeof(User),
                SearchTerm = "suspended",
                SearchValue = "true"
            };

            var searcher = GetService<IZendeskSearcher>();
            var users = searcher.Search(dataset, criteria);
            
            Assert.Equal(36, users.Count());
        }
        
        [Fact]
        public void Test_Search_User_By_Tag_Found_1()
        {
            var criteria = new SearchCriteria
            {
                SearchSubject = typeof(User),
                SearchTerm = "tags",
                SearchValue = "Veguita"
            };

            var searcher = GetService<IZendeskSearcher>();
            var users = searcher.Search(dataset, criteria);
            
            Assert.Single(users);
        }
    }
}