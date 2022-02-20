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

namespace ClassCalendarMaker.Core;

/// <summary>
/// Make options
/// </summary>
/// <remarks>
/// Available template markers:
///     1. {Name} - ClassModel.Name
///     2. {Classroom} - ClassModel.Classroom
///     3. {Teacher} - ClassModel.TeacherName
///     4. {StartWeek} - ClassTimeModel.StartWeek
///     5. {EndWeek} - ClassTimeModel.EndWeek
/// </remarks>
public class ClassCalendarMakerOptions
{
    /// <summary>
    /// The date of the first monday in the semester
    /// </summary>
    public DateOnly FirstMonday { get; set; } = new DateOnly();

    /// <summary>
    /// Timezone
    /// </summary>
    public TimeZoneInfo TimeZone { get; set; } = TimeZoneInfo.Local;
}
