using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace PrismSampleApp1.Views
{
    /// <summary>
    /// Interaction logic for GameRecord
    /// </summary>
    public partial class GameRecord : UserControl
    {
        public GameRecord()
        {
            InitializeComponent();
            
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += GetCurrentTime;
            timer.Start();
        }

        private void GetCurrentTime(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            //return dt.ToString("yyyy/MM/dd HH:mm:ss");
            CurrentTime.Text = dt.ToString("yyyy/MM/dd HH:mm:ss");
            //CurrentTime.Text = dt.ToString("MM/dd HH:mm:ss");
        }
    }
}
