using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace RestSharpCultureTests
{
    [TestFixture, Explicit, Parallelizable(ParallelScope.All)]
    public class IntegrationTests
    {
        private WireMockServer _server;
        private RestClient _restClient;

        [OneTimeSetUp]
        public void Setup()
        {
            _server = WireMockServer.Start();
            _server
                .Given(
                    Request.Create()
                        .UsingGet()
                        .WithPath($"/api/v1/data/1"))
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(HttpStatusCode.OK)
                        .WithHeader("Content-Type", "application/json")
                        .WithBody(TestData.DataObjTests.DefaultJson));
            _server
                .Given(
                    Request.Create()
                        .UsingGet()
                        .WithPath($"/api/v1/person/1"))
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(HttpStatusCode.OK)
                        .WithHeader("Content-Type", "application/json")
                        .WithBody(TestData.PersonTests.DefaultJson));

            _restClient = new RestClient($"http://localhost:{_server.Ports.FirstOrDefault()}")
            {
                Encoding = Encoding.UTF8,
                AutomaticDecompression = true,
                UseSynchronizationContext = false
            };
            _restClient.UseSerializer(() => new JsonSerializer { DateFormat = "yyyy-MM-ddTHH:mm:ss.FFFFFFFZ" });
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _server?.Dispose();
        }

        private static IEnumerable<TestCaseData> TestCases()
        {
            return CultureInfo.GetCultures(CultureTypes.AllCultures).Select(c => new TestCaseData(c).SetArgDisplayNames($"{c.Name} ({c.EnglishName})"));
        }

        [Test, TestCaseSource(nameof(TestCases))]
        public void Execute_ShouldReturnTheCorrectObject_WhenObjectIsPerson(CultureInfo culture)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.ReadOnly(culture);
            Thread.CurrentThread.CurrentCulture = CultureInfo.ReadOnly(culture);

            var request = new RestRequest("api/v1/person/1", Method.GET);
            var result = _restClient.Execute<Person>(request);
            result.Data.Should().BeEquivalentTo(TestData.PersonTests.ExpectedDeserialized);
        }

        [Test, TestCaseSource(nameof(TestCases))]
        public void Execute_ShouldReturnTheCorrectObject_WhenObjectIsDataObj(CultureInfo culture)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.ReadOnly(culture);
            Thread.CurrentThread.CurrentCulture = CultureInfo.ReadOnly(culture);

            var request = new RestRequest("api/v1/data/1", Method.GET);
            var result = _restClient.Execute<DataObj>(request);
            result.Data.Should().BeEquivalentTo(TestData.DataObjTests.ExpectedDeserialized);
        }
    }
}