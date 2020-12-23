using Xunit;
using ZendeskSearch.Enums;
using ZendeskSearch.Search;

namespace ZendeskSearchUnitTest
{
    public class TestSearchStepManager : UnitTestFixture
    {
        [Fact]
        public void Test_Invalid_SearchSubject()
        {
            var stepManager = GetService<ISearchStepManager>();
            
            Assert.False(stepManager.Proceed("0"));
            Assert.Equal(SearchStep.EnterSearchSubject, stepManager.Step);
            
            Assert.False(stepManager.Proceed("invalid_option"));
            Assert.Equal(SearchStep.EnterSearchSubject, stepManager.Step);
        }
        
        [Fact]
        public void Test_Valid_SearchSubject()
        {
            var stepManager = GetService<ISearchStepManager>();
            
            Assert.True(stepManager.Proceed("1"));
            Assert.Equal(SearchStep.EnterSearchTerm, stepManager.Step);
            
            stepManager.InitSearch();
            Assert.True(stepManager.Proceed("2"));
            Assert.Equal(SearchStep.EnterSearchTerm, stepManager.Step);

            stepManager.InitSearch();
            Assert.True(stepManager.Proceed("3"));
            Assert.Equal(SearchStep.EnterSearchTerm, stepManager.Step);
        }
        
        [Fact]
        public void Test_Invalid_SearchTerm()
        {
            var stepManager = GetService<ISearchStepManager>();
            
            // search user
            stepManager.Proceed("1");
            Assert.False(stepManager.Proceed("id"));
            Assert.Equal(SearchStep.EnterSearchTerm, stepManager.Step);
            Assert.False(stepManager.Proceed("family_name"));
            Assert.Equal(SearchStep.EnterSearchTerm, stepManager.Step);
            
            // search ticket
            stepManager.InitSearch();
            stepManager.Proceed("2");
            Assert.False(stepManager.Proceed("id"));
            Assert.Equal(SearchStep.EnterSearchTerm, stepManager.Step);
            Assert.False(stepManager.Proceed("topic"));
            Assert.Equal(SearchStep.EnterSearchTerm, stepManager.Step);
            
            // search organization
            stepManager.InitSearch();
            stepManager.Proceed("3");
            Assert.False(stepManager.Proceed("id"));
            Assert.Equal(SearchStep.EnterSearchTerm, stepManager.Step);
            Assert.False(stepManager.Proceed("organization_name"));
            Assert.Equal(SearchStep.EnterSearchTerm, stepManager.Step);
        }
        
        [Fact]
        public void Test_Search_User_Valid_SearchTerm()
        {
            var stepManager = GetService<ISearchStepManager>();
            
            // by _id
            stepManager.Proceed("1");
            Assert.True(stepManager.Proceed("_id"));
            Assert.Equal(SearchStep.EnterSearchValue, stepManager.Step);
            
            // by name
            stepManager.InitSearch();
            stepManager.Proceed("1");
            Assert.True(stepManager.Proceed("name"));
            Assert.Equal(SearchStep.EnterSearchValue, stepManager.Step);
            
            // by alias
            stepManager.InitSearch();
            stepManager.Proceed("1");
            Assert.True(stepManager.Proceed("alias"));
            Assert.Equal(SearchStep.EnterSearchValue, stepManager.Step);
            
            // by email
            stepManager.InitSearch();
            stepManager.Proceed("1");
            Assert.True(stepManager.Proceed("email"));
            Assert.Equal(SearchStep.EnterSearchValue, stepManager.Step);
            
            // by tags
            stepManager.InitSearch();
            stepManager.Proceed("1");
            Assert.True(stepManager.Proceed("tags"));
            Assert.Equal(SearchStep.EnterSearchValue, stepManager.Step);
        }
        
        [Fact]
        public void Test_Search_Ticket_Valid_SearchTerm()
        {
            var stepManager = GetService<ISearchStepManager>();
            
            // by _id
            stepManager.Proceed("2");
            Assert.True(stepManager.Proceed("_id"));
            Assert.Equal(SearchStep.EnterSearchValue, stepManager.Step);
            
            // by url
            stepManager.InitSearch();
            stepManager.Proceed("2");
            Assert.True(stepManager.Proceed("url"));
            Assert.Equal(SearchStep.EnterSearchValue, stepManager.Step);
            
            // by external_id
            stepManager.InitSearch();
            stepManager.Proceed("2");
            Assert.True(stepManager.Proceed("external_id"));
            Assert.Equal(SearchStep.EnterSearchValue, stepManager.Step);
            
            // by subject
            stepManager.InitSearch();
            stepManager.Proceed("2");
            Assert.True(stepManager.Proceed("subject"));
            Assert.Equal(SearchStep.EnterSearchValue, stepManager.Step);
            
            // by description
            stepManager.InitSearch();
            stepManager.Proceed("2");
            Assert.True(stepManager.Proceed("description"));
            Assert.Equal(SearchStep.EnterSearchValue, stepManager.Step);
            
            // by tags
            stepManager.InitSearch();
            stepManager.Proceed("2");
            Assert.True(stepManager.Proceed("tags"));
            Assert.Equal(SearchStep.EnterSearchValue, stepManager.Step);
            
            // by has_incidents
            stepManager.InitSearch();
            stepManager.Proceed("2");
            Assert.True(stepManager.Proceed("has_incidents"));
            Assert.Equal(SearchStep.EnterSearchValue, stepManager.Step);
            
            // by via
            stepManager.InitSearch();
            stepManager.Proceed("2");
            Assert.True(stepManager.Proceed("via"));
            Assert.Equal(SearchStep.EnterSearchValue, stepManager.Step);
        }
        
        [Fact]
        public void Test_Search_Organization_Valid_SearchTerm()
        {
            var stepManager = GetService<ISearchStepManager>();
            
            // by _id
            stepManager.Proceed("3");
            Assert.True(stepManager.Proceed("_id"));
            Assert.Equal(SearchStep.EnterSearchValue, stepManager.Step);
            
            // by url
            stepManager.InitSearch();
            stepManager.Proceed("3");
            Assert.True(stepManager.Proceed("url"));
            Assert.Equal(SearchStep.EnterSearchValue, stepManager.Step);
            
            // by external_id
            stepManager.InitSearch();
            stepManager.Proceed("3");
            Assert.True(stepManager.Proceed("external_id"));
            Assert.Equal(SearchStep.EnterSearchValue, stepManager.Step);
            
            // by name
            stepManager.InitSearch();
            stepManager.Proceed("3");
            Assert.True(stepManager.Proceed("name"));
            Assert.Equal(SearchStep.EnterSearchValue, stepManager.Step);
            
            // by domain_names
            stepManager.InitSearch();
            stepManager.Proceed("3");
            Assert.True(stepManager.Proceed("domain_names"));
            Assert.Equal(SearchStep.EnterSearchValue, stepManager.Step);
            
            // by created_at
            stepManager.InitSearch();
            stepManager.Proceed("3");
            Assert.True(stepManager.Proceed("created_at"));
            Assert.Equal(SearchStep.EnterSearchValue, stepManager.Step);
            
            // by details
            stepManager.InitSearch();
            stepManager.Proceed("3");
            Assert.True(stepManager.Proceed("details"));
            Assert.Equal(SearchStep.EnterSearchValue, stepManager.Step);
            
            // by shared_tickets
            stepManager.InitSearch();
            stepManager.Proceed("3");
            Assert.True(stepManager.Proceed("shared_tickets"));
            Assert.Equal(SearchStep.EnterSearchValue, stepManager.Step);
            
            // by tags
            stepManager.InitSearch();
            stepManager.Proceed("3");
            Assert.True(stepManager.Proceed("tags"));
            Assert.Equal(SearchStep.EnterSearchValue, stepManager.Step);
        }
    }
}