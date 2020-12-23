using System.Collections.Generic;
using ZendeskSearch.Model;
using ZendeskSearch.Print;

namespace ZendeskSearch.SearchResult
{
    // organization record with related users & tickets information
    public class OrganizationView : Organization, IPrintable
    {
        public IEnumerable<string> users { get; set; }
        public IEnumerable<string> tickets { get; set; }

        public override void Print()
        {
            SearchResultPrinter.Print(this);
        }
    }
}