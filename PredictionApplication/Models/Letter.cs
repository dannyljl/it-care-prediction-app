using PredictionApplication.Enums;

namespace PredictionApplication.Models
{
    public class Letter
    {
        public Client AssignedClient { get; private set; }
        public SicknessType SicknessType { get; private set; }

        public LetterType LetterType { get; private set; }

        public Letter(Client assignedClient, SicknessType sicknessType, LetterType letterType)
        {
            AssignedClient = assignedClient;
            SicknessType = sicknessType;
            LetterType = letterType;
        }
    }

}
