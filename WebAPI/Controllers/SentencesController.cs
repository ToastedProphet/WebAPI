using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class SentencesController : ApiController
    {
		public HttpResponseMessage Get()
		{
			string query = @"SELECT Sentence FROM dbo.Sentences";
			DataTable table = new DataTable();
			using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SentenceBuilderAppDB"].ConnectionString))
			using (var cmd = new SqlCommand(query, con))
			using (var da = new SqlDataAdapter(cmd))
			{
				cmd.CommandType = CommandType.Text;
				da.Fill(table);
			}
			return Request.CreateResponse(HttpStatusCode.OK, table);
		}

		public string Post(Sentences sntnce)
    {
			try
			{
        string query = @"INSERT INTO dbo.Sentences VALUES ('" + sntnce.Sentence + "')";
        DataTable table = new DataTable();
        using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SentenceBuilderAppDB"].ConnectionString))
        using (var cmd = new SqlCommand(query, con))
        using (var da = new SqlDataAdapter(cmd))
        {
          cmd.CommandType = CommandType.Text;
          da.Fill(table);
        }
        return "Successfully added";

      }
      catch (Exception)
			{
        return "Failed to add!";
				throw;
			}

    }

  //Adding custom CRUD calls will look similar to this
  //Route to indicate call that needs to be made from the front end
  //[HttpGet] to show what CRUD call it is (Can be Get,Post,Put,Delete)

  //  [Route("api/Sentences/GetAllSentences")]
  //  [HttpGet]
  //  public HttpResponseMessage GetAllSentences ()
		//{
  //    string query = @"SELECT Sentence FROM dbo.Sentences";
  //    DataTable table = new DataTable();
  //    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SentenceBuilderAppDB"].ConnectionString))
  //    using (var cmd = new SqlCommand(query, con))
  //    using (var da = new SqlDataAdapter(cmd))
  //    {
  //      cmd.CommandType = CommandType.Text;
  //      da.Fill(table);
  //    }
  //    return Request.CreateResponse(HttpStatusCode.OK, table);
  //  }
  }
}
