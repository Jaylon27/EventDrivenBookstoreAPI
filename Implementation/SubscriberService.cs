using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Linq;
using EventDrivenBookstoreAPI.Interface;
using EventDrivenBookstoreAPI.Models;

namespace EventDrivenBookstoreAPI.Implementation
{
    // Implementation of the ISubscriberService interface
    public class SubscriberService : ISubscriberService
    {
        private readonly Container _subscriberContainer; // Cosmos DB container for subscribers

        // Constructor to initialize Cosmos DB container
        public SubscriberService(CosmosClient cosmosClient, IConfiguration configuration)
        {
            var databaseName = configuration["CosmosDb:DatabaseName"];
            var containerName = "Subscribers";
            _subscriberContainer = cosmosClient.GetContainer(databaseName, containerName);
        }

        // Asynchronous method to retrieve a subscriber by their ID
        public async Task<Subscriber> GetSubscriberByIdAsync(string subscriberId)
        {
            // Query to find the subscriber by ID
            var query = _subscriberContainer.GetItemLinqQueryable<Subscriber>()
                .Where(u => u.Id == subscriberId)
                .Take(1)
                .ToFeedIterator();

            // Execute the query and return the first result or null
            var response = await query.ReadNextAsync();
            return response.FirstOrDefault();
        }

        // Asynchronous method to create a new subscriber
        public async Task<Subscriber> CreateSubscriberAsync(Subscriber subscriber)
        {
            // Assign a new GUID to the subscriber's ID
            subscriber.Id = Guid.NewGuid().ToString();
            
            // Create the subscriber document in the Cosmos DB container
            var response = await _subscriberContainer.CreateItemAsync(subscriber, new PartitionKey(subscriber.Email));
            return response.Resource;
        }
    }
}
