using Avalonia.Controls.Primitives;
using Avalonia.Threading;
using CefGlue.Avalonia;
using System;
using System.IO;
using System.Reactive.Linq;

namespace Avalonia.Summernote
{
    public class Summernote : TemplatedControl
    {
        protected override void OnTemplateApplied(TemplateAppliedEventArgs e)
        {
            var browser = e.NameScope.Find("PART_browser") as AvaloniaCefBrowser;

            if (browser != null)
            {
                var location = System.Reflection.Assembly.GetEntryAssembly().Location;
                var directory = System.IO.Path.GetDirectoryName(location);

                browser.StartUrl = $"file:///{Path.Combine(location, directory, "SummerNote").Replace("\\", "/")}/editor.html";

                Observable.FromEventPattern(browser, nameof(browser.KeyUp)).Throttle(TimeSpan.FromMilliseconds(200)).ObserveOn(AvaloniaScheduler.Instance).Subscribe(async o =>
                {
                    var text = await browser.ExecuteScriptAsync("$('#summernote').summernote('code');");
                    
                    SourceCode = text;
                });
            }
        }

        public static readonly AvaloniaProperty<string> SourceCodeProperty = AvaloniaProperty.Register<Summernote, string>(nameof(SourceCode), null, false, Data.BindingMode.TwoWay);

        public string SourceCode
        {
            get { return GetValue(SourceCodeProperty); }
            set { SetValue(SourceCodeProperty, value); }
        }
    }
}
