namespace C_Sharp7Features.Interfaces
{
    public interface IRun
    {
        void Run();
    }

    public interface IRun<in TRunner>
    {
        void Run(TRunner runner);
    }
}