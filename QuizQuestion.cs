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
        public List <char> CorrectAnswers { get; set; }
        
        public QuizQuestion()
        {
            Options = new List<string>(); // initialize the List
        }

        public override string ToString()
        {
            string optionsText = string.Join("\n", Options);
            return $"Question: {WrittenOutQuestion}\n {optionsText}\nCorrect Answer:{CorrectAnswers}";
        }
    }
}

