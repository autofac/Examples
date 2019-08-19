using System.Collections.Generic;

namespace AspNetCore3Example.Services
{
    public interface IValuesService
    {
        IEnumerable<string> FindAll();

        string Find(int id);
    }
}