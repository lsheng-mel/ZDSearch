using System;
using System.Collections.Generic;
using System.Linq;
using ZendeskSearch.Enums;
using ZendeskSearch.Model;
using ZendeskSearch.Print;

namespace ZendeskSearch.Search
{
    // this controls what input is required from user at each step
    public interface ISearchStepManager
    {
        public void InitSearch();
        public bool Proceed(string input);

        public SearchStep Step { get; }
        public SearchCriteria Criteria { get; }
    }
    
    public class SearchStepManager : ISearchStepManager
    {
        private readonly IUserInputPromptPrinter _userInputPromptPrinter;
        
        private readonly Dictionary<SearchStep, SearchStep> _flows = new Dictionary<SearchStep, SearchStep>
        {
            {SearchStep.EnterSearchSubject, SearchStep.EnterSearchTerm},
            {SearchStep.EnterSearchTerm, SearchStep.EnterSearchValue},
            {SearchStep.EnterSearchValue, SearchStep.ShowResults},
            {SearchStep.ShowResults, SearchStep.EnterSearchSubject},
        };

        public SearchStepManager(IUserInputPromptPrinter userInputPromptPrinter)
        {
            _userInputPromptPrinter = userInputPromptPrinter;
            InitSearchCriteria();
            InitSearch();
        }

        public void InitSearch()
        {
            Step = SearchStep.EnterSearchSubject;
        }

        private void InitSearchCriteria()
        {
            Criteria = new SearchCriteria();
        }

        public bool Proceed(string input)
        {
            try
            {
                switch (Step)
                {
                    case SearchStep.EnterSearchSubject:
                    {
                        var option = Convert.ToInt32(input);
                        Criteria.SearchSubject = option switch
                        {
                            (int) SearchSubject.SearchUser => typeof(User),
                            (int) SearchSubject.SearchTicket => typeof(Ticket),
                            (int) SearchSubject.SearchOrganization => typeof(Organization),
                            _ => throw new ApplicationException()
                        };
                        break;
                    }
                    case SearchStep.EnterSearchTerm:
                    {
                        var term = input.Trim();
                        if (!IsSearchTermValid(term))
                        {
                            throw new ApplicationException();
                        }
                        
                        Criteria.SearchTerm = term;
                        break;
                    }
                    case SearchStep.EnterSearchValue:
                    {
                        Criteria.SearchValue = input;
                        break;
                    }
                    case SearchStep.ShowResults:
                        break;
                    case SearchStep.Quit:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                // move onto next step
                Step = _flows[Step];

                return true;
            }
            catch (Exception)
            {
                PrintInvalidInputError();
            }

            return false;
        }

        private bool IsSearchTermValid(string input)
        {
            if (Criteria.SearchSubject == null) return false;

            return Criteria.SearchSubject.GetProperties()
                .Any(p => p.Name.Equals(input, StringComparison.InvariantCultureIgnoreCase));
        }

        protected virtual void PrintInvalidInputError()
        {
            _userInputPromptPrinter.PrintInvalidInputError();
        }

        public SearchStep Step { get; private set; }
        public SearchCriteria Criteria { get; private set; }
    }
}