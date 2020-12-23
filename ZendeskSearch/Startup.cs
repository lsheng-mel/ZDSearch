using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ZendeskSearch.Print;
using ZendeskSearch.Search;

namespace ZendeskSearch
{
    public class Startup
    {
        private readonly ServiceProvider _serviceProvider;
        
        public Startup()
        {
            var services = new ServiceCollection();

            // register services
            services.AddSingleton<IUserManual, UserManual>();
            services.AddSingleton<IDataLoader, DataLoader>();
            services.AddSingleton<IZendeskSearcher, ZendeskSearcher>();
            services.AddSingleton<ISearchStepManager, SearchStepManager>();
            services.AddSingleton<ISearchableFieldsPrinter, SearchableFieldsPrinter>();
            services.AddSingleton<ISearchController, SearchController>();
            services.AddSingleton<IUserInputPromptPrinter, UserInputPromptPrinter>();

            services.AddAutoMapper(new[] {typeof(Program).Assembly});
            
            // build the pipeline
            _serviceProvider = services.BuildServiceProvider();
        }
        
        public IServiceProvider Provider => _serviceProvider;
    }
}