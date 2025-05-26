using System.Globalization;

namespace ElectricGuitarQuiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string chord = "Cmaj7";
            Guitar theGuitar = new Guitar();
            Guitar anotherGuitar = new Guitar();
            Guitar theGuitar2 = new Guitar();

            List<Guitar> GuitarList = new List<Guitar>(); // explicitly declaring the data type list then creating the object as the "value".

            //Guitar AGuitar = new Guitar { Name = "Fender Stratocaster", GuitarBody = "Solid", colorOrFinish = "Sunburst" };

            Guitar guitar = new Guitar
            {
                Name = "Gibson ES-335",
                Strings = 6,
                Price = 1500.00,
                thePickups = new Guitar.Pickups() { humbuckers = 2 },
                GuitarBody = "Semi-Hollow",
                colorOrFinish = "VintageSunburst"
            }; // creating a new object and setting the properties at the same time

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Guitar));

            serializer.Serialize(Console.Out, guitar); // this serilizes the object to XML and prints it out to the console.
            Console.WriteLine();
            Console.ReadLine();

            

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
