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
    public class MultiplyQuestionGeneratorService : IMultiplyQuestionGeneratorService
    {
        // Add upper and lower
        public int Upper { get; set; } = 12;
        public int Lower { get; set; } = 1;
        public string Operator { get; set; } = "Multiply";
        public string SelectedItem { get; set; } = "1";
        public String Topic { get; set; } = "Multiply";
        public MultiplyQuestionGeneratorService()
        {

        }
        public BaseQuestion GenerateQuestion(int upperRange, int lowerRange, string _operator, string selectedItem, string topic)
        {
            int minInputNumber = 1;
            int maxInputNumber = 3;
            // Change this value as needed if equation has more than 2 operands
            var random = new Random(); // InputNumber is the number of Operands plus Answer. 
            var question = new BaseQuestion(); // maxInputNumber for (1 + 2 = 3) is 3. maxInputNumber for (1 + 2 + 4 = 7) is 4 
            int Operand2Temp = 1;
            string SelectedItemTemp = selectedItem;
            Topic = topic;
            int TempNumber = 1;
            SelectedItem = selectedItem;
            _operator = "Multiply";
            question.Operator = _operator;
            bool PositionFlag = true; // Flag to determine whether to execute inner switch

            switch (Topic)
            {
                case "MultiplyMissing":
                    question.Operand1 = lowerRange;
                    question.Operand2 = randomNumberGenerator.GetRandomNumber(1, upperRange);
                    question.Operator = _operator;
                    question.Answer = GetAnswer(question);
                    // Call the GetRandomNumber method with the desired maximum number
                    question.InputPosition = randomNumberGenerator.GetRandomNumber(minInputNumber, maxInputNumber);
                    break;
                case "MultiplyDivide":
                case "MixedFourOps":
                    question.Operand1 = randomNumberGenerator.GetRandomNumber(1, lowerRange);
                    question.Operand2 = randomNumberGenerator.GetRandomNumber(1, upperRange);
                    question.Operator = _operator;
                    question.Answer = GetAnswer(question);
                    // Call the GetRandomNumber method with the desired maximum number
                    question.InputPosition = randomNumberGenerator.GetRandomNumber(minInputNumber, maxInputNumber);
                    break;
                default:
                    question.Operator = _operator;
                    question.Operand1 = lowerRange;
                    question.Operand2 = randomNumberGenerator.GetRandomNumber(1, upperRange);
                    question.Answer = GetAnswer(question);
                    break;
            }

            // Execute inner switch only if executeInnerSwitch flag is true
            if (PositionFlag)
            {
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

            return question.Operand1 * question.Operand2;

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
