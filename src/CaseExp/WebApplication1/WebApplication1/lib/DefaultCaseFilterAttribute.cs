// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultCaseFilterAttribute.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WebApplication1.lib
{
    #region

    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Web.Http.Filters;
    using Newtonsoft.Json.Serialization;

    #endregion

    public class CamelCaseFilterAttribute : ActionFilterAttribute
    {
        #region Static Fields

        private static readonly JsonMediaTypeFormatter CaseFormatter = new JsonMediaTypeFormatter();

        #endregion

        #region Constructors and Destructors

        static CamelCaseFilterAttribute()
        {
            CaseFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        #endregion

        #region Public Methods and Operators

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var content = actionExecutedContext.Response.Content as ObjectContent;
            if (content != null)
            {
                if (content.Formatter is JsonMediaTypeFormatter)
                {
                    actionExecutedContext.Response.Content = new ObjectContent(
                        content.ObjectType, 
                        content.Value, 
                        CaseFormatter);
                }
            }
        }

        #endregion
    }

    public class PascalCaseFilterAttribute : ActionFilterAttribute
    {
        #region Static Fields

        private static readonly JsonMediaTypeFormatter CaseFormatter = new JsonMediaTypeFormatter();

        #endregion

        #region Constructors and Destructors

        static PascalCaseFilterAttribute()
        {
            CaseFormatter.SerializerSettings.ContractResolver = new DefaultContractResolver();
        }

        #endregion

        #region Public Methods and Operators

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var content = actionExecutedContext.Response.Content as ObjectContent;
            if (content != null)
            {
                if (content.Formatter is JsonMediaTypeFormatter)
                {
                    actionExecutedContext.Response.Content = new ObjectContent(
                        content.ObjectType, 
                        content.Value, 
                        CaseFormatter);
                }
            }
        }

        #endregion
    }
}