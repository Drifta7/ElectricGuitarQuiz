using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace ElectricGuitarQuiz
{
    public class QuizQuestion
    {
        public string WrittenOutQuestion { get; set; }
        public List<string> Options { get; set; }
        public char CorrectAnswer { get; set; }
        

        public QuizQuestion()
        {
            Options = new List<string>(); // initialize the List
        }

        public override string ToString()
        {
            string optionsText = string.Join("\n", Options);
            return $"Question: {WrittenOutQuestion}\n {optionsText}\nCorrect Answer:{CorrectAnswer}";
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
                return (List <QuizQuestion>)serializer.Deserialize(fs);
            }
        }
    }
}

