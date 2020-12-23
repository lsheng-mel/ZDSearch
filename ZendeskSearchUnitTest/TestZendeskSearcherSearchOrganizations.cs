using System.Linq;
using Xunit;
using ZendeskSearch.Model;
using ZendeskSearch.Search;

namespace ZendeskSearchUnitTest
{
    public class TestZendeskSearcherSearchOrganizations : UnitTestFixture
    {
        [Fact]
        public void Test_Search_Organization_By_Id_Found_0()
        {
            var criteria = new SearchCriteria
            {
                SearchSubject = typeof(Organization),
                SearchTerm = "_id",
                SearchValue = "1"
            };

            var searcher = GetService<IZendeskSearcher>();
            var organizations = searcher.Search(dataset, criteria);
            
            Assert.Empty(organizations);
        }
        
        [Fact]
        public void Test_Search_Organization_By_Id_Found_1()
        {
            var criteria = new SearchCriteria
            {
                SearchSubject = typeof(Organization),
                SearchTerm = "_id",
                SearchValue = "101"
            };

            var searcher = GetService<IZendeskSearcher>();
            var organizations = searcher.Search(dataset, criteria);
            
            Assert.Single(organizations);
        }
        
        [Fact]
        public void Test_Search_Organization_By_Name_Found_0()
        {
            var criteria = new SearchCriteria
            {
                SearchSubject = typeof(Organization),
                SearchTerm = "name",
                SearchValue = "dummy_Organization_name"
            };

            var searcher = GetService<IZendeskSearcher>();
            var organizations = searcher.Search(dataset, criteria);
            
            Assert.Empty(organizations);
        }
        
        [Fact]
        public void Test_Search_Organization_By_Name_Found_1()
        {
            var criteria = new SearchCriteria
            {
                SearchSubject = typeof(Organization),
                SearchTerm = "name",
                SearchValue = "Enthaze"
            };

            var searcher = GetService<IZendeskSearcher>();
            var organizations = searcher.Search(dataset, criteria);
            
            Assert.Single(organizations);
        }

        [Fact]
        public void Test_Search_Organization_By_NoSharedTickets_Found_15()
        {
            var criteria = new SearchCriteria
            {
                SearchSubject = typeof(Organization),
                SearchTerm = "shared_tickets",
                SearchValue = "false"
            };

            var searcher = GetService<IZendeskSearcher>();
            var organizations = searcher.Search(dataset, criteria);
            
            Assert.Equal(15, organizations.Count());
        }
        
        [Fact]
        public void Test_Search_Organization_By_SharedTickets_Found_10()
        {
            var criteria = new SearchCriteria
            {
                SearchSubject = typeof(Organization),
                SearchTerm = "shared_tickets",
                SearchValue = "true"
            };

            var searcher = GetService<IZendeskSearcher>();
            var organizations = searcher.Search(dataset, criteria);
            
            Assert.Equal(10, organizations.Count());
        }
        
        [Fact]
        public void Test_Search_Organization_By_DomainNames_Found_1()
        {
            var criteria = new SearchCriteria
            {
                SearchSubject = typeof(Organization),
                SearchTerm = "domain_names",
                SearchValue = "kage.com"
            };

            var searcher = GetService<IZendeskSearcher>();
            var organizations = searcher.Search(dataset, criteria);

            Assert.Single(organizations);
        }
        
        [Fact]
        public void Test_Search_Organization_By_Details_Found_9()
        {
            var criteria = new SearchCriteria
            {
                SearchSubject = typeof(Organization),
                SearchTerm = "details",
                SearchValue = "MegaCorp"
            };

            var searcher = GetService<IZendeskSearcher>();
            var organizations = searcher.Search(dataset, criteria);

            Assert.Equal(9, organizations.Count());
        }

        [Fact]
        public void Test_Search_Organization_By_Tag_Found_1()
        {
            var criteria = new SearchCriteria
            {
                SearchSubject = typeof(Organization),
                SearchTerm = "tags",
                SearchValue = "Fulton"
            };

            var searcher = GetService<IZendeskSearcher>();
            var organizations = searcher.Search(dataset, criteria);

            Assert.Single(organizations);
        }
    }
}