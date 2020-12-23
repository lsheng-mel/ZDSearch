using System.Collections.Generic;

namespace ZendeskSearch.Model
{
    public class Zendesk
    {
        // subject type <-> all object instances of the same subject type
        public Dictionary<string, IEnumerable<Searchable>> Data { get; set; }
        
        public Zendesk()
        {
            Data = new Dictionary<string, IEnumerable<Searchable>>();
        }
    }
}