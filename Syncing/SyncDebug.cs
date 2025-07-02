using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperSample.Syncing
{
    public class SyncDebug
    {
        public List<string> InitializeList(IEnumerable<string> items)
        {
            var bag = new ConcurrentBag<string>();
            
            // Avoid async in Parallel.ForEach
            Parallel.ForEach(items, i =>
            {
                // No async/await � just add each item directly
                bag.Add(i);
            });
            var list = bag.ToList();
            return list;
        }

        public Dictionary<int, string> InitializeDictionary(Func<int, string> getItem)
        {
            var itemsToInitialize = Enumerable.Range(0, 100);

            var concurrentDictionary = new ConcurrentDictionary<int, Lazy<string>>();

            // Use multiple threads to fill the dictionary
            Parallel.ForEach(itemsToInitialize, item =>
            {
                // Get or add a Lazy<string> for this key. Only one Lazy.Value runs getItem().
                var lazy = concurrentDictionary.GetOrAdd(item,
                    key => new Lazy<string>(() => getItem(key), LazyThreadSafetyMode.ExecutionAndPublication));

                // Force initialization of the value
                _ = lazy.Value;
            });

            // Convert to a regular Dictionary<int,string> by extracting Lazy.Value
            return concurrentDictionary.ToDictionary(kv => kv.Key, kv => kv.Value.Value);
        }
    }
}