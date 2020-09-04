using RestSharp;
using RestSharp.Serialization;
using RestSharp.Serialization.Json;

namespace RestSharpCultureTests
{
    public static class TestData
    {
        public static readonly IRestSerializer DefaultSerializer = new JsonSerializer {DateFormat = "yyyy-MM-ddTHH:mm:ss.FFFFFFFZ"};

        public static class DataObjTests
        {
            public static readonly string DefaultJson = DataObj.CreateDefaultJson();
            public static readonly RestResponse DefaultRestResponse = new RestResponse {Content = DefaultJson, ContentType = "application/json"};
            public static readonly DataObj ExpectedDeserialized = DataObj.CreateDefault();
        }
        public static class PersonTests
        {
            public static readonly string DefaultJson = Person.CreateDefaultJson();
            public static readonly RestResponse DefaultRestResponse = new RestResponse {Content = DefaultJson, ContentType = "application/json"};
            public static readonly Person ExpectedDeserialized = Person.CreateDefault();
        }
    }
}