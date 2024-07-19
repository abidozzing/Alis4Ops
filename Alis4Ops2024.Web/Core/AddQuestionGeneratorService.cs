using Alis4Ops2024.Web.Pages;
using Alis4Ops2024.Web.Models;
using System;
using System.Data;
namespace Alis4Ops2024.Web.Core
{
    public class AddQuestionGeneratorService : IAddQuestionGeneratorService
    {
        // Add upper and lower
        public int Upper { get; set; } = 5;
        public int Lower { get; set; } = 1;
        public string Operator { get; set; } = "Add";
        public string SelectedItem { get; set; } = "1-5";
        public String Topic { get; set; } = "Add";
        public AddQuestionGeneratorService()
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
            var random = new Random(); // InputNumber is the number of Operands plus Answer. 
            var question = new BaseQuestion(); // maxInputNumber for (1 + 2 = 3) is 3. maxInputNumber for (1 + 2 + 4 = 7) is 4 
            question.Operator = _operator;
            switch (Topic)
            {
                case "Add":
                    // Create equations with missing numbers in random positions.
                    // To write code logic for Add Missing ? + 6 = 18, 4 + ? = 12, 2 + 7 = ?
                    // Create addition questions that add up to a specified number
                    switch (selectedItem)
                    {
                        case "Make-5":
                        case "Make-10":
                        case "Make-20":
                        case "Make-50":
                        case "Make-100":
                            question.Operand1 = upperRange;
                            question.Operand2 = randomNumberGenerator.GetRandomNumber(lowerRange, upperRange - lowerRange);
                            TempNumber = question.Operand1 - question.Operand2;
                            question.Operand1 = TempNumber;
                            question.Operator = _operator;
                            question.Answer = GetAnswer(question);
                            maxInputNumber = 2;
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
                            }
                            break;
                        default:
                            question.Operand1 = upperRange;
                            question.Operand2 = randomNumberGenerator.GetRandomNumber(lowerRange, upperRange - lowerRange);
                            TempNumber = question.Operand1 - question.Operand2;
                            question.Operand1 = randomNumberGenerator.GetRandomNumber(lowerRange, TempNumber);
                            question.Operator = _operator;
                            question.Answer = GetAnswer(question);
                            break;
                    }
                    break;
                case "AddMissing":
                case "AddSubtract":
                case "MixedFourOps":
                    question.Operand1 = upperRange;
                    question.Operand2 = randomNumberGenerator.GetRandomNumber(lowerRange, upperRange - lowerRange);
                    TempNumber = question.Operand1 - question.Operand2;
                    question.Operand1 = randomNumberGenerator.GetRandomNumber(lowerRange, TempNumber);

                    question.Operator = _operator;
                    question.Answer = GetAnswer(question);

                    // Call the GetRandomNumber method with the desired maximum number of operands + 1
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
                    question.Operand1 = upperRange;
                    question.Operand2 = randomNumberGenerator.GetRandomNumber(lowerRange, upperRange - lowerRange);
                    TempNumber = question.Operand1 - question.Operand2;
                    question.Operand1 = randomNumberGenerator.GetRandomNumber(lowerRange, TempNumber);
                    question.Operator = _operator;
                    question.Answer = GetAnswer(question);
                    break;
            }

            return question;
        }

        public BaseQuestion GenerateQuestion()
        {
            var question = new BaseQuestion();

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
            private static Random random;

            public RandomNumberGenerator()
            {
                // Seed the random number generator with current time ticks
                random = new Random((int)DateTime.UtcNow.Ticks);
            }

            public int GetRandomNumber(int minNumber, int maxNumber)
            {
                // Generate a random number between minNumber and maxNumber (inclusive)
                int randomNumber = random.Next(minNumber, maxNumber + 1);
                return randomNumber;
            }
        }

    }
}

