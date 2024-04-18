using PredictionApplication.Enums;
using PredictionApplication.Extensions;
using PredictionApplication.Models;

namespace PredictionApplication.Interfaces
{
    public interface ISicknessType
    {
        public LetterType CheckPrediction(Client client);
    }

    public class PhysicalSicknessType : ISicknessType
    {
        public LetterType CheckPrediction(Client client)
        {
            var age = client.DateOfBirth.Age();
                if (age <= 34)
                {
                    return LetterType.Questionnaire;
                }
                if (age <= 44 && client.Gender == Gender.Female)
                {
                    return LetterType.Questionnaire;
                }
                if (age > 60)
                {
                    return LetterType.PhysicalVisit;
                }
                return LetterType.TelephoneAppointment;
        }
    }

    public class MentalSicknessType : ISicknessType
    {
        public LetterType CheckPrediction(Client client)
        {
            var age = client.DateOfBirth.Age();
            if (client.Gender == Gender.Male)
            {
                return LetterType.PhysicalVisit;
            }
            if (age < 25)
            {
                return LetterType.TelephoneAppointment;
            }
            if (age < 25 && age <= 34 && client.Gender == Gender.Other)
            {
                return LetterType.TelephoneAppointment;
            }
            return LetterType.PhysicalVisit;
        }
    }
}
