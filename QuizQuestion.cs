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
        public string Question1 { get; set; }
        public List<string> Options { get; set; }
        public char CorrectAnswer { get; set; }
       
        public QuizQuestion()
        {
            Options = new List<string>(); // initialize the List
        }

       


    }
}
