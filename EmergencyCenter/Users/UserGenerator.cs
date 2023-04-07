using EmergencyCenter.Utils;

namespace EmergencyCenter.Users;

public static class UserGenerator
{
    public static User GetUser()
    {
        var firstName = GetFirstName();
        var lastName = GetLastName();
        var gender = GetGender();
        var nationalCode = GetNationalCode();
        var address = GetAddress();
        return new User(firstName, lastName, gender, nationalCode, address);
    }

    private static string GetFirstName()
    {
        return ConsoleUtil.GetValidInput("enter your first name", Validator.IsNotEmpty);
    }
    
    private static string GetLastName()
    {
        return ConsoleUtil.GetValidInput("enter your last name", Validator.IsNotEmpty);
    }
    
    private static Gender GetGender()
    {
        ConsoleUtil.PrintEnumOptions<Gender>();
        return (Gender) Convert.ToInt32(ConsoleUtil.GetValidInput("choose one of the genders listed above", Validator.IsValidOption<Gender>));
    }
    
    private static string GetNationalCode()
    {
        return ConsoleUtil.GetValidInput("enter your national code", Validator.IsValidNationalCode);
    }
    
    private static string GetAddress()
    {
        return ConsoleUtil.GetValidInput("enter your address", Validator.IsNotEmpty);
    }
}