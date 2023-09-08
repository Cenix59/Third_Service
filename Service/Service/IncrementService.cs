using System;
using System.ComponentModel;
using System.IO;
using System.ServiceProcess;
using System.Timers;

namespace IncrementService
{
    public class IncrementService : ServiceBase
    {
        private Timer timer;
        private int counter;
        private DateTime scheduledDateTime;

        public IncrementService()
        {
            this.ServiceName = "IncrementService";
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;

        }

        protected override void OnStart(string[] args)
        {
            counter = 0;

            scheduledDateTime = new DateTime(2023, 8, 29, 9, 10, 0); // Año, mes, día, hora, minuto, segundo

            string path = @"C:\Users\nicof\OneDrive\Escritorio\6to\Windows\Service\Increment.txt";
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            
            }

            TimeSpan initialInterval = scheduledDateTime - DateTime.Now;


            timer = new Timer();
            timer.Interval = initialInterval.TotalMilliseconds;
            timer.Elapsed += new ElapsedEventHandler(OnTimer);
            timer.Start();
        }

        protected override void OnStop()
        {
            timer.Stop();
        }

        private void OnTimer(object sender, ElapsedEventArgs e)
        {
            scheduledDateTime = scheduledDateTime.AddHours(1);
            TimeSpan interval = scheduledDateTime - DateTime.Now;
            timer.Interval = interval.TotalMilliseconds;

            counter++;

            string path = @"C:\Users\nicof\OneDrive\Escritorio\6to\Windows\Service\Increment.txt";
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(counter);
            }
        }
    }
}

