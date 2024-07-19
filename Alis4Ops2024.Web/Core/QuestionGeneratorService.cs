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
    public class QuestionGeneratorService : IQuestionGeneratorService
    {
        // Add upper and lower
        public int Upper { get; set; } = 5;
        public int Lower { get; set; } = 1;
        public string Operator { get; set; } = "Add";
        public string SelectedItem { get; set; } = "1-5";
        public String Topic { get; set; } = "Add";
        public QuestionGeneratorService()
        {

        }
        public BaseQuestion GenerateQuestion(int upperRange, int lowerRange, string _operator, string selectedItem, string topic)
        {
            int maxInputNumber = 3; // Change this value as needed if equation has more than 2 operands
            var random = new Random(); // InputNumber is the number of Operands plus Answer. 
            var question = new BaseQuestion(); // maxInputNumber for (1 + 2 = 3) is 3. maxInputNumber for (1 + 2 + 4 = 7) is 4 
            int Operand2Temp = 0;
            string SelectedItemTemp = selectedItem;
            switch (_operator)
            {
                case "Add":
                    // For the others besides the exception in the "case" statement below,
                    // the Lower and Upper range received is used to generate the the numbers as operands and the answer. 
                    switch (selectedItem)

                    {
                        // Create equations with missing numbers in random positions.
                        // To write code logic for Add Missing ? + 6 = 18, 4 + ? = 12, 2 + 7 = ?
                        case "Add-Missing":
                            question.Operand1 = random.Next(0, upperRange + 1);
                            question.Operand2 = random.Next(0, upperRange + 1);
                            question.Operator = _operator;
                            question.Answer = GetAnswer(question);

                            // Call the GetRandomNumber method with the desired maximum number of operands + 1
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

                        // Create addition questions that add up to a specified number
                        case "Make-5":
                            question.Operand1 = 10;
                            question.Operand2 = random.Next(0, upperRange + 1);
                            Operand2Temp = question.Operand1 - question.Operand2;
                            question.Operand1 = Operand2Temp;
                            question.Operator = _operator;
                            question.Answer = GetAnswer(question);
                            break;

                        case "Make-10":
                            question.Operand1 = 20;
                            question.Operand2 = random.Next(0, upperRange + 1);
                            Operand2Temp = question.Operand1 - question.Operand2;
                            question.Operand1 = Operand2Temp;
                            question.Operator = _operator;
                            question.Answer = GetAnswer(question);
                            break;

                        case "Make-20":
                            question.Operand1 = 10;
                            question.Operand2 = random.Next(0, upperRange + 1);
                            Operand2Temp = question.Operand1 - question.Operand2;
                            question.Operand1 = Operand2Temp;
                            question.Operator = _operator;
                            question.Answer = GetAnswer(question);
                            break;

                        case "Make-50":
                            question.Operand1 = 20;
                            question.Operand2 = random.Next(0, upperRange + 1);
                            Operand2Temp = question.Operand1 - question.Operand2;
                            question.Operand1 = Operand2Temp;
                            question.Operator = _operator;
                            question.Answer = GetAnswer(question);
                            break;

                        case "Make-100":
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
                    break;



                case "Subtract":
                    switch (selectedItem)
                    // if upperRange-lowerRange = 0 item clicked is "Sum equals 10".upperRange =10, lowerRange=10
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
                        default:
                            question.Operand1 = random.Next(lowerRange, upperRange + 1); 
                            question.Operand2 = random.Next(lowerRange, upperRange + 1); 

                            question.Operator = _operator;
                            question.Answer = GetAnswer(question);
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


                case "Multiply":
                    switch (selectedItem)
                    // if upperRange-lowerRange = 0 item clicked is "Sum equals 10".upperRange =10, lowerRange=10
                    // To write code logic for Multiply Missing ? x 6 = 18, 4 x ? = 28, 2 x 7 = ?
                    {
                        case "Multiply-Missing":  
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
                            question.Operand1 = random.Next(1, upperRange) * lowerRange;
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
