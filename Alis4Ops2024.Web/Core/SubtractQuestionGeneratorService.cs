using Alis4Ops2024.Web.Pages;
using Alis4Ops2024.Web.Models;
using System;
using System.Data;

//Create QuestionGeneratorService for different category of question.
//Innitially create 4 QuestionGeneratorService for each operations = - x /
//This will reduce clutter as each operation uses its own QuestionGeneratorService.
//AddQuestionGeneratorService, SubtractQuestionGeneratorService, MultiplyQuestionGeneratorService
//and DivideQuestionGeneratorService.

namespace Alis4Ops2024.Web.Core
{
    public class SubtractQuestionGeneratorService : ISubtractQuestionGeneratorService
    {
        // Add upper and lower
        public int Upper { get; set; } = 5;
        public int Lower { get; set; } = 1;
        public string Operator { get; set; } = "Add";
        public string SelectedItem { get; set; } = "0-5";
        public SubtractQuestionGeneratorService()
        {

        }
        public BaseQuestion GenerateQuestion(int upperRange, int lowerRange, string _operator, string selectedItem)
        {
            int maxInputNumber = 3; // Change this value as needed if equation has more than 2 operands
            var random = new Random(); // InputNumber is the number of Operands plus Answer. 
            var question = new BaseQuestion(); // maxInputNumber for (1 + 2 = 3) is 3. maxInputNumber for (1 + 2 + 4 = 7) is 4 
            int Operand2Temp = 0;
            string SelectedItemTemp = selectedItem;
            // For the others besides the exception in the "case" statement below,
            // the Lower and Upper range received is used to generate the the numbers as operands and the answer. 
            switch (selectedItem)

            {

                case "Subtract-Missing":  // To write code logic for Subtract Missing ? - 6 = 18, 4 - ? = 1, 21 - 7 = ?
                    question.Operand1 = random.Next(0, upperRange + 1);
                    question.Operand2 = random.Next(0, upperRange + 1);
                    question.Operator = _operator;
                    question.Answer = GetAnswer(question);
                    // Call the GetRandomNumber method with the desired maximum number
                    question.InputPosition = randomNumberGenerator.GetRandomNumber(maxInputNumber);
                    int SubtractMissingTemp;
                    switch (question.InputPosition)
                    {
                        case 1:
                            SubtractMissingTemp = question.Answer;
                            question.Answer = question.Operand1;
                            question.Operand1 = SubtractMissingTemp;
                            break;
                        case 2:
                            SubtractMissingTemp = question.Answer;
                            question.Answer = question.Operand2;
                            question.Operand2 = SubtractMissingTemp;
                            break;
                        case 3:
                            break;
                    }
                    break;

                // Create subtraction questions that add up to a specified number
                case "Subtract-from-5":
                    question.Operand1 = 10;
                    question.Operand2 = random.Next(0, upperRange + 1);
                    Operand2Temp = question.Operand1 - question.Operand2;
                    question.Operand1 = Operand2Temp;
                    question.Operator = _operator;
                    question.Answer = GetAnswer(question);
                    break;

                case "Subtract-from-10":
                    question.Operand1 = 20;
                    question.Operand2 = random.Next(0, upperRange + 1);
                    Operand2Temp = question.Operand1 - question.Operand2;
                    question.Operand1 = Operand2Temp;
                    question.Operator = _operator;
                    question.Answer = GetAnswer(question);
                    break;

                case "Subtract-from-20":
                    question.Operand1 = 10;
                    question.Operand2 = random.Next(0, upperRange + 1);
                    Operand2Temp = question.Operand1 - question.Operand2;
                    question.Operand1 = Operand2Temp;
                    question.Operator = _operator;
                    question.Answer = GetAnswer(question);
                    break;

                case "Subtract-from-50":
                    question.Operand1 = 20;
                    question.Operand2 = random.Next(0, upperRange + 1);
                    Operand2Temp = question.Operand1 - question.Operand2;
                    question.Operand1 = Operand2Temp;
                    question.Operator = _operator;
                    question.Answer = GetAnswer(question);
                    break;

                case "Subtract-from-100":
                    question.Operand1 = 20;
                    question.Operand2 = random.Next(0, upperRange + 1);
                    Operand2Temp = question.Operand1 - question.Operand2;
                    question.Operand1 = Operand2Temp;
                    question.Operator = _operator;
                    question.Answer = GetAnswer(question);
                    break;

                default:
                    question.Operand1 = random.Next(lowerRange, upperRange + 1);
                    question.Operand2 = random.Next(lowerRange, upperRange + 1);

                    question.Operator = _operator;
                    question.Answer = GetAnswer(question);
                    break;
            }

            return question;

        }

        public BaseQuestion GenerateQuestion()
        {
            var random = new Random();
            var question = new BaseQuestion();
            string SelectedItemTemp = SelectedItem;
            question.Operand1 = random.Next(Lower, Upper);
            question.Operand2 = random.Next(Lower, Upper);
            question.Operator = Operator;

            question.Answer = GetAnswer(question);

            return question;
        }

        private int GetAnswer(BaseQuestion question)
        {
            switch (question.Operator)
            {
                case "Add":
                    return question.Operand1 + question.Operand2;
                case "Subtract":
                    if (question.Operand1 < question.Operand2)
                    {
                        int operandTemp = question.Operand1;
                        question.Operand1 = question.Operand2;
                        question.Operand2 = operandTemp;
                    }
                    return question.Operand1 - question.Operand2;
                case "Multiply":
                    return question.Operand1 * question.Operand2;
                case "Divide":
                    {

                    }
                    return question.Operand1 / question.Operand2;

                default:
                    question.Operator = "Add";
                    return question.Operand1 + question.Operand2;
                    //throw new InvalidOperationException($"Operator is not valid {question.Operator}");
                    break;
            }
        }

        // Create an instance of RandomNumberGenerator
        RandomNumberGenerator randomNumberGenerator = new RandomNumberGenerator();

        public class RandomNumberGenerator
        {
            private static Random random = new Random();

            public int GetRandomNumber(int maxNumber)
            {
                // Generate a random number between 1 and maxNumber (inclusive)
                int randomNumber = random.Next(1, maxNumber + 1);
                return randomNumber;
            }
        }
    }
}
