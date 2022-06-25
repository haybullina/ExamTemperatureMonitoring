using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTemperatureMonitoring
{
    internal class Violation
    {
        private string fishName;
        private int tempMax;
        private int time1;
        private int tempMin = 0;
        private int time2 = 0;
        private string data;
        private string startTime;

        public Violation(string fishName, int tempMax, int time1, int tempMin, int time2, string data, string startTime)
        {
            this.tempMax = tempMax;
            this.time1 = time1;
            this.tempMin = tempMin;
            this.time2 = time2;
            this.data = data;
            this.startTime = startTime;
        }

        public Violation(string fishName, int tempMax, int time1, string data, string startTime)
        {
            this.tempMax = tempMax;
            this.time1 = time1;
            this.data = data;
            this.startTime = startTime;
        }

        public string Pursing() 
        {
            string result = "";

            if (tempMin != 0 || time2 != 0) 
            {
                List<int> temperature = new List<int>();

                string[] temps = data.Split();
                foreach (string temp in temps)
                {
                    temperature.Add(Convert.ToInt32(temp));
                }
                

            }

            return result;
        }

    }
}
