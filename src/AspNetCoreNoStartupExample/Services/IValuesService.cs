namespace AspNetCoreNoStartupExample.Services;

public interface IValuesService
{
    IEnumerable<string> FindAll();

    string Find(int id);
}
