using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DateTimeConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private long InitialDateTimeTicks = (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).Ticks;

        public MainWindow()
        {
            InitializeComponent();

            string tds = Boolean.FalseString;
        }

        private DateTime ConvertToDateTime(long value)
        {
            DateTime utcDateTime = new DateTime(value * 10000 + InitialDateTimeTicks, DateTimeKind.Utc);

            return (DateTime)utcDateTime;
        }

        private long TotalMillisecondsFrom1970( DateTime utcDateTime)
        {
            var interval = (utcDateTime - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;

            return (long)interval;
        }

        private void ConvertToDate(object sender, RoutedEventArgs e)
        {
            var fromData = long.Parse(fromLongData.Text);

            toDateTimeData.Text = ConvertToDateTime(fromData).ToString();
        }

        private void ConvertToLong(object sender, RoutedEventArgs e)
        {
            var fromData = DateTime.Parse( fromDateData.Text);

            toLongData.Text = TotalMillisecondsFrom1970(fromData).ToString();
        }
    }
}
