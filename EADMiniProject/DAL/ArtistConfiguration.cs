using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace EADMiniProject.DAL
{
    public class ArtistConfiguration : DbConfiguration
    {
        public ArtistConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }
    }
}