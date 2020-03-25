using System;
using System.Collections.Generic;
using System.IO;
using SmartSchool.Core.Entities;

namespace SmartSchool.TestConsole
{
    public class ImportController
    {
        const string Filename = "measurements.csv";

        /// <summary>
        /// Liefert die Messwerte mit den dazugehörigen Sensoren
        /// </summary>
        public static IEnumerable<Measurement> ReadFromCsv()
        {
            String[] Content = File.ReadAllLines(Path.GetFullPath(Filename));
            List<Measurement> measurements = new List<Measurement>();
            
            foreach (var line in Content)
            {
                String[] SeperatedLine = line.Split(",");
                Measurement m = new Measurement();
                Sensor s = new Sensor();
                m.Time = DateTime.Parse(SeperatedLine[0]+SeperatedLine[0]);
                s.Id = m.SensorId;
                s.Location = SeperatedLine[2];
                m.Sensor = s;
                m.Value = Double.Parse(SeperatedLine[3]);
                measurements.Add(m);
            }

            return measurements;
        }

    }
}
