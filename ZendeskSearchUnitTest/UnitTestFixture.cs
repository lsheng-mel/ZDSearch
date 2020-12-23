using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ZendeskSearch;
using ZendeskSearch.Model;
using ZendeskSearch.Print;
using ZendeskSearch.Search;
using ZendeskSearchUnitTest.TestUnits;

namespace ZendeskSearchUnitTest
{
    public class UnitTestFixture
    {
        protected readonly Zendesk dataset;
        
        protected UnitTestFixture()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            serviceCollection.AddSingleton<IDataLoader, DataLoader>();
            serviceCollection.AddSingleton<IZendeskSearcher, ZendeskSearcher>();
            serviceCollection.AddSingleton<ISearchStepManager, SearchStepManagerForTest>();
            serviceCollection.AddSingleton<ISearchableFieldsPrinter, SearchableFieldsPrinter>();
            serviceCollection.AddSingleton<ISearchController, SearchController>();
            serviceCollection.AddSingleton<IUserInputPromptPrinter, UserInputPromptPrinter>();

            ServiceProvider = serviceCollection.BuildServiceProvider();
            
            dataset = GetService<IDataLoader>().Load();
        }

        protected IServiceProvider ServiceProvider { get; private set; }

        protected T GetService<T>()
        {
            return (T) ServiceProvider.GetService(typeof(T));
        }
    }
}