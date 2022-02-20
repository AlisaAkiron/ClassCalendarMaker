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

using System.Text.Json.Serialization;
using ClassCalendarMaker.Core.Convertor;

namespace ClassCalendarMaker.Core.Model;

/// <summary>
/// Represent class time, one class can have multiple class time
/// </summary>
public class ClassTimeModel
{
    /// <summary>
    /// Which day the class begin
    /// </summary>
    [JsonPropertyName("day_of_week")]
    [JsonConverter(typeof(DayOfWeekJsonConvertor))]
    public DayOfWeek DayOfWeek { get; set; }

    /// <summary>
    /// Start week
    /// </summary>
    [JsonPropertyName("start_week")]
    public uint StartWeek { get; set; }

    /// <summary>
    /// End week
    /// </summary>
    [JsonPropertyName("end_week")]
    public uint EndWeek { get; set; }

    /// <summary>
    /// Repeat week interval
    /// </summary>
    [JsonPropertyName("week_interval")]
    public uint WeekInterval { get; set; }

    /// <summary>
    /// Class start time
    /// </summary>
    [JsonPropertyName("start_time")]
    [JsonConverter(typeof(TimeOnlyJsonConvertor))]
    public TimeOnly StartTime { get; set; }

    /// <summary>
    /// Class end time
    /// </summary>
    [JsonPropertyName("end_time")]
    [JsonConverter(typeof(TimeOnlyJsonConvertor))]
    public TimeOnly EndTime { get; set; }

    /// <summary>
    /// Classroom
    /// </summary>
    [JsonPropertyName("classroom")]
    public string Classroom { get; set; }
}
