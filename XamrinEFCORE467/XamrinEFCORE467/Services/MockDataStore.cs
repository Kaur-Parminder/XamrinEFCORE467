using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Threading.Tasks;
using XamrinEFCORE467.Models;

namespace XamrinEFCORE467.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            try
            {
               
                HttpClient client = new HttpClient();
                //10.0.2.2 is an IP address used by emulator to connect to web server 
                HttpResponseMessage response = client.GetAsync("http://10.0.2.2:28370/Northwind").Result;               
               
                items = new List<Item>() { new Item { Id = Guid.NewGuid().ToString(), Text = response.Content.ReadAsStringAsync().Result, Description = "This data is fetched from Northwind database." } };
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured" + e.Message);

            }

         }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}