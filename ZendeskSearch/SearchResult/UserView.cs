using System.Collections.Generic;
using ZendeskSearch.Model;
using ZendeskSearch.Print;

namespace ZendeskSearch.SearchResult
{
    // user record with related tickets & organization information
    public class UserView : User, IPrintable
    {
        public string organization_name { get; set; }
        public List<string> submitted_tickets { get; set; }
        
        public void Print()
        {
            SearchResultPrinter.Print(this);
        }
    }
}