namespace ElectricGuitarQuiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string chord = "Cmaj7";
            Guitar theGuitar = new Guitar();
            Guitar anotherGuitar = new Guitar();

            var GuitarList = new List<Guitar>(); // why does this work?

            theGuitar.Name = "Gibson ES-335";
            theGuitar.Strings = 6;
            theGuitar.GuitarBody = "Semi-Hollow";
            theGuitar.Price = 1500.00;
            theGuitar.thePickups.humbuckers = 2;
            theGuitar.colorOrFinish = "VintageSunbrust";
            theGuitar.tuners = 6;
            theGuitar.fretboardWood = "Rosewood";

            theGuitar.Name = "Fender Stratocaster";
            theGuitar.Strings = 6;
            theGuitar.GuitarBody = "Solid";
            theGuitar.Price = 1200.00;
            theGuitar.colorOrFinish = "Sunburst";
            theGuitar.tuners = 6;
            theGuitar.fretboardWood = "Rosewood";
            theGuitar.thePickups.singleCoils = 3; // on stratocaster
          
            theGuitar.Name = "Gibson Les Paul";
            theGuitar.Strings = 6;
            theGuitar.GuitarBody = "SolidBody";
            theGuitar.Price = 1000.00;
            theGuitar.colorOrFinish = "GoldTop";
            theGuitar.tuners = 6;
            theGuitar.fretboardWood = "Ebony";
            theGuitar.thePickups.humbuckers = 2; // on les paul
            theGuitar.thePickups.singleCoils = 0; // on les paul they can have humbuckers or P90s and P90's are single coils 


            theGuitar.thePickups = new Guitar.Pickups(); // creates a new object    

            Guitar.PlayNote(chord);




        }
    }
}
