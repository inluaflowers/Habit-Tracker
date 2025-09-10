using SQLHandler;

var testDictionary = new Dictionary<string, string>()
{
    {"Sleeping", "TEXT"},
    {"NameOfMeasurement", "TEXT"},
    {"UnitOfMeasurement", "REAL"}
};

SqlHandler.CreateTable("SleepHabit", testDictionary);

/*
    ~~ (A1) Main Menu ~~
    Title = HabitTracker (Maybe Some Fancy Coloring?), Selection Prompt
    Type = SELECTION PROMPT
    Menu Choices = 
    {
        (A2) Create a New Habit Tracker
        (A3) View Habit Tracker
    }

    ~~ (2) Create New Habit Tracker
        ~ Habit Name
        ~ Unit of Measurement
            Create a unit of Measurement
            ~ MeasurementName
    View Habit Tracker
        ~~ From Table Habits ~~
        ~ Sleeping
        ~ Eating
        ~ Coding
        ~ Hydration

    ~~ Tables ~~
    Habits
        - HabitId INTEGER PRIMARY KEY AUTOINCREMENT
        - HabitName TEXT
    
    HabitID     HabitName
    1           Sleeping
    2           Eating
    3           Coding
    4           Hydration
    
    Measurements
        - MeasurementId INTEGER PRIMARY KEY AUTOINCREMENT
        - MeasurementName TEXT
        - MeasurementUnit TEXT
        - NeedsConversion BOOL
        - ConvertTo TEXT NULLABLE
        - ConversionId INTEGER NULLABLE
            ~ FOREIGN KEY (ConversionId) REFERENCES Measurements(MeasurementId)
        - ConversionRation DECIMAL(2,1)

    MeasurementId   MeasurementName     MeasurementUnit     NeedsConversion     ConvertTo       ConversionId    ConversionRatio     
    1               Minutes             Decimal(5,2)        FALSE               NULL            NULL            NULL
    2               Hours               DECIMAL(3, 1)       TRUE                Minutes         1               60.0            
    3               Calories            INTEGER             FALSE               NULL            NULL            NULL
    4               Ounces              INTEGER             FALSE               NULL            NULL            NULL
    5               Glasses             INTEGER             TRUE                Ounces          4               8.0
    6               Bottles             DECIMAL(1, 1)       TRUE                Ounces          4               16.0
    7               Large Bottles       DECIMAL(1, 1)       TRUE                Ounces          4               32.0
    
 */