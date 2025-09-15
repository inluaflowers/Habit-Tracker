using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface;
public class Cache
{
    public Dictionary<string, object> BlankCacheDictionary = new Dictionary<string, object>();
    public Dictionary<string, object> CacheDictionary = new Dictionary<string, object>();

    public void ResetCache()
    {
        CacheDictionary = BlankCacheDictionary;
    }
}

public class AddHabitCache : Cache
{
    public AddHabitCache()
    {
        BlankCacheDictionary = new Dictionary<string, object>()
        {
            {"Habit Name", ""},
            {"Unit of Measurement", ""}
        };
        ResetCache();
    }
}
