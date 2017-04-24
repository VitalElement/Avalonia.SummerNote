using Avalonia;
using CefGlue.Avalonia;

namespace ControlCatalog
{


    internal class Program
    {
        static void Main(string[] args)
        {
            AppBuilder.Configure<App>()
                .UseSkia().UsePlatformDetect().ConfigureCefGlue(args).Start<MainWindow>();
        }
    }
}
