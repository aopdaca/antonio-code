using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Person> data = GetInitialData();
            var filePath = @"C:\revature\date.xml"; //xml
            var jsonFilePath = @"C:\revature\date.json"; 

            //List<Person> data = ReadXmlFromFile(filePath);
            Task<List<Person>> task = ReadJsonFromFileAsync(jsonFilePath);
            List<Person> data = task.Result;// synchronization
            //in c# like many languages literal strings use \ slashes to escape special characters
            //\n new line
            //we have @ strings to disable those escapes


            ModifyData(data);


            WriteXmlToFile(data, filePath);

            WriteJsonToFileAsync(data, filePath).Wait(); //wait synchronusly for the result
            //(bad to do! except again this is the main method)

            //aync imoirtant for netwrrking and disk access

            //C# does have the avility to directly with threads
            //usually we perefer tasks
            //tasks arent directly 1 to 1 with threads. could be a few tasks across many threads,
            //or you can have sevral tasks on one thread

            //we can also have thread pools in .Net

            //parallel processing
            //parallel.ForEach()
            //we can run some function on each element of a list in true parallel

            // you shouls know what deadlock is
            object o = new object();
            lock (o)
            {
                //no other thread can aquire that lock until i get out of this block
            }
        }

        //to avoid just waiting for long running operations
        //in csharp we use task and async/await.
        // no preactical benifit in a simple console app, but its a necessary
        //practice on a more complicated app

        private static async Task<List<Person>> ReadJsonFromFileAsync(string filePath)
        {
            //string json = File.ReadAllText(filePath);
            string json = await File.ReadAllTextAsync(filePath);

            //the await operator waits on a task and extracts its inner result
            //but it does so in a way that allows other code to run in the meantime.

            var data = JsonConvert.DeserializeObject<List<Person>>(json);

            return data;
        }

        // to convert synchronus code to asynchronous code, we follow some steps:
        //1. replace the sync call with an Async call. 
        // the library whose code you are using need to provide this!!
        //2. await" the result of that call
        //3. change the current method to async keyword
        //4.wrap return type of this method in a task
        //5. (convertion) remane method to end in Async
        //6. repeat for all mothods that call THIS method
        private static  async Task WriteJsonToFileAsync(List<Person> data, string filePath)
        {
            // if an async method return nothing it should return task

            //.NET does have a built in Data serializer built in
            //but most people use a 3rd party laibrary called JSON.Net(aka Newronsoft.JSON)

            string json = JsonConvert.SerializeObject(data);

            //(should have exception handling here)
            await File.WriteAllTextAsync(filePath, json);
        }

        private static void ModifyData(List<Person> data)
        {
            var lastItem = data.Last();
            lastItem.Id++;
        }

        private static List<Person> ReadXmlFromFile(string filePath)
        {
            //we can customize the format of the xml using options on this
            var serializer = new XmlSerializer(typeof(List<Person>));

            //really should still have try catch to handle the exceptions
            //ommited for brevity

            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {

                var data = (List<Person>)serializer.Deserialize(fileStream);
                return data;
                //using block asts like a try-finally and it calles .Dispose in the finally
                //for Idispose objects
                //Dispose is a method that cleans up any resources that the CLR cannot automatially manage.

            }
        }

        private static bool WriteXmlToFile(List<Person> data, string filePath)
        {
            //xml doesnt understand generics so we code like this
            var serializer = new XmlSerializer(typeof(List<Person>));

            //Creat mode to overwrite any existing file
            FileStream fileStream = null;


            try
            {

                //Creat mode to overwrite any existing file
                fileStream = new FileStream("filePath", FileMode.Create);

                //serialize data
                serializer.Serialize(fileStream, data);

                fileStream.Close();
            }
            catch(PathTooLongException ex)
            {
                //more specific exception cathc must be first
                //exceptions are matched agains try catch block 
                Console.WriteLine("Error - path is too long");
                Console.WriteLine(ex.Message);
                return false;

            }
            catch (IOException ex)
            {
                Console.WriteLine("Error while wwriting to file");
                Console.WriteLine(ex.Message);
                return false;
            }
            finally // runs
            {
                fileStream?.Close();
            }

            return true;
        }

        private static List<Person> GetInitialData()
        {
            return new List<Person>
            {
                new Person
                {
                    Id = 1,
                    FirstName= "Antonio",
                    LastName = "Garcia",
                    Address = new Address
                    {
                        Street = "123 main st",
                        City = "Dallas",
                        State  = "Tx"
                    }
                }
            };
            
        }
    }
}
