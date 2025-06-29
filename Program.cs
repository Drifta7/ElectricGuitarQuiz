using System.Globalization;

namespace ElectricGuitarQuiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // string chord = "Cmaj7";
            GuitarParts theGuitar = new GuitarParts(); // bringing in the Guitar class from the Guitar.cs file into an object called theGuitar (NOTE)
            GuitarParts anotherGuitar = new GuitarParts();
            GuitarParts theGuitar2 = new GuitarParts();

            List<GuitarParts> GuitarList = new List<GuitarParts>(); // explicitly declaring the data type list of Guitar objects and initializing an empty instance

            //Guitar AGuitar = new Guitar { Name = "Fender Stratocaster", GuitarBody = "Solid", colorOrFinish = "Sunburst" };

            GuitarParts guitar = new GuitarParts
            {
                Name = "Gibson ES-335",
                Strings = 6,
                Price = 1500.00,
                thePickups = new GuitarParts.Pickups() { humbuckers = 2 },
                GuitarBody = "Semi-Hollow",
                ColorOrFinish = "VintageSunburst"
            }; // creating a new object and setting the properties at the same time

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(GuitarParts)); // just an example

            serializer.Serialize(Console.Out, guitar); // this serilizes the object to XML and prints it out to the console.

            //_----____----_-______--_-______---------------- (Serialize and Deserialize) ---------__---__-_-_-_-------------_--_-_--__---------------__--__-_-___- 

            GuitarQuestionsList questionManager = new GuitarQuestionsList(); // creating an instance of the GuitarQuestion class

            // create the question
            QuizQuestion question = new GuitarQuestionsList().GetSampleQuestion(); // accessing the GuitarQuestions class to call the GetSampleQuestion method to create a question object

            //serialized question to Xml
            string filepath = @"D:\Random Drawings\Serialization Guitar.xml";
            questionManager.SaveQuestionToFile(question, filepath); // saving the question to a file
            Ui_Methods.DisplayingSavedToFile(); // displaying a message to the user that the question has been saved

            // derserialize the question from the file
            QuizQuestion loadedQuestion = questionManager.LoadQuestionFromFile(filepath); // loading the question from the file
            Console.WriteLine("\nLoaded Question:");
            Console.WriteLine("Question:" + loadedQuestion.Question1);

            // prints out the list within the class QuizQuestion from SampleQuestion().cs (method)
            foreach (string option in question.Options)
            {
                Console.WriteLine(option);
            }
            //_----____----_-______--_-______---------------------(TESTING)----__---__-_-_-_-------------_--_-_--__---------------__--__-_-___-

            //theGuitar.Name = "Gibson ES-335";
            //theGuitar.Strings = 6;
            //// theGuitar.GuitarBody = "Semi-Hollow";
            //theGuitar.Price = 1500.00;
            //theGuitar.thePickups.humbuckers = 2;
            ////theGuitar.colorOrFinish = "VintageSunbrust";
            //theGuitar.tuners = 6;
            //theGuitar.fretboardWood = "Rosewood";

            //anotherGuitar.Name = "Fender Stratocaster";
            //anotherGuitar.Strings = 6;
            //anotherGuitar.GuitarBody = "Solid";
            //anotherGuitar.Price = 1200.00;
            //anotherGuitar.colorOrFinish = "Sunburst";
            //anotherGuitar.tuners = 6;
            //anotherGuitar.fretboardWood = "Rosewood";
            //anotherGuitar.thePickups.singleCoils = 3; // on stratocaster

            //theGuitar2.Name = "Gibson Les Paul";
            //theGuitar2.Strings = 6;
            //theGuitar2.GuitarBody = "SolidBody";
            //theGuitar2.Price = 1000.00;
            //theGuitar2.colorOrFinish = "GoldTop";
            //theGuitar2.tuners = 6;
            //theGuitar2.fretboardWood = "Ebony";
            //theGuitar2.thePickups.humbuckers = 2; // on les paul
            //theGuitar2.thePickups.singleCoils = 0; // on les paul they can have humbuckers or P90s and P90's are single coils 


            //theGuitar.thePickups = new Guitar.Pickups(); // creates a new object    

            //Guitar.PlayNote(chord);

            //GuitarList.Add(AGuitar); // Testing Purposes
            //GuitarList.Add(guitar); // Testing Purposes
            //GuitarList.Add(theGuitar2); // Testing Purposes


            //foreach (Guitar list in GuitarList)
            //    Console.WriteLine(list.Name);


        }
    }
}
