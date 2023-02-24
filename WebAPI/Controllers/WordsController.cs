using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
  public class WordsController : ApiController
  {
    public HttpResponseMessage Get ()
    {
      string query = @"SELECT WordId, Word, WordTypeId FROM dbo.Words";
      DataTable table = new DataTable();
      using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SentenceBuilderAppDB"].ConnectionString))
        using(var cmd = new SqlCommand(query,con))
        using(var da = new SqlDataAdapter(cmd))
			{
        cmd.CommandType = CommandType.Text;
        da.Fill(table);
			}
      return Request.CreateResponse(HttpStatusCode.OK, table);
    }
  }
}
