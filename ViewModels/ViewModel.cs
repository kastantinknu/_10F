using DevExpress.Mvvm;
using View.UI.Models;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace View.UI.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
        public PlotModel plotModel { get; set; }
        Plots _plot;

        private DelegateCommand<object> _checkBox2;
        public DelegateCommand<object> _CheckBox2
        {
            get
            {
                return _checkBox2 ??
                       (_checkBox2 = new DelegateCommand<object>(obj =>
                       {
                           MyFunction[Convert.ToInt32(obj)].Change_flag();
                           _plot._PlotModel.Series.Clear();
                           for (int i = 0; i < MyFunction.Count; i++)
                           {
                               if (MyFunction[i].Flag)
                               {
                                   _plot._PlotModel.Series.Add(MyFunction[i].Funk());
                               }
                           }
                           _plot._PlotModel.InvalidatePlot(true);
                       }));
            }
        }

        private DelegateCommand<object> _slider_cos2;
        public DelegateCommand<object> _Slider_cos2
        {
            get
            {
                return _slider_cos2 ??
                       (_slider_cos2 = new DelegateCommand<object>(obj =>
                       {
                           MyFunction[0].Change_amplitude(Math.Round(Convert.ToDouble(obj), 1));
                           _plot._PlotModel.Series.Clear();
                           for (int i = 0; i < MyFunction.Count; i++)
                           {
                               if (MyFunction[i].Flag)
                               {
                                   _plot._PlotModel.Series.Add(MyFunction[i].Funk());
                               }
                           }
                           _plot._PlotModel.InvalidatePlot(true);
                       }));
            }
        }

        private DelegateCommand<object> _slider_sin2;
        public DelegateCommand<object> _Slider_sin2
        {
            get
            {
                return _slider_sin2 ??
                       (_slider_sin2 = new DelegateCommand<object>(obj =>
                       {
                           MyFunction[1].Change_amplitude(Math.Round(Convert.ToDouble(obj), 1));
                           _plot._PlotModel.Series.Clear();

                           for (int i = 0; i < MyFunction.Count; i++)
                           {
                               if (MyFunction[i].Flag)
                               {
                                   _plot._PlotModel.Series.Add(MyFunction[i].Funk());
                               }
                           }


                           _plot._PlotModel.InvalidatePlot(true);
                       }));
            }
        }

        private DelegateCommand<object> _slider_tan2;
        public DelegateCommand<object> _Slider_tan2
        {
            get
            {
                return _slider_tan2 ??
                       (_slider_tan2 = new DelegateCommand<object>(obj =>
                       {
                           MyFunction[2].Change_amplitude(Math.Round(Convert.ToDouble(obj), 1));
                           _plot._PlotModel.Series.Clear();

                           for (int i = 0; i < MyFunction.Count; i++)
                           {
                               if (MyFunction[i].Flag)
                               {
                                   _plot._PlotModel.Series.Add(MyFunction[i].Funk());
                               }
                           }
                           _plot._PlotModel.InvalidatePlot(true);
                       }));
            }
        }

        private DelegateCommand<object> _slider_cot2;
        public DelegateCommand<object> _Slider_cot2
        {
            get
            {
                return _slider_cot2 ??
                       (_slider_cot2 = new DelegateCommand<object>(obj =>
                       {
                           MyFunction[3].Change_amplitude(Math.Round(Convert.ToDouble(obj), 1));
                           _plot._PlotModel.Series.Clear();

                           for (int i = 0; i < MyFunction.Count; i++)
                           {
                               if (MyFunction[i].Flag)
                               {
                                   _plot._PlotModel.Series.Add(MyFunction[i].Funk());
                               }
                           }
                           _plot._PlotModel.InvalidatePlot(true);
                       }));
            }
        }
        public double Amplitude_Cos => MyFunction[0].Amplitude;
        public double Amplitude_Sin => MyFunction[1].Amplitude;
        public double Amplitude_Tan => MyFunction[2].Amplitude;
        public double Amplitude_Cot => MyFunction[3].Amplitude;

        public List<Function> MyFunction = new List<Function>();

        public ViewModel()
        {
            _plot = new Plots();

            Cosinus cosinus = new Cosinus();
            cosinus.PropertyChanged += (s, e) => { RaisePropertyChanged("Amplitude_Cos"); };
            MyFunction.Add(cosinus);

            Sinus sinus = new Sinus();
            sinus.PropertyChanged += (s, e) => { RaisePropertyChanged("Amplitude_Sin"); };
            MyFunction.Add(sinus);

            Tangens tangens = new Tangens();
            tangens.PropertyChanged += (s, e) => { RaisePropertyChanged("Amplitude_Tan"); };
            MyFunction.Add(tangens);

            Cotangens cotangens = new Cotangens();
            cotangens.PropertyChanged += (s, e) => { RaisePropertyChanged("Amplitude_Cot"); };
            MyFunction.Add(cotangens);

            plotModel = new PlotModel();
            plotModel = _plot._PlotModel;
        }

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
