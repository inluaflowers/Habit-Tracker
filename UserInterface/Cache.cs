using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface;
public class Cache
{
    public Dictionary<string, object> CacheDictionary = new Dictionary<string, object>();

    public Dictionary<string, object> NewHabitDictionary = new Dictionary<string, object>()
    {
        {"Habit Name", ""},
        {"Unit of Measurement 1", ""}
    };

    public Dictionary<string, float> ConversionDictionary = new Dictionary<string, float>();
    public int NumberOfMeasurements = 2;

}

