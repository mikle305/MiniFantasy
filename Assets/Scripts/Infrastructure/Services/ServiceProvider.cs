namespace Infrastructure.Services
{
    public class ServiceProvider
    {
        private static ServiceProvider _instance;

        public static ServiceProvider Container => _instance ??= new ServiceProvider();

        
        public void RegisterSingle<TService>(TService implementation) where TService : IService
        {
            ServiceImplementation<TService>.Instance = implementation;
        }

        public TService Resolve<TService>() where TService : IService
        {
            return ServiceImplementation<TService>.Instance;
        }
    }
}