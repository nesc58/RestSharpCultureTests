using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;

namespace RestSharpCultureTests
{
    [TestFixture, Parallelizable(ParallelScope.All)]
    public class SerializerTests
    {
        private static IEnumerable<TestCaseData> TestCases()
        {
            return CultureInfo.GetCultures(CultureTypes.AllCultures).Select(c => new TestCaseData(c).SetArgDisplayNames($"{c.Name} ({c.EnglishName})"));
        }

        [Test, TestCaseSource(nameof(TestCases))]
        public void Deserialize_ShouldReturnTheCorrectObject_WhenObjectIsPerson(CultureInfo culture)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.ReadOnly(culture);
            Thread.CurrentThread.CurrentCulture = CultureInfo.ReadOnly(culture);

            var result = TestData.DefaultSerializer.Deserialize<Person>(TestData.PersonTests.DefaultRestResponse);
            result.Should().BeEquivalentTo(TestData.PersonTests.ExpectedDeserialized);
        }

        [Test, TestCaseSource(nameof(TestCases))]
        public void Deserialize_ShouldReturnTheCorrectObject_WhenObjectIsDataObj(CultureInfo culture)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.ReadOnly(culture);
            Thread.CurrentThread.CurrentCulture = CultureInfo.ReadOnly(culture);

            var result = TestData.DefaultSerializer.Deserialize<DataObj>(TestData.DataObjTests.DefaultRestResponse);
            result.Should().BeEquivalentTo(TestData.DataObjTests.ExpectedDeserialized);
        }
    }
}