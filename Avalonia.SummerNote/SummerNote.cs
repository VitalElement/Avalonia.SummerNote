using Avalonia.Controls.Primitives;
using CefGlue.Avalonia;
using System.IO;

namespace Avalonia.Summernote
{
    public class Summernote : TemplatedControl
    {
        protected override void OnTemplateApplied(TemplateAppliedEventArgs e)
        {
            var browser = e.NameScope.Find("PART_browser") as AvaloniaCefBrowser;
            
            if(browser != null)
            {
                var location = System.Reflection.Assembly.GetEntryAssembly().Location;
                var directory = System.IO.Path.GetDirectoryName(location);                

                browser.StartUrl = $"file:///{Path.Combine(location, directory, "SummerNote").Replace("\\","/")}/editor.html";
            }
        }
    }    
}
