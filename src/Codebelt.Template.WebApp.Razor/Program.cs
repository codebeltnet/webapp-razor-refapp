using Codebelt.Bootstrapper.Web;
using Microsoft.Extensions.Hosting;

namespace Codebelt.Template.WebApp.Razor
{
    public class Program : WebProgram<Startup>
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
    }
}
