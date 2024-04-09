using PredictionApplication.Enums;
using PredictionApplication.Exceptions;
using PredictionApplication.Models;

namespace PredictionApplication.Services
{
    public class LetterService : ILetterService
    {
        public LetterService()
        {
            
        }

        public Letter CreateLetter(Client client, SicknessType sicknessType)
        {
            var clientAge = client.GetAge();
            if(clientAge < 14)
            {
                throw new Exception("client is under the age of 14, age is:" + clientAge);
            }
            if(client.Address == string.Empty)
            {
                throw new Exception("client address is invalid, address is:" + client.Address);
            }

            if(sicknessType == SicknessType.Physical)
            {
                if(clientAge <= 34)
                {
                    return new Letter(client, sicknessType, LetterType.Questionnaire);
                }
                if(clientAge <= 44 && client.Gender == Gender.Female)
                {
                    return new Letter(client, sicknessType, LetterType.Questionnaire);
                }
                if(clientAge > 60)
                {
                    return new Letter(client, sicknessType, LetterType.PhysicalVisit);
                }

                return new Letter(client, sicknessType, LetterType.TelephoneAppointment);

            }
            if (sicknessType == SicknessType.Mental)
            {
                if(client.Gender == Gender.Male)
                {
                    return new Letter(client, sicknessType, LetterType.PhysicalVisit);
                }
                if (clientAge < 25)
                {
                    return new Letter(client, sicknessType, LetterType.TelephoneAppointment);
                }
                if(clientAge < 25 && clientAge <= 34 && client.Gender == Gender.Other)
                {
                    return new Letter(client, sicknessType, LetterType.TelephoneAppointment);
                }
                return new Letter(client, sicknessType, LetterType.PhysicalVisit);
            }
            throw new UnsupportedEnumTypeException("Sickness type not found, type:" + sicknessType.ToString());
        }
    }
}
