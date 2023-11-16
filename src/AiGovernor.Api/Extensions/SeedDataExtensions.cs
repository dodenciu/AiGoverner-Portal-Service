using AiGovernorPortal.Application.Abstractions.Data;
using Bogus;
using Dapper;

namespace AiGovernorPortal.Api.Extensions;

public static class SeedDataExtensions
{
    public static async Task SeedData(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        await Task.Delay(TimeSpan.FromSeconds(2));

        var sqlConnectionFactory = scope.ServiceProvider.GetRequiredService<ISqlConnectionFactory>();
        using var connection = sqlConnectionFactory.CreateConnection();

        var faker = new Faker();

        List<object> features = new();

        for (var i = 0; i < 5; i++)
        {
            features.Add(new
            {
                Id = Guid.NewGuid(),
                Name = faker.Random.Word(),
                Description = faker.Random.Words(),
                State = faker.Random.Number(1, 3),
                AiProxies = new int[2] { 1, 2 },
                Storage = new int[2] { 1, 2 }
            });
        }

        const string sql = """
            INSERT INTO public.features
            (id, "name", description, state, ai_proxies, storage)
            VALUES(@Id, @Name, @Description, @State, @AiProxies, @Storage);
            """;

        await connection.ExecuteAsync(sql, features);
    }
}
