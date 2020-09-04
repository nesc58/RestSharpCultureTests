namespace RestSharpCultureTests
{
    public class Person
    {
        public string InternalName { get; set; }
        public static Person CreateDefault()
        {
            return new Person
            {
                InternalName = nameof(InternalName),
            };
        }

        public static string CreateDefaultJson()
        {
            return  @"{""internalName"":""InternalName""}";
        }
    }
}