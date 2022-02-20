# ClassCalendarMaker

This tool can help you make an ICS (iCalendar RFC 5545) file of your class scheduler which can be easily imported to Outlook or Apple Calendar.

## Build

Make sure you have install `.NET SDK 6.0.x`, if not, go to [Microsoft .NET Website](https://dotnet.microsoft.com/en-us/download/dotnet) and download it, then install it.

- On windows, run `./publish.ps1`.
- On Linux or macOS, run `./publish.sh`

The publish script can take some arguments.

```powershell
.\publish.ps1 --<option>=<value>
```

```shell
./publish.sh --<option>=<value>
```

Avaliable options:

- `--rid`: Runtime Identifier, see [Rid Catalog](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog) for more information. Default: `portable`
- `--configuration`: Compile profile, you can choose between `Release` and `Debug`. Default: `Release`
- `--framework`: Compile with specific .NET version. Default: `net-6.0`
- `--component`: Choose which component to publish. Default: `["Cli", "Core"]`

## Run Cli version

You need to run this application in command line.

- On Windows: `dotnet ClassCalendarMaker.Cli.dll -- <args>` or `.\ClassCalendarMaker.Cli.exe <args>`
- On Linux or macOS: `dotnet ClassCalendarMaker.Cli.dll -- <args>` or `./ClassCalendarMaker.Cli <args>`

### Args

- `-?`: Show helps
- `-c <classes>` or `--classes <classes>`: Classes json definition file path
- `-o <output>` or `--output <output>`: Output ICS file path, should end with .ics
- `-fm <first-monday>` or `--first-monday <first-monday>`: The first monday of this semester, should be in yyyy-MM-dd format

### Class json file

Take this as an example:

```json
[
  {
    "class_name": "Class Name HERE",
    "class_id": "Class ID HERE",
    "teacher_name": "Teacher or Professor Name HERE",
    "class_times": [
      {
        "classroom": "Classroom string, will fill the Location field in calendar",
        "day_of_week": 1,
        "start_week": 10,
        "end_week": 17,
        "week_interval": 1,
        "start_time": "10:00:00",
        "end_time": "11:35:00"
      },
      {
        "classroom": "Classroom string, will fill the Location field in calendar",
        "day_of_week": 2,
        "start_week": 1,
        "end_week": 14,
        "week_interval": 1,
        "start_time": "18:00:00",
        "end_time": "20:25:00"
      }
    ]
  },
  {
    "class_name": "Another Class",
    "class_id": "Another Class ID",
    "teacher_name": "Another Teacher or Professor Name",
    "class_times": [
      {
        "classroom": "Another Classroom",
        "day_of_week": 1,
        "start_week": 1,
        "end_week": 9,
        "week_interval": 1,
        "start_time": "13:30:00",
        "end_time": "17:05:00"
      }
    ]
  }
]
```

Explain:

- `day_of_week`: When is the class in a week, 1 for Monday, 7 for Sunday, etc.
- `start_week`: Which week is the time that this class start in this semester.
- `end_week`: Which week is the time that this class end in this semester.
- `week_interval`: If you have this class in every week, set to 1, and so on.

For example, in the above json string, `Another Class` will start from the 1st week of this semester to the 9th week on every Monday afternoon from 13:30:00 to 17:05:00.

## License

This project is licensed under [GNU GENERAL PUBLIC LICENSE Version 3 or later](./LICENSE)
