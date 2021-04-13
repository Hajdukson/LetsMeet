# Let's meet algorithm

The algorithm takes two workers on input, who had fixed appointments and returns possible meetings for them.

Example input: 
```C#
Meeting meeting = new Meeting(30); //sets duration of possible meetings
return new List<Worker>
{
    new Worker{
        Name = "Wojtek",
        WorkingHours = new WorkingHours(DateTime.Parse("09:00"), DateTime.Parse("19:55")),
        Meetings = new List<Meeting>
        {
            new Meeting(DateTime.Parse("09:00"), DateTime.Parse("10:30")),
            new Meeting(DateTime.Parse("12:00"), DateTime.Parse("13:00")),
            new Meeting(DateTime.Parse("16:00"), DateTime.Parse("18:00"))
        }
    },
    new Worker{
        Name = "Michał",
        WorkingHours = new WorkingHours(DateTime.Parse("10:00"), DateTime.Parse("18:30")),
        Meetings = new List<Meeting>
        {
            new Meeting(DateTime.Parse("10:00"), DateTime.Parse("11:30")),
            new Meeting(DateTime.Parse("12:30"), DateTime.Parse("14:30")),
            new Meeting(DateTime.Parse("14:30"), DateTime.Parse("15:00")),
            new Meeting(DateTime.Parse("16:00"), DateTime.Parse("17:00"))
        }
    },
};
```
Output should be:
```
Wojtek' s data
Working hours: [09:00 - 20:00]
[09:00 - 10: 30]
[12:00 - 13: 00]
[16:00 - 18: 00]
[18:30 - 19: 30]

Michał' s data
Working hours: [10:00 - 20:00]
[10:00 - 11:30]
[12:30 - 14:30]
[14:30 - 15:00]
[16:00 - 17:00]

Workers can meet at: [[11:30 - 12:00], [15:00 - 16:00], [18:00 - 18:30], [19:30 - 20:00]]
```