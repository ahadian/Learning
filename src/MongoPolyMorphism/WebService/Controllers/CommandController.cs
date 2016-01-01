using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Selise.AppSuite.DataDefination.Core.PrimaryEntities;
using Selise.AppSuite.MongoDbDataContext.RepositoryImpls;
using WebService.ManagersAndAll;

namespace WebService.Controllers
{
    public class CommandController : ApiController
    {
        private string DbName = "MongoPolyMorphism";
        public CommandController()
        {
            
        }

        

        [HttpGet]
        public HttpResponseMessage InsertConetentTile()
        {
            object obj = new ContentTile()
            {
                CreateDate = DateTime.UtcNow,
                CreatedBy = "Najim",
                ItemId = SuperManager.Rand.Id(),
                ShortText = SuperManager.Rand.String(),
                Tags = SuperManager.Rand.StringArray()
            };
            new CommandRepository(this.DbName).Insert("ContentTile",obj);
            return this.Request.CreateResponse(HttpStatusCode.OK,"All is well,Insert");
        }
        [HttpGet]
        public HttpResponseMessage UpdateConetentTile(string id)
        {
            object obj = new ContentTile()
            {
                CreateDate = DateTime.UtcNow,
                CreatedBy = "Najim",
                ItemId = id,
                ShortText = SuperManager.Rand.String(),
                Tags = SuperManager.Rand.StringArray()
            };
            new CommandRepository(this.DbName).Update("ContentTile", obj);
            return this.Request.CreateResponse(HttpStatusCode.OK, "All is well,Update");
        }
    }
}