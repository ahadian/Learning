using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MongoDbRnd.MakeUpClass;

namespace MongoDbRnd.Controllers
{
    public class DataManipulationQueryController : ApiController
    {

        [HttpPost]
        public HttpResponseMessage GetFiltered(GetFilteredQuery query)
        {

            return this.Request.CreateResponse(new DataQueryRepository().GetFiltered(query.EntityName,),HttpStatusCode.Accepted);
        }
    }

    public class DataQueryRepository()
    {
        
    }
}
