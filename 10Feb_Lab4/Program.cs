namespace _10Feb_Lab4
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            #region XML Serialize and Deserialize
            //var people = new List<Person>
            //{
            //    new Person("Adil","Heybetov",24),
            //    new Person("Arif","Babayev",17),
            //    new Person("Huseyn","Aliyev",23),
            //    new Person("Huseyn","Quliyev",17),
            //};

            //var serializer = new XmlSerializer(typeof(List<Person>));

            //using (var writer = new StreamWriter("people.xml"))
            //{
            //    serializer.Serialize(writer, people);
            //}
            //List<Person> deserializedPeople = (List<Person>)serializer.Deserialize(File.OpenRead("people.xml"));

            //foreach (var person in deserializedPeople)
            //{
            //    Console.WriteLine($"{"Firstname:",-10}{person.FirstName}");
            //    Console.WriteLine($"{"Lastname:",-10}{person.LastName}");
            //    Console.WriteLine($"{"Age:",-10}{person.Age}\n");
            //}
            #endregion

            #region Writing Fetched JSON to file
            string url = "https://jsonplaceholder.typicode.com/posts";

            await WriteFetchedJsonToFileAsync(url);
            #endregion
        }

        static async Task WriteFetchedJsonToFileAsync(string url)
        {
            using (HttpClient client = new())
            {
                string json = await client.GetStringAsync(url);
                
                await File.Create("test.json").DisposeAsync();
                
                await File.WriteAllTextAsync("test.json", json);
            }
        }
    }
}