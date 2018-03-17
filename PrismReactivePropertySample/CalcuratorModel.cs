using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Prism.Mvvm;

namespace PrismReactivePropertySample
{
    class CalcuratorModel : BindableBase
    {
        private double _x;
        private double _y;

        public double X
        {
            get => _x;
            set => SetProperty(ref _x, value);
        }

        public double Y
        {
            get => _y;
            set => SetProperty(ref _y, value);
        }

        public CalcuratorModel(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public double Sum()
        {
            return X + Y;
        }
    }
}
