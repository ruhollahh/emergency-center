using System.Text.RegularExpressions;

namespace EmergencyCenter.Utils;

public static class Validator
{
    public static bool IsNumeric(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || int.TryParse(value, out _))
        {
            throw new InvalidOperationException("Age must be a number.");
        }

        return true;
    }
    
    public static bool IsNotEmpty(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidOperationException("Name can't be empty or consist only of white-spaces.");
        }

        return true;
    }

    public static bool IsValidOption<T>(string option)
    {
        if (string.IsNullOrWhiteSpace(option) || !int.TryParse(option, out var numericOption) || !Enum.IsDefined(typeof(T), numericOption))
        {
            throw new InvalidOperationException("Invalid option.");
        }

        return true;
    }

    public static bool IsValidNationalCode(string nationalCode)
    {
        var regex = new Regex(@"\d{10}");
        var allDigitEqual = new[]{"0000000000","1111111111","2222222222","3333333333","4444444444","5555555555","6666666666","7777777777","8888888888","9999999999"};
        
        if (string.IsNullOrWhiteSpace(nationalCode) || nationalCode.Length != 10 || !regex.IsMatch(nationalCode) || allDigitEqual.Contains(nationalCode))
        {
            throw new InvalidOperationException("National Code is not valid.");
        }

        var chArray = nationalCode.ToCharArray();
        var num0 = Convert.ToInt32(chArray[0].ToString())*10;
        var num2 = Convert.ToInt32(chArray[1].ToString())*9;
        var num3 = Convert.ToInt32(chArray[2].ToString())*8;
        var num4 = Convert.ToInt32(chArray[3].ToString())*7;
        var num5 = Convert.ToInt32(chArray[4].ToString())*6;
        var num6 = Convert.ToInt32(chArray[5].ToString())*5;
        var num7 = Convert.ToInt32(chArray[6].ToString())*4;
        var num8 = Convert.ToInt32(chArray[7].ToString())*3;
        var num9 = Convert.ToInt32(chArray[8].ToString())*2;
        var a = Convert.ToInt32(chArray[9].ToString());

        var b = (((((((num0 + num2) + num3) + num4) + num5) + num6) + num7) + num8) + num9;
        var c = b%11;

        if (!(((c < 2) && (a == c)) || ((c >= 2) && ((11 - c) == a))))
        {
            throw new InvalidOperationException("National Code is not valid.");
        }

        return true;
    }
}