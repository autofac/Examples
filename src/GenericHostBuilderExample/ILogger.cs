using System.Threading.Tasks;

namespace GenericHostBuilderExample
{
    internal interface ILogger
    {
        Task Log(string value);
    }
}