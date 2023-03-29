namespace Infrastructure.Services.Fps
{
    public interface IFpsService : IService
    {
        public int CalculateFps();
        
        public void SetTargetFps(int fps);
        
        public void SetTargetFpsUnlimited();
    }
}