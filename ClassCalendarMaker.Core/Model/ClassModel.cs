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

namespace ClassCalendarMaker.Core.Model;

/// <summary>
/// Represent a class on scheduler
/// </summary>
public class ClassModel
{
    /// <summary>
    /// Class name
    /// </summary>
    [JsonPropertyName("class_name")]
    public string ClassName { get; set; }

    /// <summary>
    /// Class Id
    /// </summary>
    [JsonPropertyName("class_id")]
    public string ClassId { get; set; }

    /// <summary>
    /// Teacher or Professor name
    /// </summary>
    [JsonPropertyName("teacher_name")]
    public string TeacherName { get; set; }

    /// <summary>
    /// Class times
    /// </summary>
    [JsonPropertyName("class_times")]
    public List<ClassTimeModel> ClassTimes { get; set; }
}
