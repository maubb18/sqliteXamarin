using SQLite.Net.Interop;

namespace Sqlite2
{
    public interface IConfig
    {
        string DirectorioDB { get; }
        ISQLitePlatform Plataforma { get; }
    }
}
