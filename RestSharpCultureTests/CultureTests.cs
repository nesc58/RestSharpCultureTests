using System;
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
    [TestFixture, Parallelizable(ParallelScope.All)]
    public class RestSharpTests
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
                        .WithPath($"/api/v1/person/1"))
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(HttpStatusCode.OK)
                        .WithHeader("Content-Type", "application/json")
                        .WithBody(Person.CreateDefaultJson()));

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
        public void TestWithCulture(CultureInfo culture)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.ReadOnly(culture);
            Thread.CurrentThread.CurrentCulture = CultureInfo.ReadOnly(culture);

            var request = new RestRequest("api/v1/person/1", Method.GET);
            var result = _restClient.Execute<Person>(request);
            result.Data.Should().BeEquivalentTo(Person.CreateDefault());
        }
    }
}