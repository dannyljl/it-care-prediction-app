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

        public void UpdateClient(DateTime dateOfBirth, string address, Gender gender)
        {
            DateOfBirth = dateOfBirth;
            Address = address;
            Gender = gender;
        }
    }
}
