using EmergencyCenter.Records;
using EmergencyCenter.Services;
using EmergencyCenter.Users;
using EmergencyCenter.Utils;

namespace EmergencyCenter.App;

public class Operator {
    private RecordList RecordList { get; }

    public Operator()
    {
        RecordList = new RecordList();
    }
    
    private static void ShowOptions<T>() where T : struct, IConvertible
    {
        ConsoleUtil.PrintEnumOptions<T>();
    }

    private static T GetRequestedOption<T>()
    {
        return (T)(object) Convert.ToInt32(ConsoleUtil.GetValidInput("choose one of the options listed above", Validator.IsValidOption<T>));
    }

    private void HandleMainResponse(MainOption chosenOption)
    {
        switch (chosenOption)
        {
            case MainOption.Services:
                HandleServiceRequest();
                break;
            case MainOption.Records:
                HandleRecordRequest();
                break;
            default:
                throw new InvalidOperationException("Invalid option.");
        }
    }
    
    private void HandleRecordResponse(RecordOption chosenOption)
    {
        switch (chosenOption)
        {
            case RecordOption.All:
                this.RecordList.ShowAllRecords();
                break;
            case RecordOption.FireService:
                Console.WriteLine("todo");
                break;
            case RecordOption.MedicalService:
                Console.WriteLine("todo");
                break;
            case RecordOption.PoliceServiceForMale:
                Console.WriteLine("todo");
                break;
            case RecordOption.PoliceServiceForFemale:
                Console.WriteLine("todo");
                break;
            default:
                throw new InvalidOperationException("Invalid option.");
        }
    }
    
    private void HandleServiceRequest()
    {
        var user = UserGenerator.GetUser();
        ShowOptions<ServiceOption>();
        var chosenOption = GetRequestedOption<ServiceOption>();
        this.RecordList.AddRecord(user, chosenOption);
        Console.WriteLine("Our forces will be sent to the place immediately.");
        Start();
    }
    
    private void HandleRecordRequest()
    {
        ShowOptions<RecordOption>();
        var chosenOption = GetRequestedOption<RecordOption>();
        HandleRecordResponse(chosenOption);
        Start();
    }

    public void Start()
    {
        ShowOptions<MainOption>();
        var chosenOption = GetRequestedOption<MainOption>();
        HandleMainResponse(chosenOption);
    }
}