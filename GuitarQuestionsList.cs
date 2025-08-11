using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ElectricGuitarQuiz
{
    public class GuitarQuestionsList
    {
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

            foreach (string option in question.Options)
            {
                Console.WriteLine(option);
            }

            return question; // store this for XML serialization later.

        }

        public QuizQuestion GetSampleQuestion_1()
        {
            QuizQuestion question = new QuizQuestion
            {
                Question = "Which Guitar has single coils as opposed to humbuckers?",
                CorrectAnswer = 'B'
            };
            
            Console.WriteLine("Which Guitar has single coils as opposed to humbuckers?");
            
            question.Options.Add($"A: Gibson ES-335");
            question.Options.Add($"B: Gibson SG Standard");
            question.Options.Add($"C: Gretsch White Falcon");
            question.Options.Add($"D: Fender JazzMaster");
            question.Options.Add($"E: Fender Stratocaster");
            question.Options.Add($"A: Gibson Les Paul");

            foreach (string option in question.Options)
            {
                Console.WriteLine(option);
            }

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
        //public char CorrectAnswer = GuitarQuizQuestion(Ui_Methods.GetValidUserChoice()); // this will store the user answer or maybe serilize it later.
    }
}




//------will use this soon but want to test out one question first.

//public char Question2(char UserGuess)
//{
//    Console.WriteLine("How many Pickups does a Fender startocaster have?");

//    Console.WriteLine($"A: {UserGuess}2 Pickups");
//    Console.WriteLine($"B: {UserGuess}3 Pickups");
//    Console.WriteLine($"C: {UserGuess}4 Pickups");
//    Console.WriteLine($"D: {UserGuess}5 Pickups");

//    char correctAnswer = 'B';
//    return correctAnswer;
//}

