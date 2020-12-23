using System.Linq;
using Xunit;
using ZendeskSearch.Model;
using ZendeskSearch.Search;

namespace ZendeskSearchUnitTest
{
    public class TestZendeskSearcherSearchTickets : UnitTestFixture
    {
        [Fact]
        public void Test_Search_Ticket_By_Id_Found_0()
        {
            var criteria = new SearchCriteria
            {
                SearchSubject = typeof(Ticket),
                SearchTerm = "_id",
                SearchValue = "dummy_id"
            };

            var searcher = GetService<IZendeskSearcher>();
            var tickets = searcher.Search(dataset, criteria);
            
            Assert.Empty(tickets);
        }
        
        [Fact]
        public void Test_Search_Ticket_By_Id_Found_1()
        {
            var criteria = new SearchCriteria
            {
                SearchSubject = typeof(Ticket),
                SearchTerm = "_id",
                SearchValue = "436bf9b0-1147-4c0a-8439-6f79833bff5b"
            };

            var searcher = GetService<IZendeskSearcher>();
            var tickets = searcher.Search(dataset, criteria);
            
            Assert.Single(tickets);
        }
        
        [Fact]
        public void Test_Search_Ticket_By_Name_Found_0()
        {
            var criteria = new SearchCriteria
            {
                SearchSubject = typeof(Ticket),
                SearchTerm = "subject",
                SearchValue = "dummy_ticket_subject"
            };

            var searcher = GetService<IZendeskSearcher>();
            var tickets = searcher.Search(dataset, criteria);
            
            Assert.Empty(tickets);
        }
        
        [Fact]
        public void Test_Search_Ticket_By_Name_Found_1()
        {
            var criteria = new SearchCriteria
            {
                SearchSubject = typeof(Ticket),
                SearchTerm = "subject",
                SearchValue = "A Catastrophe in Korea (North)"
            };

            var searcher = GetService<IZendeskSearcher>();
            var tickets = searcher.Search(dataset, criteria);
            
            Assert.Single(tickets);
        }
        
        [Fact]
        public void Test_Search_Ticket_By_OrganizationId_Found_9()
        {
            var criteria = new SearchCriteria
            {
                SearchSubject = typeof(Ticket),
                SearchTerm = "organization_id",
                SearchValue = "116"
            };

            var searcher = GetService<IZendeskSearcher>();
            var tickets = searcher.Search(dataset, criteria);
            
            Assert.Equal(9, tickets.Count());
        }
        
        [Fact]
        public void Test_Search_Ticket_By_HasNoIncidents_Found_101()
        {
            var criteria = new SearchCriteria
            {
                SearchSubject = typeof(Ticket),
                SearchTerm = "has_incidents",
                SearchValue = "false"
            };

            var searcher = GetService<IZendeskSearcher>();
            var tickets = searcher.Search(dataset, criteria);
            
            Assert.Equal(101, tickets.Count());
        }
        
        [Fact]
        public void Test_Search_Ticket_By_HasIncidents_Found_99()
        {
            var criteria = new SearchCriteria
            {
                SearchSubject = typeof(Ticket),
                SearchTerm = "has_incidents",
                SearchValue = "true"
            };

            var searcher = GetService<IZendeskSearcher>();
            var tickets = searcher.Search(dataset, criteria);
            
            Assert.Equal(99, tickets.Count());
        }
        
        [Fact]
        public void Test_Search_Ticket_By_Tag_Found_14()
        {
            var criteria = new SearchCriteria
            {
                SearchSubject = typeof(Ticket),
                SearchTerm = "tags",
                SearchValue = "Ohio"
            };

            var searcher = GetService<IZendeskSearcher>();
            var tickets = searcher.Search(dataset, criteria);
            
            Assert.Equal(14, tickets.Count());
        }
    }
}