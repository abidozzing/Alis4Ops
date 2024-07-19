using Alis4Ops2024.Web.Models;

namespace Alis4Ops2024.Web.Core
{
    public interface IQuestionGeneratorService
    {
        int Upper { get; set; }
        int Lower { get; set; }
        string Operator { get; set; }
        String SelectedItem { get; set; }
        String Topic { get; set; }
        BaseQuestion GenerateQuestion(int upperRange, int lowerRange, string _operator, String _selectedItem, String _topic);
        BaseQuestion GenerateQuestion();
    }
}