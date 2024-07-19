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
        public string Operator { get; set; } = "Subtract";
        public string SelectedItem { get; set; } = "1-5";
        public String Topic { get; set; } = "Subtract";
        public SubtractQuestionGeneratorService()
        {

        }
        public BaseQuestion GenerateQuestion(int upperRange, int lowerRange, string _operator, string selectedItem, string topic)
        {
            int maxInputNumber = 3; // Change this value as needed if equation has more than 2 operands
            int minInputNumber = 1;
            string SelectedItemTemp = selectedItem;
            Topic = topic;
            int TempNumber = 1;
            SelectedItem = selectedItem;
            var question = new BaseQuestion(); // maxInputNumber for (1 + 2 = 3) is 3. maxInputNumber for (1 + 2 + 4 = 7) is 4 
            // For the others besides the exception in the "case" statement below,
            // the Lower and Upper range received is used to generate the the numbers as operands and the answer. 
            switch (Topic)

            {
                case "Subtract":
                    // Create equations with missing numbers in random positions.
                    // To write code logic for Add Missing ? + 6 = 18, 4 + ? = 12, 2 + 7 = ?
                    // Create addition questions that add up to a specified number
                    switch (selectedItem)
                    {
                        // Create subtraction questions that add up to a specified number
                        case "From 5":
                        case "From 10":
                        case "From 20":
                        case "From 50":
                        case "From 100":
                            question.Operand1 = upperRange;
                            question.Operand2 = randomNumberGenerator.GetRandomNumber(1, upperRange);
                            question.Operator = _operator;
                            question.Answer = GetAnswer(question);
                            minInputNumber = 2;
                            maxInputNumber = 3;
                            question.InputPosition = randomNumberGenerator.GetRandomNumber(minInputNumber, maxInputNumber);
                            switch (question.InputPosition)
                            {
                                case 2:
                                    TempNumber = question.Answer;
                                    question.Answer = question.Operand2;
                                    question.Operand2 = TempNumber;
                                    break;
                            }
                            break;

                        default:
                            question.Operand1 = randomNumberGenerator.GetRandomNumber(lowerRange, upperRange);
                            question.Operand2 = randomNumberGenerator.GetRandomNumber(lowerRange, upperRange);
                            question.Operator = _operator;
                            question.Answer = GetAnswer(question);
                            break;
                    }
                    break;
                //redo the logic
                //AddMissing can select from menu 1 to 12
                //AddSubtract will be random for both selected lower and upper values and displayed as missing
                // To write code logic for Subtract Missing ? - 6 = 18, 4 - ? = 1, 21 - 7 = ?
                case "SubtractMissing":
                case "AddSubtract":
                case "MixedFourOps":
                    question.Operand1 = randomNumberGenerator.GetRandomNumber(lowerRange, upperRange);
                    question.Operand2 = randomNumberGenerator.GetRandomNumber(lowerRange, upperRange);
                    question.Operator = _operator;
                    question.Answer = GetAnswer(question);
                    // Call the GetRandomNumber method with the desired maximum number
                    question.InputPosition = randomNumberGenerator.GetRandomNumber(minInputNumber, maxInputNumber);
                    switch (question.InputPosition)
                    {
                        case 1:
                            TempNumber = question.Answer;
                            question.Answer = question.Operand1;
                            question.Operand1 = TempNumber;
                            break;
                        case 2:
                            TempNumber = question.Answer;
                            question.Answer = question.Operand2;
                            question.Operand2 = TempNumber;
                            break;
                        case 3:
                            break;
                    }
                    break;

                default:
                    question.Operand1 = randomNumberGenerator.GetRandomNumber(lowerRange, upperRange);
                    question.Operand2 = randomNumberGenerator.GetRandomNumber(lowerRange, upperRange);
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

            public int GetRandomNumber(int minNumber, int maxNumber)
            {
                // Generate a random number between 1 and maxNumber (inclusive)
                int randomNumber = random.Next(minNumber, maxNumber + 1);
                return randomNumber;
            }
        }
    }
}
