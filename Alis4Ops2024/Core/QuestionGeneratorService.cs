using Alis4Ops2024.Components.Pages;
using Alis4Ops2024.Models;
using System;
using System.Data;

//Create QuestionGeneratorService for different types of question

namespace Alis4Ops2024.Core
{
    public class QuestionGeneratorService : IQuestionGeneratorService
    {
        // Add upper and lower
        public int Upper { get; set; } = 5;
        public int Lower { get; set; } = 1;
        public string Operator { get; set; } = "Add";
        public string SelectedItem { get; set; } = "0-5";
        public QuestionGeneratorService()
        {
            
        }
        public BaseQuestion GenerateQuestion(int upperRange, int lowerRange, string _operator, string selectedItem)
        {
            int maxInputNumber = 3; // Change this value as needed
            var random = new Random();
            var question = new BaseQuestion();
            int Operand2Temp = 0;
            string SelectedItemTemp = selectedItem;
            switch (_operator)
            {
                case "Add":
                   
                    switch (selectedItem)
                    // if upperRange-lowerRange = 0 item clicked is "Sum equals 10".upperRange =10, lowerRange=10
                    {
                        case "Add-Missing":  // To write code logic for Add Missing ? + 6 = 18, 4 + ? = 12, 2 + 7 = ?
                            question.Operand1 = random.Next(0, upperRange + 1);
                            question.Operand2 = random.Next(0, upperRange + 1); // Generate a number between lowerRange and upperRange+1
                            question.Operator = _operator;
                            question.Answer = GetAnswer(question);
                            // Call the GetRandomNumber method with the desired maximum number

                            question.InputPosition = randomNumberGenerator.GetRandomNumber(maxInputNumber);
                            int AddMissingTemp;
                            switch (question.InputPosition)
                            {
                                case 1:
                                    AddMissingTemp = question.Answer;
                                    question.Answer = question.Operand1;
                                    question.Operand1 = AddMissingTemp;
                                    break;
                                case 2:
                                    AddMissingTemp = question.Answer;
                                    question.Answer = question.Operand2;
                                    question.Operand2 = AddMissingTemp;
                                    break;
                                case 3:
                                    break;
                            }
                            break;

                        case "Add-to-10": // Create addition question that add up to 10
                            question.Operand1 = 10;
                            question.Operand2 = random.Next(0, upperRange + 1); // Generate a number between lowerRange and upperRange+1
                            Operand2Temp = question.Operand1 - question.Operand2;
                            question.Operand1 = Operand2Temp;
                            question.Operator = _operator;
                            question.Answer = GetAnswer(question);
                            break;

                        case "Add-to-20": // Create addition question that add up to 20
                            question.Operand1 = 20;
                            question.Operand2 = random.Next(0, upperRange + 1); // Generate a number between lowerRange and upperRange+1
                            Operand2Temp = question.Operand1 - question.Operand2;
                            question.Operand1 = Operand2Temp;
                            question.Operator = _operator;
                            question.Answer = GetAnswer(question);
                            break;
                        default:
                            question.Operand1 = random.Next(lowerRange, upperRange + 1); // Generate a number between lowerRange and upperRange+1
                            question.Operand2 = random.Next(lowerRange, upperRange + 1); // Generate a number between lowerRange and upperRange+1
                            question.Operator = _operator;
                            question.Answer = GetAnswer(question);
                            break; 
                    }
                    break;



                case "Subtract":
                    switch (selectedItem)
                    // if upperRange-lowerRange = 0 item clicked is "Sum equals 10".upperRange =10, lowerRange=10
                    {
                        case "Subtract-Missing":  // To write code logic for Subtract Missing ? - 6 = 18, 4 - ? = 1, 21 - 7 = ?
                            question.Operand1 = random.Next(0, upperRange + 1);
                            question.Operand2 = random.Next(0, upperRange + 1); // Generate a number between lowerRange and upperRange+1
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
                                default:
                                question.Operand1 = random.Next(lowerRange, upperRange + 1); // Generate a number between lowerRange and upperRange+1
                                question.Operand2 = random.Next(lowerRange, upperRange + 1); // Generate a number between lowerRange and upperRange+1

                                question.Operator = _operator;
                                question.Answer = GetAnswer(question);
                                break;
                    }
                    break;

                case "Multiply":
                    switch (selectedItem)
                    // if upperRange-lowerRange = 0 item clicked is "Sum equals 10".upperRange =10, lowerRange=10
                    {
                        case "Multiply-Missing":  // To write code logic for Multiply Missing ? x 6 = 18, 4 x ? = 28, 2 x 7 = ?
                            _operator = "Multiply";
                            question.Operator = _operator;
                            question.Operand1 = lowerRange;
                            question.Operand2 = question.Operand2 = random.Next(0, upperRange);
                            question.Operator = _operator;
                            question.Answer = GetAnswer(question);
                            // Call the GetRandomNumber method with the desired maximum number
                            question.InputPosition = randomNumberGenerator.GetRandomNumber(maxInputNumber);
                            int MultiplytMissingTemp;
                            switch (question.InputPosition)
                            {
                                case 1:
                                    MultiplytMissingTemp = question.Answer;
                                    question.Answer = question.Operand1;
                                    question.Operand1 = MultiplytMissingTemp;
                                    break;
                                case 2:
                                    MultiplytMissingTemp = question.Answer;
                                    question.Answer = question.Operand2;
                                    question.Operand2 = MultiplytMissingTemp;
                                    break;
                                case 3:
                                    break;
                            }
                            break;
                                default:
                                question.Operator = _operator;
                                question.Operand1 = lowerRange;
                                question.Operand2 = question.Operand2 = random.Next(0, upperRange);
                                question.Answer = GetAnswer(question);
                                break;
                    }
                    break;

                case "Divide":
                    switch (selectedItem)
                    // if upperRange-lowerRange = 0 item clicked is "Sum equals 10".upperRange =10, lowerRange=10
                    {
                        case "Divide-Missing":  // To write code logic for Divide Missing ?/6 = 5, 40/? = 10, 42/7 = ?
                            _operator = "Divide";
                            question.Operator = _operator;
                            question.Operand2 = lowerRange;
                            question.Operand1 = random.Next(1, upperRange) * lowerRange;
                            question.Answer = GetAnswer(question);
                            // Call the GetRandomNumber method with the desired maximum number
                            question.InputPosition = randomNumberGenerator.GetRandomNumber(maxInputNumber);
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
                                case 3:
                                    break;
                            }
                            break;
                                default:
                                question.Operator = _operator;
                                question.Operand2 = lowerRange;
                                question.Operand1 = random.Next(1, upperRange)*lowerRange;
                                question.Answer = GetAnswer(question);
                                break;
                    }
                    break;



                case "Mixed4Ops":  // To write code logic for Mixed4Ops normal and missing for the 4Ops
                    question.Operator = _operator;
                    question.Operand2 = lowerRange;
                    question.Operand1 = random.Next(1, upperRange) * lowerRange;
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
            question.Operand1 = random.Next(Lower, Upper); // Generate a number between 1 and 10
            question.Operand2 = random.Next(Lower, Upper); // Generate a number between 1 and 10
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
                        //int answerTemp = question.Operand1 / question.Operand2;
                        //question.Operand1= answerTemp;
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
