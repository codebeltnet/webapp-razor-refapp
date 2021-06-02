using Microsoft.Extensions.Hosting;
using Codebelt.Bootstrapper.Web;

namespace Codebelt.WebApp.Razor
{
    public class Program : WebProgram<Startup>
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
    }
}
