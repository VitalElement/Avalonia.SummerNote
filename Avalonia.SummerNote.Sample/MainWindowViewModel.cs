using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Avalonia.Summernote
{
    public class MainWindowViewModel : ReactiveObject
    {
        private string _source;
        public string Source
        {
            get { return _source; }
            set { this.RaiseAndSetIfChanged(ref _source, value); }
        }
    }
}
