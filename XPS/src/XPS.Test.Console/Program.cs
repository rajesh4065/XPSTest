using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace XPS.Test.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            // startup file
            new Startup(args);
        }

    }
}

