using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestApp
{
    public class Analyzer : INotifyPropertyChanged
    {
        public Analyzer()
        {
            AnalyzerChannels = new HashSet<AnalyzerChannel>();
        }

        private int id;
        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        private string type;
        public string Type
        {
            get => type;
            set
            {
                type = value;
                OnPropertyChanged();
            }
        }

        private int? measureInterval;
        public int? MeasureInterval
        {
            get => measureInterval;
            set
            {
                measureInterval = value;
                OnPropertyChanged();
            }
        }

        public virtual ICollection<AnalyzerChannel> AnalyzerChannels { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string s = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(s));
        }
    }
}
