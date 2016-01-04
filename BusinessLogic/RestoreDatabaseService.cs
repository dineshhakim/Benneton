using System.Data;
using DataLogic;

namespace BusinessLogic
{
    public class RestoreDatabaseService
    {
        public static DataTable RestoreDatabase(int Event, string fileName, string databaseName)
        {
            return RestoreDatabaseData.RestoreDatabase(Event, fileName, databaseName);
        }
    }
}
