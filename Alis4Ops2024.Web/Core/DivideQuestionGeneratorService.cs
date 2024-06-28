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
    public class DivideQuestionGeneratorService : IDivideQuestionGeneratorService
    {
        // Add upper and lower
        public int Upper { get; set; } = 12;
        public int Lower { get; set; } = 1;
        public string Operator { get; set; } = "Divide";
        public string SelectedItem { get; set; } = "1";
        public DivideQuestionGeneratorService()
        {

        }
        public BaseQuestion GenerateQuestion(int upperRange, int lowerRange, string _operator, string selectedItem)
        {
            int minInputNumber = 1;
            int maxInputNumber = 3; // Change this value as needed if equation has more than 2 operands
            var random = new Random(); // InputNumber is the number of Operands plus Answer. 
            var question = new BaseQuestion(); // maxInputNumber for (1 + 2 = 3) is 3. maxInputNumber for (1 + 2 + 4 = 7) is 4 
            int Operand2Temp = 0;
            string SelectedItemTemp = selectedItem;
            switch (selectedItem)
            { 
                    case "Divide-Missing":  // To write code logic for Divide Missing ?/6 = 5, 40/? = 10, 42/7 = ?
                        _operator = "Divide";
                        question.Operator = _operator;
                        question.Operand2 = randomNumberGenerator.GetRandomNumber(lowerRange, upperRange);
                        question.Operand1 = randomNumberGenerator.GetRandomNumber(lowerRange, upperRange) * question.Operand2;
                        question.Answer = GetAnswer(question);
                        // Call the GetRandomNumber method with the desired maximum number
                        question.InputPosition = randomNumberGenerator.GetRandomNumber(minInputNumber,maxInputNumber);
                        int DivideMissingTemp;
                        switch (question.InputPosition)
                        {
                            case 1:
                                DivideMissingTemp = question.Answer;
                                question.Answer = question.Operand1;
                                question.Operand1 = DivideMissingTemp;
                                break;
                            case 2:
                                DivideMissingTemp = question.Answer;
                                question.Answer = question.Operand2;
                                question.Operand2 = DivideMissingTemp;
                                break;
                    }
                        break;
                    default:
                        question.Operator = _operator;
                        question.Operand2 = lowerRange;
                        question.Operand1 = randomNumberGenerator.GetRandomNumber(lowerRange, upperRange) * lowerRange;
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
            question.Operand1 = randomNumberGenerator.GetRandomNumber(Lower, Upper);
            question.Operand2 = randomNumberGenerator.GetRandomNumber(Lower, Upper);
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

            public int GetRandomNumber(int minNumber,int maxNumber)
            {
                // Generate a random number between 1 and maxNumber (inclusive)
                int randomNumber = random.Next(minNumber, maxNumber + 1);
                return randomNumber;
            }
        }
    }
}
