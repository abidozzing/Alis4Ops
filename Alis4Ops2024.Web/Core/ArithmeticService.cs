// ArithmeticService.cs
using System;

public interface IArithmeticService
{
    (int, int) GenerateAdditionProblem();
    (int, int) GenerateSubtractionProblem();
    bool CheckAnswer(int answer);
    void ResetCounters();
    int CorrectAnswerCounter { get; }
    int WrongAnswerCounter { get; }
    int TotalCount { get; }
}

public class ArithmeticService : IArithmeticService
{
    private readonly Random random;
    private int operand1;
    private int operand2;
    private int correctAnswer;
    private bool isFirstWrongAnswer;
    private int correctAnswerCounter;
    private int wrongAnswerCounter;
    private int totalCount;

    public ArithmeticService()
    {
        random = new Random();
        ResetCounters();
    }

    public (int, int) GenerateAdditionProblem()
    {
        operand1 = random.Next(1, 6);
        operand2 = random.Next(1, 6);
        correctAnswer = operand1 + operand2;
        return (operand1, operand2);
    }

    public (int, int) GenerateSubtractionProblem()
    {
        operand1 = random.Next(1, 6);
        operand2 = random.Next(1, operand1 + 1); // Ensure operand2 <= operand1
        correctAnswer = operand1 - operand2;
        return (operand1, operand2);
    }

    public bool CheckAnswer(int answer)
    {
        totalCount++;

        if (answer == correctAnswer)
        {
            correctAnswerCounter++;
            isFirstWrongAnswer = true; // Reset isFirstWrongAnswer on correct answer
            return true;
        }
        else
        {
            if (isFirstWrongAnswer)
            {
                wrongAnswerCounter++;
                isFirstWrongAnswer = false; // Prevent multiple increments for same question
            }
            return false;
        }
    }

    public void ResetCounters()
    {
        correctAnswerCounter = 0;
        wrongAnswerCounter = 0;
        totalCount = 0;
        isFirstWrongAnswer = true;
    }

    public int CorrectAnswerCounter => correctAnswerCounter;
    public int WrongAnswerCounter => wrongAnswerCounter;
    public int TotalCount => totalCount;
}
