namespace Pvs.EasyflowExtensions.Dispatch.EasyLog
{
    public abstract class LogBase
    {
        protected readonly object lockObject = new object();
        public abstract void Write(string message);
    }
}
