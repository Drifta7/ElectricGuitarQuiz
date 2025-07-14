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
        public string Question { get; set; }
        public List<string> Options { get; set; }
        public char CorrectAnswer { get; set; }

        public QuizQuestion()
        {
            Options = new List<string>(); // initialize the List
        }

        public QuizQuestion GetSampleQuestion()
        {

            QuizQuestion question = new QuizQuestion
            {
                Question = "What is the style of guitar that has an arch -top?",
                CorrectAnswer = 'C'
            };

            Console.WriteLine("What is the style the Guitar that has an arch-top?"); // perhaps make this a blank for spaceholder for a question 

            question.Options.Add($"A: Gibson Les Paul"); // make this a placeholder for a question perhaps(and for the rest of the other questions).
            question.Options.Add($"B: Fender Stratocaster");
            question.Options.Add($"C: Gibson ES-335");
            question.Options.Add($"D: Fender JazzMaster");
            question.Options.Add($"E: Gibson SG Standard");
            question.Options.Add($"F: Gretsch White Falcon");

            return question; // store this for XML serialization later.
        }

        public QuizQuestion BlankQuizQuestionsForUser()
        {
            QuizQuestion question = new QuizQuestion
            {
                Question = " ",
                CorrectAnswer = ' '
            };
            
            Console.WriteLine("Enter the Question for the multiple answers");

            question.Options.Add($"A:  ");
            question.Options.Add($"B:  ");
            question.Options.Add($"C:  ");
            question.Options.Add($"D:  ");
            question.Options.Add($"E:  ");
            question.Options.Add($"A:  ");

            return question;
        }

        //serialize
        public void SaveQuestionToFile(QuizQuestion question, string filepath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(QuizQuestion));
            string path = @"D:\Random Drawings\Serialization Guitar.xml";

            using (FileStream fs = new FileStream(filepath, FileMode.Create)) // creates the file to the HD
            {
                serializer.Serialize(fs, question);
            }
        }
        // deserialize
        public QuizQuestion LoadQuestionFromFile(string filepath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(QuizQuestion));
            using (FileStream fs = new FileStream(filepath, FileMode.Open))
            {
                return (QuizQuestion)serializer.Deserialize(fs);
            }
        }
        

    }
}

