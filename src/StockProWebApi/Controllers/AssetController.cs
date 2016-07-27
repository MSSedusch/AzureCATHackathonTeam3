using System.Collections.Generic;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Configuration;

namespace StockProWebApi.Controllers
{
    public class AssetController : ApiController
    {
        // GET api/values 
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        
        public DataTable GetDataTable(ref System.Data.SqlClient.SqlConnection _SqlConnection, string _SQL)
        {
            System.Data.SqlClient.SqlCommand _SqlCommand = new System.Data.SqlClient.SqlCommand(_SQL, _SqlConnection);
            System.Data.SqlClient.SqlDataAdapter _SqlDataAdapter = new System.Data.SqlClient.SqlDataAdapter();
            _SqlDataAdapter.SelectCommand = _SqlCommand;

            DataTable _DataTable = new DataTable();
            _DataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;

            try
            {
                _SqlDataAdapter.Fill(_DataTable);
            }
            catch (System.Exception)
            {

            }
            return _DataTable;
        }

        public string DataTableToJsonWithJavaScriptSerializer(DataTable table)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in table.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }
            return jsSerializer.Serialize(parentRow);
        }
        
        // GET api/values/5 
        public string Get(int id)
        {
            SqlConnection conn;
            DataTable dt;

            //ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["DBConnString"];

            conn = new System.Data.SqlClient.SqlConnection();
            conn.ConnectionString =
                "Data Source=tcp:cathack03.database.windows.net,1433;Initial Catalog=portfoliodb;Integrated Security=False;User Id=cathack03;Password=CAT@Hack#3;Encrypt=True;TrustServerCertificate=False;MultipleActiveResultSets=True";

            conn.Open();

            dt = GetDataTable(ref conn, "select * from UserAssetValuesHistory UAVH inner join Users U on UAVH.UserID = U.UserID inner join AssetTypes A on UAVH.AssetTypeID = A.AssetTypeID where U.LoginName = 'raramani' order by U.UserID, A.AssetTypeID, UAVH.AsOnDate");

            return DataTableToJsonWithJavaScriptSerializer(dt);
        }

        // POST api/values 
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5 
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5 
        public void Delete(int id)
        {
        }
    }
}
