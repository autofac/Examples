using System.Collections.Generic;

namespace AspNetCore3NoStartupExample.Services
{
    public interface IValuesService
    {
        IEnumerable<string> FindAll();

        string Find(int id);
    }
}