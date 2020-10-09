using System.Collections.Generic;
using TRMDataManager.Library.Internal.DataAccess;
using TRMDataManager.Library.Models;

namespace TRMDataManager.Library.DataAccess
{
    public class UserData
    {
        public List<UserModel> GetUsersById(string Id)
        {
            SqlDataAccess sql = new SqlDataAccess();
            var p = new { Id = Id }; 
            var output = sql.LoadData<UserModel, dynamic>("dbo.spUserLookup", p, "TRMDataConnection"); //DefaultConnection
            return output;
        }
    }
}
