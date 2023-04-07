using EmergencyCenter.Services;
using EmergencyCenter.Users;

namespace EmergencyCenter.Records;

public class Record
{
    public User User { get; }
    public ServiceOption Service { get; }

    public Record(User user, ServiceOption service)
    {
        User = user;
        Service = service;
    }
}