using Microsoft.Azure.Cosmos;
using SupportWebApp.Models;

namespace SupportWebApp.Services;

public class CosmosDbService
{
    private readonly Container _container;

    public CosmosDbService(IConfiguration configuration)
    {
        var connectionString = configuration["CosmosDb:ConnectionString"];
        var databaseName = configuration["CosmosDb:DatabaseName"];
        var containerName = configuration["CosmosDb:ContainerName"];

        var client = new CosmosClient(connectionString);
        var database = client.GetDatabase(databaseName);
        _container = database.GetContainer(containerName);
    }

    public async Task AddSupportMessageAsync(SupportMessage message)
    {
        var document = new
        {
            id = message.Id,
            category = message.Category,
            customer = new
            {
                name = message.Customer.Name,
                email = message.Customer.Email,
                phone = message.Customer.Phone
            },
            description = message.Description,
            createdAt = message.CreatedAt,
            status = message.Status
        };

        await _container.CreateItemAsync(
            document,
            new PartitionKey(message.Category));
    }
    
    public async Task<List<SupportMessage>> GetSupportMessagesAsync()
    {
        var query = _container.GetItemQueryIterator<SupportMessage>();

        var results = new List<SupportMessage>();

        while (query.HasMoreResults)
        {
            var response = await query.ReadNextAsync();
            results.AddRange(response);
        }

        return results;
    }
}