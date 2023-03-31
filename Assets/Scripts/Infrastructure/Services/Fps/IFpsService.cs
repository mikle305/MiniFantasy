namespace Infrastructure.Services
{
    public interface IFpsService
    {
        public int CalculateFps();
        
        public void SetTargetFps(int fps);
        
        public void SetTargetFpsUnlimited();
    }
}