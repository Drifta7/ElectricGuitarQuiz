using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ElectricGuitarQuiz
{
    public class Logic
    {
        // create a random method that can pick up out a number between 1 and 7-8 and display it to the user 
        //then that number will be used to select a question from the list of questions.

        // might have to use a foreach loop to get the question to the user but that miight be in the UImethods file


        public static QuizQuestion GetRandomQuestion(List<QuizQuestion> questions)
        {
            Random random = new Random();
            int randomIndex = random.Next(questions.Count); // get a random index based on the number of questions available
            return questions[randomIndex]; // return the randomly selected question
        }


        // used to pass in list of questions to check if null or empty "THIS IS MORE DYNAMIC"

        public static string saveUserDirectoryPath = null;


        public static bool CheckIfListIsNotEmpty(List<QuizQuestion> checkingList)
        {
            return checkingList != null && checkingList.Any(); // this checks if the list isn't null before it checks if it's empty
        }

        //serialize
        public static void SaveQuestionToFile(List<QuizQuestion> question, string filepath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<QuizQuestion>));

            string directory = Path.GetDirectoryName(filepath);
            Directory.CreateDirectory(directory);

            ////DEBUG
            //Console.WriteLine(directory); //Delete later
            //Console.WriteLine(filepath); //Delete later

            using (FileStream fs = new FileStream(filepath, FileMode.Create)) // creates the file to the HD
            {
                serializer.Serialize(fs, question);
            }
        }
        // deserialize
        public static List<QuizQuestion> LoadQuestionFromFile(string filepath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<QuizQuestion>));
            using (FileStream fs = new FileStream(filepath, FileMode.Open))
            {
                return (List<QuizQuestion>)serializer.Deserialize(fs);
            }
        }

    }
}
