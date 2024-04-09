using PredictionApplication.Enums;
using PredictionApplication.Models;

namespace PredictionApplication.Services
{
    public interface ILetterService
    {
        public Letter CreateLetter(Client client, SicknessType sicknessType);
    }
}
