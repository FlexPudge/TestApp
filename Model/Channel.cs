using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestApp
{
    public class Channel : INotifyPropertyChanged
    {
        public Channel()
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
        private int isHot;
        public int IsHot
        {
            get => isHot;
            set
            {
                isHot = value;
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
