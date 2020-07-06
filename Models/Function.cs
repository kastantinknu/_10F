using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace View.UI.Models
{
    public abstract class Function : INotifyPropertyChanged
    {
        private bool _flag = false;
        public bool Flag
        {
            get { return _flag; }
            set => SetAndRaisePropertyChanged(ref _flag, value);
        }

        private double _amplitude = 1;
        public double Amplitude
        {
            get { return _amplitude; }
            set => SetAndRaisePropertyChanged(ref _amplitude, value);
        }
        public void Change_flag()
        {
            this.Flag = !Flag;
        }
        public void Change_amplitude(double a)
        {
            this.Amplitude = a;
        }
        public abstract LineSeries Funk();

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected virtual bool SetAndRaisePropertyChanged<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;
            storage = value;
            this.RaisePropertyChanged(propertyName);
            return true;
        }
    }
}
