using System.Collections.Generic;

namespace AspNetCoreExample.Services;

public interface IValuesService
{
    IEnumerable<string> FindAll();

    string Find(int id);
}
