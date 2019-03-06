namespace PPR.CrossCutting.Interfaces
{
    public interface IServiceCreator
    {
        IIdentityUserService CreateIdentityUserService(string connectionString);
    }
}
