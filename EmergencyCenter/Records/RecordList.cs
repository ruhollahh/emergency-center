using EmergencyCenter.Services;
using EmergencyCenter.Users;

namespace EmergencyCenter.Records;

public class RecordList
{
    private List<Record> AllRecords { get;}

    public RecordList()
    {
        AllRecords = new List<Record>();
    }

    public void AddRecord(User user, ServiceOption service)
    {
        AllRecords.Add(new Record(user, service));
    }
    
    private static IEnumerable<string> FormattedRecord(List<Record> records)
    {
        foreach (var record in records)
        {
            yield return $"{record.User.NationalCode} -> {record.Service}";
        }
    }
    
    public void ShowAllRecords()
    {
        foreach (string formattedRecord in FormattedRecord(AllRecords))
        {
            Console.WriteLine(formattedRecord);
        }
    }

    public void ShowFireRecords()
    {
        List<Record> filteredRecords = AllRecords.FindAll(record => record.Service == ServiceOption.Fire);
        foreach (string formattedRecord in FormattedRecord(filteredRecords))
        {
            Console.WriteLine(formattedRecord);
        }
    }
    
    public void ShowMedicalRecords()
    {
        List<Record> filteredRecords = AllRecords.FindAll(record => record.Service == ServiceOption.ShortnessOfBreath);
        foreach (string formattedRecord in FormattedRecord(filteredRecords))
        {
            Console.WriteLine(formattedRecord);
        }
    }
    
    public void ShowPoliceForMaleRecords()
    {
        List<Record> filteredRecords = AllRecords.FindAll(record => record.Service == ServiceOption.Theft && record.User.Gender == Gender.Male);
        foreach (string formattedRecord in FormattedRecord(filteredRecords))
        {
            Console.WriteLine(formattedRecord);
        }
    }
    
    public void ShowPoliceForFemaleRecords()
    {
        List<Record> filteredRecords = AllRecords.FindAll(record => record.Service == ServiceOption.Theft && record.User.Gender == Gender.Female);
        foreach (string formattedRecord in FormattedRecord(filteredRecords))
        {
            Console.WriteLine(formattedRecord);
        }
    }
}