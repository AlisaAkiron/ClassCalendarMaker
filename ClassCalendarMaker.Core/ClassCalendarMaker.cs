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

using ClassCalendarMaker.Core.Model;
using Ical.Net;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;

namespace ClassCalendarMaker.Core;

/// <summary>
/// Main function class
/// </summary>
public static class ClassCalendarMaker
{
    /// <summary>
    /// Get iCalendar (RFC 5545) string
    /// </summary>
    /// <param name="classes">All classes</param>
    /// <param name="options">Make options</param>
    /// <returns>iCalendar (RFC 5545) string</returns>
    public static string Make(IEnumerable<ClassModel> classes, ClassCalendarMakerOptions options)
    {
        var calendar = new Calendar();
        calendar.AddTimeZone(options.TimeZone);

        foreach (var c in classes)
        {
            foreach (var t in c.ClassTimes)
            {
                var startDate = CalculateClassStartDate(options.FirstMonday, t.DayOfWeek, t.StartWeek);

                var startTime = startDate.Combine(t.StartTime);
                var endTime = startDate.Combine(t.EndTime);

                var patten = new RecurrencePattern
                {
                    Frequency = FrequencyType.Weekly,
                    Interval = (int)t.WeekInterval,
                    Count = (int)((t.EndWeek - t.StartWeek) / t.WeekInterval + 1)
                };

                var e = new CalendarEvent()
                {
                    Summary = $"{c.ClassName} [{c.TeacherName}]",
                    Location = t.Classroom,
                    Description = $"{c.ClassId} {c.ClassName} [{c.TeacherName}]",
                    Start = startTime,
                    End = endTime,
                    RecurrenceRules = new[] { patten }
                };

                calendar.Events.Add(e);
            }
        }

        var iCalSerializer = new CalendarSerializer();
        var serializedCalendar = iCalSerializer.SerializeToString(calendar);

        return serializedCalendar;
    }


    internal static DateOnly CalculateClassStartDate(DateOnly firstMonday, DayOfWeek classWeekday, uint startWeek)
    {
        var startWeekdayInFirstWeek = firstMonday.AddDays(classWeekday.ToInt());
        var realStartDate = startWeekdayInFirstWeek.AddDays(((int)startWeek - 1) * 7);
        return realStartDate;
    }

    internal static int ToInt(this DayOfWeek dayOfWeek) =>
        dayOfWeek switch
        {
            DayOfWeek.Monday => 1,
            DayOfWeek.Tuesday => 2,
            DayOfWeek.Wednesday => 3,
            DayOfWeek.Thursday => 4,
            DayOfWeek.Friday => 5,
            DayOfWeek.Saturday => 6,
            DayOfWeek.Sunday => -1,
            _ => throw new ArgumentOutOfRangeException(nameof(dayOfWeek), "Unknown day of week")
        };

    internal static CalDateTime Combine(this DateOnly date, TimeOnly time)
    {
        return new CalDateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
    }
}
