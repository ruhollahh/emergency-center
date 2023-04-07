namespace EmergencyCenter.Users;

public class User
{
    private string FirstName { get; }
    private string LastName { get; }
    private string FullName => $"{FirstName} {LastName}";
    public Gender Gender { get; }
    public string NationalCode { get; }
    private string Address { get; }

    public User(string firstName, string lastName, Gender gender, string nationalCode, string address)
    {
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        NationalCode = nationalCode;
        Address = address;
    }
}