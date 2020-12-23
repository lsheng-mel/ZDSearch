using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ZendeskSearch.Model;
using ZendeskSearch.Print;
using ZendeskSearch.SearchResult;

namespace ZendeskSearch.Search
{
    // given the whole dataset and search criteria, returns the list of search results
    public interface IZendeskSearcher
    {
        IEnumerable<IPrintable> Search(Zendesk dataset, SearchCriteria criteria);
    }
    
    public class ZendeskSearcher : IZendeskSearcher
    {
        private readonly IMapper _mapper;

        public ZendeskSearcher(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<IPrintable> Search(Zendesk dataset, SearchCriteria criteria)
        {
            var data = dataset.Data[criteria.SearchSubject.Name];
            var items = data.Where(d => d.IsMatched(criteria.SearchSubject, criteria.SearchTerm, criteria.SearchValue));
            
            var result = GetSearchResults(items, dataset);
            return result;
        }
        
        // convert matched entities to view model (including related entity information)
        private IEnumerable<IPrintable> GetSearchResults(IEnumerable<Searchable> items, Zendesk dataset)
        {
            var result = items.ToList();
            if (result.FirstOrDefault()?.GetType() == typeof(User))
            {
                return _mapper.Map<IEnumerable<UserView>>(items,
                    opt => opt.Items["dataset"] = dataset);
            }

            if (result.FirstOrDefault()?.GetType() == typeof(Ticket))
            {
                return _mapper.Map<IEnumerable<TicketView>>(items,
                    opt => opt.Items["dataset"] = dataset);
            }

            if (result.FirstOrDefault()?.GetType() == typeof(Organization))
            {
                return _mapper.Map<IEnumerable<OrganizationView>>(items,
                    opt => opt.Items["dataset"] = dataset);
            }

            return new List<IPrintable>();
        }
    }
}