using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoVip.Core
{
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using System.Data;

    public class DataWriteDirectlyService : IDataWriteDirectlyService<IDataEntity>
    {
        public void Save(IEnumerable<IDataEntity> entities)
        {
            if (entities == null) return;
            using (var service = new ShopDataWriter())
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                var database = factory.Create("yovip");
                //   DatabaseFactory.SetDatabaseProviderFactory(DatabaseProviderFactory)

                var queryString = service.GenerateExecuteNonQuery(entities);
                
                int i = database.ExecuteNonQuery(CommandType.Text, queryString);
                Console.WriteLine("Werite {0} ", i);
            }
        }
    }
}
