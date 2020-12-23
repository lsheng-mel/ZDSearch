using System.Linq;
using Xunit;
using ZendeskSearch;
using ZendeskSearch.Model;

namespace ZendeskSearchUnitTest
{
    public class TestDataLoader : UnitTestFixture
    {
        [Fact]
        public void Test_Load_Data()
        {
            var loader = GetService<IDataLoader>();
            var dataset = loader.Load();
            
            Assert.Equal(75, dataset.Data[nameof(User)].Count());
            Assert.Equal(200, dataset.Data[nameof(Ticket)].Count());
            Assert.Equal(25, dataset.Data[nameof(Organization)].Count());
        }
    }
}