using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestApp.Services;

namespace TestApp.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private List<Analyzer> analyzer;
        public List<Analyzer> Analyzer
        {
            get => analyzer;
            set
            {
                analyzer = value;
                OnPropertyChanged();
            }
        }
        private Analyzer selectedAnalyzer;
        public Analyzer SelectedAnalyzer
        {
            get => selectedAnalyzer;
            set
            {
                selectedAnalyzer = value;
                OnPropertyChanged();
                LoadDataChannel();
            }
        }
        private Channel selectedChannel;
        public Channel SelectedChannel
        {
            get => selectedChannel;
            set
            {
                selectedChannel = value;
                OnPropertyChanged();
                LoadDataChannel();
            }
        }
        private List<AnalyzerChannel> analyzerChannels;
        public List<AnalyzerChannel> AnalyzerChannels
        {
            get => analyzerChannels;
            set
            {
                analyzerChannels = value;
                OnPropertyChanged();
            }
        }
        public MainWindowViewModel()
        {
            LoadDataAnalyzer();
        }
        private async void LoadDataAnalyzer()
        {
            try
            {
                var content = await HttpRequest.GetListAsync<Analyzer>(App.Address + "Home/");
                Analyzer = content;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        private async void LoadDataChannel()
        {
            try
            {
                int id = SelectedAnalyzer.Id;
                if (id != 0)
                {
                    var content = await HttpRequest.GetListAsync<AnalyzerChannel>(App.Address + $"Home/{id}");
                    AnalyzerChannels = content;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        private void DeleteItem()
        {
            //int idAnalyzer = SelectedAnalyzer.Id;
            //int idChannel = SelectedChannel.Id;
            //if (idAnalyzer == 0)
            //{ 
            //}
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string s = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(s));
        }
    }
}
