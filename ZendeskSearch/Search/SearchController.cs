using System;
using System.Collections.Generic;
using ZendeskSearch.Enums;
using ZendeskSearch.Extensions;
using ZendeskSearch.Model;
using ZendeskSearch.Print;

namespace ZendeskSearch.Search
{
    // this is the controller that controls the whole work flow
    public interface ISearchController
    {
        void Search(Zendesk dataset);
    }
    
    public class SearchController : ISearchController
    {
        private readonly ISearchStepManager _searchStepManager;
        private readonly IUserInputPromptPrinter _userInputPromptPrinter;
        private readonly ISearchableFieldsPrinter _searchableFieldsPrinter;
        private readonly IZendeskSearcher _searcher;
        private string _input;
        
        private readonly Dictionary<SearchStep, SearchStep> _flows = new Dictionary<SearchStep, SearchStep>
        {
            {SearchStep.EnterSearchSubject, SearchStep.EnterSearchTerm},
            {SearchStep.EnterSearchTerm, SearchStep.EnterSearchValue},
            {SearchStep.EnterSearchValue, SearchStep.ShowResults},
            {SearchStep.ShowResults, SearchStep.EnterSearchSubject},
        };
        
        public SearchController(IUserInputPromptPrinter userInputPromptPrinter, ISearchStepManager searchStepManager, ISearchableFieldsPrinter searchableFieldsPrinter, IZendeskSearcher searcher)
        {
            _userInputPromptPrinter = userInputPromptPrinter;
            _searchStepManager = searchStepManager;
            _searchableFieldsPrinter = searchableFieldsPrinter;
            _searcher = searcher;
            _input = string.Empty;
        }

        public void Search(Zendesk dataset)
        {
            if (!SelectOption())
            {
                return;
            }
            
            while (true)
            {
                PromptUserInput();

                if (Exit())
                {
                    _userInputPromptPrinter.Print("Goodbye.");
                    break;
                }
                
                Proceed();
                SearchAndOutput(dataset);
            }
        }

        // select search option 1) search 2) view search fields 3) quit
        private bool SelectOption()
        {
            while (true)
            {
                try
                {
                    PromptUserInput(false);
                    if (Exit())
                    {
                        _userInputPromptPrinter.Print("Goodbye.");
                        return false;
                    }

                    var option = Convert.ToInt32(_input);
                    switch (option)
                    {
                        case 1:
                            return true;
                        case 2:
                            _searchableFieldsPrinter.Print();
                            break;
                        default:
                            _userInputPromptPrinter.PrintInvalidInputError();
                            break;
                    }
                }
                catch (Exception)
                {
                    _userInputPromptPrinter.PrintInvalidInputError();
                }
            }
        }

        // proceed to the next step of the search flow after user input
        private void Proceed()
        {
            _searchStepManager.Proceed(_input);
        }
        
        // search data based on user input search criteria & print search result
        private void SearchAndOutput(Zendesk dataset)
        {
            if (_searchStepManager.Step != SearchStep.ShowResults)
            {
                return;
            }

            var result = _searcher.Search(dataset, _searchStepManager.Criteria);
            SearchResultPrinter.Print(result);
                
            // re-start search flow
            _searchStepManager.InitSearch();
        }

        // prompt user to input
        private void PromptUserInput(bool printPrompt = true)
        {
            if (printPrompt)
            {
                _userInputPromptPrinter.Print(_searchStepManager.Step.GetDescription());
            }
            
            _input = Console.ReadLine();
        }

        private bool Exit()
        {
            return (_input ?? string.Empty).ToLower().Contains("quit");
        }
    }
}