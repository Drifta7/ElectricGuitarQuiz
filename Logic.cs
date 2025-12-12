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
        public static QuizQuestion GetRandomQuestion(List<QuizQuestion> questions)
        {
            Random random = new Random();
            int randomIndex = random.Next(questions.Count); // get a random index based on the number of questions available
            return questions[randomIndex]; // return the randomly selected question
        }

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
