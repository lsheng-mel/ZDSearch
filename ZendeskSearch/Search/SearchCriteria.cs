using System;

namespace ZendeskSearch.Search
{
    // this is the capture of the user input that is used for search within the dataset
    public class SearchCriteria
    {
        public Type SearchSubject { get; set; }
        public string SearchTerm { get; set; }
        public string SearchValue { get; set; }
    }
}