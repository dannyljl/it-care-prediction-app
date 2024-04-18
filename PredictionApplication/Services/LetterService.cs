using PredictionApplication.Enums;
using PredictionApplication.Interfaces;
using PredictionApplication.Models;

namespace PredictionApplication.Services
{
    public class LetterService : ILetterService
    {
        private ISicknessType _sicknessTypePredictor;
        public LetterService(ISicknessType sicknessTypePredictor)
        {
            _sicknessTypePredictor = sicknessTypePredictor;
        }

        public Letter CreateLetter(Client client, SicknessType sicknessType)
        {
            return new Letter(client, sicknessType,_sicknessTypePredictor.CheckPrediction(client));
        }
    }
}
