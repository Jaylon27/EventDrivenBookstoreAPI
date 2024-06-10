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
    // Implementation of the IBookService interface
    public class BookService : IBookService
    {
        private readonly Container _bookContainer; // Cosmos DB container for books

        // Constructor to initialize Cosmos DB container
        public BookService(CosmosClient cosmosClient, IConfiguration configuration)
        {
            var databaseName = configuration["CosmosDb:DatabaseName"];
            var containerName = configuration["CosmosDb:ContainerName"];
            _bookContainer = cosmosClient.GetContainer(databaseName, containerName);
        }

        // Asynchronous method to retrieve a book by its ID
        public async Task<Book> GetBookByIdAsync(string bookId)
        {
            // Query to find the book by ID
            var query = _bookContainer.GetItemLinqQueryable<Book>()
                .Where(t => t.Id == bookId)
                .Take(1)
                .ToQueryDefinition();

            // Execute the query and return the first result or null
            var response = await _bookContainer.GetItemQueryIterator<Book>(query).ReadNextAsync();
            return response.FirstOrDefault();
        }

        // Asynchronous method to create a new book
        public async Task<Book> CreateBookAsync(Book book)
        {
            // Assign a new GUID to the book's ID
            book.Id = Guid.NewGuid().ToString();

            // Create the book item in the Cosmos DB container
            var response = await _bookContainer.CreateItemAsync(book, new PartitionKey(book.Genre));
            return response.Resource;
        }
    }
}
