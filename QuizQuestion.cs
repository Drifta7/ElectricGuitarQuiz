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
            
            Console.WriteLine("What is the style the Guitar that has an arch-top?"); // Blueprint for a question.

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

            //-------_--------- Questiond For the User to fill -----------_---_-_-----_- MIGHT NOT USE THIS FOR A FOR LOOP IS BETTER!!!!!

            QuizQuestion userQuizQuestion = new QuizQuestion();
            userQuizQuestion.Question = " ";    // this is a placeholder for the user to enter their own question.
           
                        

            //QuizQuestion userQuizQuestion_2 = new QuizQuestion();
            //userQuizQuestion_2.Question = "";

            //QuizQuestion userQuizQuestion_3 = new QuizQuestion();
            //userQuizQuestion_2.Question = "";

            //QuizQuestion userQuizQuestion_4 = new QuizQuestion();
            //userQuizQuestion_4.Question = "";

            //QuizQuestion userQuizQuestion_5 = new QuizQuestion();
            //userQuizQuestion_5.Question = "";

            //QuizQuestion userQuizQuestion_6 = new QuizQuestion();
            //userQuizQuestion_6.Question = "";

            userQuizQuestion.CorrectAnswer = ' '; // this is a placeholder for the user to enter their own correct answer.
           
            Console.WriteLine("Enter the Question for the multiple answers");

            question.Options.Add($"A:  ");
            question.Options.Add($"B:  ");
            question.Options.Add($"C:  ");
            question.Options.Add($"D:  ");
            question.Options.Add($"E:  ");
            question.Options.Add($"A:  ");

            return question;
        }


       
        public static void PrintOutSelectedNumberOfQuestions() // this will be used for Create Mode 
        {
            int numberOfQuestions = Ui_Methods.InputNumberOfQuestions();
            
            QuizQuestion question = new QuizQuestion();// for the user to enter their own question and answers

            for (int i = 0; i < numberOfQuestions; i++) // this will print out the selected number of questions
            {
                
                char multiChoiceChar = (char)('A' + i); string userInput = Console.ReadLine(); // this will cast a char and the iterator "i" will increment the char value
                Console.WriteLine($"{multiChoiceChar}" + "Enter Question" + ":");

                // there supposed to be a method that creates a question in here 
                
                question.Options.Add($"{multiChoiceChar}: {userInput}"); // this will add to the list with the label")
            }
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

