using Microsoft.Extensions.DependencyInjection;
using ZendeskSearch.Search;

namespace ZendeskSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            // register everything needed for start up the program
            var startup = new Startup();
            
            var userManual = startup.Provider.GetRequiredService<IUserManual>();
            var dataLoader = startup.Provider.GetRequiredService<IDataLoader>();
            var searchController = startup.Provider.GetRequiredService<ISearchController>();
            
            // run search program
            var dataset = dataLoader.Load();
            userManual.Show();
            searchController.Search(dataset);
        }
    }
}