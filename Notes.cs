/*
    ~~ (A1) Main Menu ~~
    Title = LMer
    Subtitle = "Shh! Be vewy, vewy quiet.  We're hunting habits!"
    Type = SELECTION PROMPT
    Menu Choices = 
    {
        (B1) Create a New Habit Tracker
        (C1) View Habit Tracker
    }

    ~~ (A2) Create New Habit Tracker ~~
    Title = Create A Habit
    Type Selection Prompt
    Menu Choices = 
    {
        (B2.1) Habit Name
        (B2.2) Add Unit of Measuerement
        (B2.3) Edit or Delete Unit of Measuerment
            (B2.3.1) Edit
            (B2.3.2) Delete 
            (B2.3.2.1) Type Yes to Confirm)
    
    }

    
        ~ Instructions
            First, you will set a name for the habit.
            Then, you will be able to set custom unit of measurements for this habit.
            Each unit of measuerment will have its own name, numeric value type, 
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