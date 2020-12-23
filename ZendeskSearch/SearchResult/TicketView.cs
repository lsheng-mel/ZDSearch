using System;
using ZendeskSearch.Model;
using ZendeskSearch.Print;

namespace ZendeskSearch.SearchResult
{
    // ticket record with related users & organization information
    public class TicketView : Ticket, IPrintable
    {
        public string submitter { get; set; }
        public string assignee { get; set; }
        public string organization_name { get; set; }
        
        public override void Print()
        {
            SearchResultPrinter.Print(this);
        }
    }
}