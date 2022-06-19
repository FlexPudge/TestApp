using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestApp
{
    public class AnalyzerChannel : INotifyPropertyChanged
    {
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
        private int? idAnalyzer;
        public int? Idanalyzer
        {
            get => idAnalyzer;
            set
            {
                idAnalyzer = value;
                OnPropertyChanged();
            }
        }
        private int? idChannel;
        public int? Idchannel
        {
            get => idChannel;
            set
            {
                idChannel = value;
                OnPropertyChanged();
            }
        }
        public virtual Analyzer IdanalyzerNavigation { get; set; }
        public virtual Channel IdchannelNavigation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string s = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(s));
        }
    }
}
