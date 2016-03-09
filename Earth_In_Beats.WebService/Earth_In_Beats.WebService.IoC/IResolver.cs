namespace Earth_In_Beats.WebService.IoC
{
    public interface IResolver
    {
        T Resolve<T>();
    }
}