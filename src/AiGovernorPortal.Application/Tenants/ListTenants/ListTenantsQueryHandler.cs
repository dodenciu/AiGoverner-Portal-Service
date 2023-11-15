using AiGovernorPortal.Application.Abstractions.Data;
using AiGovernorPortal.Application.Abstractions.Messaging;
using AiGovernorPortal.Domain.Abstractions;
using Dapper;

namespace AiGovernorPortal.Application.Tenants.ListTenants;

public class ListTenantsQueryHandler
    : IQueryHandler<ListTenantsQuery, IReadOnlyList<TenantResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public ListTenantsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }
    public async Task<Result<IReadOnlyList<TenantResponse>>> Handle(
        ListTenantsQuery request,
        CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
                        SELECT
                            id as Id,
                            name as Name,
                            subdomain as Subdomain,
                            status as State,
                            created_on_utc as CreatedOnUtc,
                            address as Address,
                            email as Email,
                            company as Company
                        FROM Tenant
                        ORDER BY CreatedOnUtc
                        OFFSET @Offset @Page
                        FETCH NEXT @PageSize @Page ONLY;
                        """;

        var tenants = await connection
            .QueryAsync<TenantResponse, ContactResponse, TenantResponse>(
                sql,
                (tenant, contact) =>
                {
                    tenant.Contact = contact;
                    return tenant;
                },
                new
                {
                    request.Page,
                    request.PageSize
                });

        return tenants.ToList();
    }
}