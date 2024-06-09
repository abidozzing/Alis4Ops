namespace Alis4Ops2024.Web.Models

// Missing numbers questions
//  Operand1 (4Ops) Operand2 = Result
//  Position of InputBox is either at position Operand1, Operand2 or Result
//  We give a variable AnswerPosition an int with value 1,2 or 3
//  AnswerPosition determines where to locate the InputBox where the user input the answer.
// If InputPosition = 1, InputBox is at Operand1
// If InputPosition = 2, InputBox is at Operand2
// If InputPosition = 3, InputBox is at Result

{
    public class BaseQuestion
    {
        public int Operand1 { get; set; }
        public int Operand2 { get; set; }
        public string Operator { get; set; }
        public int Answer { get; set; }
        public int InputPosition { get; set; }
        public char OperatorAsSymbol
        {
            get
            {
                switch (Operator)
                {
                    case "Add":
                        return '+';
                    case "Subtract":
                        return '-';
                    case "Multiply":
                        return 'x';
                    case "Divide":
                        return '\u00F7';
                    default: 
                        return 'z';

                }
            }
        }
    }

}
