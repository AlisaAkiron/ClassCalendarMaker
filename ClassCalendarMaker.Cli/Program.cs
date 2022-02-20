// ClassCalendarMaker - Convert class scheduler to calendar ICS file
// Copyright (C) 2021 Liam Sho and Contributors
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, 
// or any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY

using System.CommandLine;
using System.CommandLine.Parsing;
using System.Text.Json;
using ClassCalendarMaker.Core;
using ClassCalendarMaker.Core.Model;

var classesJsonFile = new Option<FileInfo>(
    new string[]
    {
        "--classes",
        "-c"
    },
    "Classes json definition file");

var outputIcsFile = new Option<FileInfo>(
    new string[]
    {
        "--output",
        "-o"
    },
    "Output ics file");

var firstMonday = new Option<string>(
    new string[]
    {
        "--first-monday",
        "-fm"
    },
    "First monday date string in yyyy-MM-dd format, eg: 2022-2-21");

var rootCommand = new RootCommand
{
    classesJsonFile,
    outputIcsFile,
    firstMonday
};

rootCommand.SetHandler((FileInfo i, FileInfo o, string fm) =>
{
    if (i is null || o is null || fm is null)
    {
        Console.Error.WriteLine("Invalid arguments, run with argument \"-?\" for help.");
        return;
    }

    if (i.Exists is false)
    {
        Console.Error.WriteLine("Input JSON file is not exist");
        return;
    }

    if (o.Exists)
    {
        Console.WriteLine("Output file exist, it will be replaced");
        o.Delete();
    }

    try
    {
        var jsonString = File.ReadAllText(i.FullName);
        var classes = JsonSerializer.Deserialize<List<ClassModel>>(jsonString);
        if (classes is null)
        {
            throw new JsonException("Can't deserilize json string");
        }

        var fmObj = DateOnly.Parse(fm);

        var ics = ClassCalendarMaker.Core.ClassCalendarMaker.Make(classes, new ClassCalendarMakerOptions
        {
            FirstMonday = fmObj,
            TimeZone = TimeZoneInfo.Local
        });

        File.WriteAllText(o.FullName, ics);
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine(ex);
        return;
    };
}, classesJsonFile, outputIcsFile, firstMonday);

return rootCommand.Invoke(args);
