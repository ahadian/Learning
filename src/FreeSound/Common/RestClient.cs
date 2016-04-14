// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HttpRequestFactory.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Web;
using FreeSound;

namespace Selise.AppSuite.Common
{
    #region

    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;

    using Newtonsoft.Json;


    using File = System.IO.File;

    #endregion

    public class RestClient<TRequest>
    {
        #region Constants

        private const string TENANT_HEADER_NAME = "X-TENANT";

        #endregion

        #region Fields

        private readonly string apiActionUrl;

        private readonly string apiBaseUrl;

        private readonly HttpMethod httpMethod;

        private readonly TRequest requestObject;

        private readonly string mediaType;


        #endregion

        #region Constructors and Destructors

        public RestClient(HttpMethod httpMethod, string apiActionUrl, string apiBaseUrl, TRequest requestObject, string _mediaType)
        {
            this.httpMethod = httpMethod;
            this.apiActionUrl = apiActionUrl;
            this.requestObject = requestObject;
            this.apiBaseUrl = apiBaseUrl;
            this.mediaType = _mediaType;
        }

        #endregion

        #region Public Methods and Operators

        public HttpRequestMessage CreateHttpRequest()
        {
            if (this.httpMethod == HttpMethod.Get)
            {
                return this.CreateHttpGetRequest();
            }

            if (this.httpMethod == HttpMethod.Post)
            {
                return this.CreateHttpPostRequest();
            }

            if (this.httpMethod == HttpMethod.Put)
            {
                return this.CreateHttpMultipartFormDataRequest();
            }

            return null;
        }

        #endregion

        #region Methods

        private HttpRequestMessage CreateHttpGetRequest()
        {
            NameValueCollection requestParameters = new NameValueCollection();

            this.requestObject.GetType()
                .GetProperties()
                .ToList()
                .ForEach(pi => requestParameters.Add(pi.Name, pi.GetValue(this.requestObject, null).ToString()));

            string queryString = string.Join(
                "&",
                requestParameters.AllKeys.Select(
                    key => string.Format("{0}={1}", key, WebUtility.UrlEncode(requestParameters[key]))));

            string requestUrl = string.Format("{0}/{1}?{2}", this.apiBaseUrl, this.apiActionUrl, queryString);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return request;
        }

        private HttpRequestMessage CreateHttpMultipartFormDataRequest()
        {
            string requestUrl = string.Format("{0}/{1}", this.apiBaseUrl, this.apiActionUrl);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, requestUrl);

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string jsonString = JsonConvert.SerializeObject(this.requestObject);

            var content = new MultipartFormDataContent();

            string filePath =
                (string)this.requestObject.GetType().GetProperty("FilePath").GetValue(this.requestObject, null);
            string fileName =
                (string)this.requestObject.GetType().GetProperty("Name").GetValue(this.requestObject, null);
            string parentDirectoryId =
                (string)this.requestObject.GetType().GetProperty("ParentDirectoryId").GetValue(this.requestObject, null);
            string tags =
                (string)this.requestObject.GetType().GetProperty("Tags").GetValue(this.requestObject, null);
            string itemId =
                (string)this.requestObject.GetType().GetProperty("ItemId").GetValue(this.requestObject, null);

            string metaData =
                (string)this.requestObject.GetType().GetProperty("MetaData").GetValue(this.requestObject, null);


            var fileContent = new ByteArrayContent(File.ReadAllBytes(filePath));

            content.Add(fileContent, "file", fileName);

            content.Add(new StringContent(itemId), "ItemId");
            content.Add(new StringContent(fileName), "Name");
            content.Add(new StringContent(parentDirectoryId ?? string.Empty), "ParentDirectoryId");
            content.Add(new StringContent(tags ?? string.Empty), "Tags");
            content.Add(new StringContent(metaData ?? string.Empty), "MetaData");
            request.Content = content;

            return request;
        }

        private HttpRequestMessage CreateHttpPostRequest()
        {
            string requestUrl = string.Format("{0}/{1}", this.apiBaseUrl, this.apiActionUrl);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, requestUrl);

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(this.mediaType));

            //string jsonString = JsonConvert.SerializeObject(this.requestObject);
            string content = PreparePostContent(this.requestObject, this.mediaType);
            request.Content = new StringContent(content, Encoding.UTF8, this.mediaType);

            return request;
        }

        private string PreparePostContent(TRequest request, string mediaType)
        {
            switch (mediaType)
            {
                case MediaTypes.ApplicationJSON:
                    string jsonString = JsonConvert.SerializeObject(this.requestObject);
                    return jsonString;
                case MediaTypes.ApplicationXUrlEncoded:
                    StringBuilder postData = new StringBuilder();
                    Dictionary<string, string> dictionary = this.requestObject.ToDictionary();
                    foreach (var item in dictionary)
                    {
                        postData.AppendUrlEncoded(item.Key, item.Value,
                            !dictionary[item.Key].Equals(dictionary.Last().Value));
                    }
                    return postData.ToString();
                    break;
                default:
                    throw new Exception("Unknown Media Type");
            }
        }


        //in an extension class

        #endregion
    }
}