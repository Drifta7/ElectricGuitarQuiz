using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ElectricGuitarQuiz
{
    public class Guitar
    {
        

        public string Name;
        public int Strings;
        public string GuitarBody; // whether it's an arch top or solidbody
        public double Price;
        public string colorOrFinish;
        public int tuners;
        public string fretboardWood;

        public Pickups thePickups = new Pickups();

        // will remove later this was just for testing 
        public static void PlayNote(string chord)
        {
            Console.WriteLine($"Fretting the Chord {chord}");
        }

        public class Pickups // compemplating on whether that should be in it's own class 
        {
            public string pickupType; // single coil or humbucker
            public string pickupBrand; // EMG, Seymour Duncan, etc.
            public int numberOfPickups;
            public int numberOfCoils;
            public int numberOfWires;
            public int numberOfMagnets;
            public int numberOfScrews;
            public int numberOfPoles;

            public int humbuckers;
            public int singleCoils;
        }

        XmlSerializer serializer = new XmlSerializer(typeof(List<Guitar>));
        string path = @"\Users\User\Documents\GitHub\ElectricGuitarQuiz\ElectricGuitarQuiz\bin\Debug\net6.0-windows\ElectricGuitarQuiz.exe";
    }
}
