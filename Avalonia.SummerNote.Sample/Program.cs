using Avalonia;
using CefGlue.Avalonia;

namespace Avalonia.Summernote.Sample
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
