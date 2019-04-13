namespace Com.Lepecki.Playground.Camlc.Api.Configuration
{
    public interface IConfigurator<in T>
    {
        void Configure(T options);
    }
}
