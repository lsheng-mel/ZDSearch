using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ZendeskSearch.Model;

namespace ZendeskSearch
{
    public interface IDataLoader
    {
        Zendesk Load();
    }
    
    public class DataLoader : IDataLoader
    {
        private const string FilePath = "Datastore";
        private const string UsersFile = "users.json";
        private const string OrganizationsFile = "organizations.json";
        private const string TicketsFile = "tickets.json";
        
        public Zendesk Load()
        {
            var usersJsonString = File.ReadAllText($"{FilePath}/{UsersFile}");
            var organizationsJsonString = File.ReadAllText($"{FilePath}/{OrganizationsFile}");
            var ticketsJsonString = File.ReadAllText($"{FilePath}/{TicketsFile}");

            var users = JsonConvert.DeserializeObject<List<User>>(usersJsonString);
            var organizations = JsonConvert.DeserializeObject<List<Organization>>(organizationsJsonString);
            var tickets = JsonConvert.DeserializeObject<List<Ticket>>(ticketsJsonString);

            var dataset = new Zendesk();
            dataset.Data.Add(nameof(User), users);
            dataset.Data.Add(nameof(Organization), organizations);
            dataset.Data.Add(nameof(Ticket), tickets);
            return dataset;
        }
    }
}