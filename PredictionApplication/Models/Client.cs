using PredictionApplication.Enums;

namespace PredictionApplication.Models
{
    public class Client
    {
        public DateTime DateOfBirth { get; private set; }
        public string? Address { get; private set; }
        public Gender Gender { get; private set; }

        public Client(DateTime dateOfBirth, string? address, Gender gender)
        {
            DateOfBirth = dateOfBirth;
            Address = address;
            Gender = gender;
        }

        public int GetAge()
        {
            var currentDate = DateTime.Now;
            int age = currentDate.Year - DateOfBirth.Year;

            if (currentDate.Month < DateOfBirth.Month || (currentDate.Month == DateOfBirth.Month && currentDate.Day < DateOfBirth.Day))
            {
                age--;
            }

            return age;
        }

        public void UpdateClient(DateTime dateOfBirth, string address, Gender gender)
        {
            DateOfBirth = dateOfBirth;
            Address = address;
            Gender = gender;
        }
    }
}
