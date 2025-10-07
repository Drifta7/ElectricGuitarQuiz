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

        public QuizQuestion GetSampleQuestion()// to be called in the Program.cs
        {

            QuizQuestion question = new QuizQuestion
            {
                // instead of this use the questions and answersf from the user input in the Create Mode
                WrittenOutQuestion = "What is the style of guitar that has an arch -top?",
                CorrectAnswer = 'C'
            };

            Console.WriteLine("What is the style the Guitar that has an arch-top?"); // Blueprint for a question.

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

            string CorrectAnswerVar = CorrectAnswer.ToString().ToUpper(); // converts the char to a string and makes it uppercase.

            return question; // store this for XML serialization later.
        }


        public static List<QuizQuestion> PrintOutSelectedNumberOfQuestions() // this will be used for Create Mode 
        {
            int numberOfQuestions = UiMethods.InputNumberOfQuestions(); // returned int in called method will be stored here.

            List<QuizQuestion> quizQuestion = new List<QuizQuestion>();// for the user to enter their own question and answers in a list.
            bool isQuestionCreationComplete = false;

            for (int i = 0; i < numberOfQuestions; i++) // this will print out the selected number of questions
            {
                char multiChoiceChar = (char)('A' + i); // this will cast a char and the iterator "i" will increment the char value as A, B, C, etc.
                QuizQuestion question = new QuizQuestion(); // creates a new instance of the question.

                UiMethods.PromptUserToCreateQuestions();

                Console.WriteLine($" Enter question {i + 1}:"); // prompts the user to enter a question
                question.WrittenOutQuestion = Console.ReadLine(); // waits for user to input question

                quizQuestion.Add(question); // add typed answer to the list
            }
            
            isQuestionCreationComplete = true;
           
            if (isQuestionCreationComplete)
            {
                UiMethods.PromptingUserToCreateMoreQuestions(); //this is after the loop is finished and the user has a choice to make more question or not
            }
            return quizQuestion;
        }

        public static List <QuizQuestion> PrintOutSelectedNumberOfOptions()
        {
            List<QuizQuestion> quizQuestion = new List<QuizQuestion>();
            QuizQuestion question = new QuizQuestion();
            
            question.Options = new List<string>(); // initializes the Options list for each question
            
            int numberOfOptions = UiMethods.InputNumberOfAnswers(); //returned int in called method will be stored here.

            for (int j = 0; j < numberOfOptions; j++)
            {
                char optionLabel = (char)('A' + j);
                Console.WriteLine($"Option {optionLabel}");
                string optionText = Console.ReadLine(); // waits for user to put in text for the option
                question.Options.Add($"{optionLabel}: {optionText}"); // adds the option to the list with the label
            }

             // from Line 180 to 188 is to just check if the user placed a valid answer or not 
            string correctValidInput; // making sure that the user inputs a valid answer 
            do
            {
                correctValidInput = Console.ReadLine().Trim().ToUpper(); //
            }
            while (string.IsNullOrEmpty(correctValidInput));

            UiMethods.PromptUserToCreateCorrectAnswer();
            question.CorrectAnswer = Console.ReadLine().ToUpper()[0]; // reads the correct answer from user and selects the first character of the array from string array

            quizQuestion.Add(question);// adds the question to the list of questions
            return quizQuestion;
        }

        public override string ToString()
        {
            string optionsText = string.Join("\n", Options);
            return $"Question: {WrittenOutQuestion}\n {optionsText}\nCorrect Answer:{CorrectAnswer}";
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

