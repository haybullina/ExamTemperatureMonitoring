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
        private string startTime = "";

        public Violation(string fishName, int tempMax, int time1, int tempMin, int time2, string data, string startTime)
        {
            this.tempMax = tempMax;
            this.time1 = time1;
            this.tempMin = tempMin;
            this.time2 = time2;
            this.data = data;
            this.startTime = startTime;
        }

        public Violation(string fishName, int tempMax, int time1, string data, string startTime, bool b)
        {
            this.tempMax = tempMax;
            this.time1 = time1;
            this.data = data;
            this.startTime = startTime;
        }

        public Violation(string fishName, int tempMin, int time2, string data, string startTime)
        {
            this.tempMax = tempMin;
            this.time1 = time2;
            this.data = data;
            this.startTime = startTime;
        }

        public string Pursing() 
        {
            string result = "     Время                Факт     Норма     Отклонение от нормы\n\n";
            int violationTimeMin = 0;
            int violationTimeMax = 0;
            string dateTime = startTime + ":00";

            if (tempMin != 0 || tempMax != 0)
            {
                List<int> temperatures = new List<int>();

                string[] temps = data.Split();
                foreach (string temp in temps)
                {
                    temperatures.Add(Convert.ToInt32(temp));
                }

                foreach (int temperature in temperatures)
                {
                    if (temperature > tempMax || temperature < tempMin)
                    {
                        result += $"{dateTime}      {temperature}          {(temperature < tempMin ? tempMin : tempMax)}                    " +
                            $"{((temperature < tempMin ? tempMin : tempMax) == tempMin ? (temperature - tempMin) : (tempMax - temperature))}\n";
                        dateTime = DateTime.Parse(startTime).AddMinutes(10).ToString();

                        if (temperature < tempMin) { violationTimeMin += 10; }
                        else { violationTimeMax += 10; }
                    }
                }

            }
            else if (tempMin == 0 && time2 == 0)
            {
                List<int> temperatures = new List<int>();

                string[] temps = data.Split();
                foreach (string temp in temps)
                {
                    temperatures.Add(Convert.ToInt32(temp));
                }

                foreach (int temperature in temperatures)
                {
                    if (temperature < tempMin)
                    {
                        result += $"      {dateTime}      {temperature}      {tempMin}       " + $"{tempMin - temperature}\n";
                        dateTime = DateTime.Parse(startTime).AddMinutes(10).ToString();

                        if (temperature < tempMin) { violationTimeMin += 10; }
                        else { violationTimeMax += 10; }
                    }
                }
            }

            else if (tempMax == 0 && time1 == 0)
            {
                List<int> temperatures = new List<int>();

                string[] temps = data.Split();
                foreach (string temp in temps)
                {
                    temperatures.Add(Convert.ToInt32(temp));
                }

                foreach (int temperature in temperatures)
                {
                    if (temperature < tempMin)
                    {
                        result += $"      {dateTime}      {temperature}      {tempMax}       " + $"{temperature - tempMax}\n";
                        dateTime = DateTime.Parse(startTime).AddMinutes(10).ToString();

                        if (temperature < tempMin) { violationTimeMin += 10; }
                        else { violationTimeMax += 10; }
                    }
                }
            }

            if (violationTimeMin > time2) 
            {
                result += $"\nПорог мин допустимой температуры превышен на {violationTimeMin} минут\n";
            }
            else if (violationTimeMax < time1) 
            {
                result += $"\nПорог макс допустимой температуры превышен на {violationTimeMax} минут";
            }

            return result;
        }

    }
}
