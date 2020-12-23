using System;
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

        private Dictionary<string, string> DataFiles = new Dictionary<string, string>
        {
            {  nameof(User), "users.json" },
            {  nameof(Ticket), "tickets.json" },
            {  nameof(Organization), "organizations.json" }
        };
        
        public Zendesk Load()
        {
            var dataset = new Zendesk();
            dataset.Data.Add(nameof(User), Load<User>());
            dataset.Data.Add(nameof(Ticket), Load<Ticket>());
            dataset.Data.Add(nameof(Organization), Load<Organization>());
            return dataset;
        }

        private List<T> Load<T>()
        {
            try
            {
                var file = DataFiles[typeof(T).Name];
                var usersJsonString = File.ReadAllText($"{FilePath}/{file}");
                var items = JsonConvert.DeserializeObject<List<T>>(usersJsonString);

                return items;
            }
            catch(Exception e)
            {
                return new List<T>();
            }
        }
    }
}