using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ElectricGuitarQuiz
{   
    public class GuitarParts
    {
        public string Name = "";
        public int Strings;
        public string GuitarBody = ""; // whether it's an arch top or solidbody
        public double Price;
        public string ColorOrFinish = "";
        public int tuners;
        public string fretboardWood = "";

        public Pickups thePickups = new Pickups(); // this will be used to store the pickups information


        public class Pickups // compemplating on whether that should be in it's own class 
        {
            public string pickupType = ""; // single coil or humbucker
            public string pickupBrand = ""; // EMG, Seymour Duncan, etc.
            public int numberOfPickups;
            public int numberOfCoils;
            public int numberOfWires;

            public int humbuckers;
            public int singleCoils;
        }
    }
}
