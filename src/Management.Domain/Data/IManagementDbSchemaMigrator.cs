using System.Threading.Tasks;

namespace Management.Data;

public interface IManagementDbSchemaMigrator
{
    Task MigrateAsync();
}
