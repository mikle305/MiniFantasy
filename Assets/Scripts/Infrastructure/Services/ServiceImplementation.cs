namespace Infrastructure.Services
{
    public static class ServiceImplementation<TService> where TService : IService
    {
        public static TService Instance { get; set; }
    }
}