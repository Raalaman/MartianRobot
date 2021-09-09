using ApplicationCore;

namespace Infrastructure
{
    public interface IMartianRobotDataService : IAsyncOnlyGetRepository<MartianRobotInputDataDTO>
    { }
}
