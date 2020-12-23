using System.ComponentModel;

namespace ZendeskSearch.Enums
{
    public enum SearchStep
    {
        [Description("Select 1) Users or 2) Tickets or 3) Organizations")]
        EnterSearchSubject,
        
        [Description("Enter search term")]
        EnterSearchTerm,
        
        [Description("Enter search value")]
        EnterSearchValue,
        
        ShowResults,
        
        Quit
    }
}