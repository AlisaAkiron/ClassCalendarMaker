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

using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassCalendarMaker.Core.Convertor;

internal class TimeOnlyJsonConvertor : JsonConverter<TimeOnly>
{
    public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var timeString = reader.GetString();

        try
        {
            var splitTimeString = timeString.Split(":");

            if (splitTimeString.Length != 3)
            {
                throw new Exception();
            }

            var hh = Convert.ToInt32(splitTimeString[0]);
            var mm = Convert.ToInt32(splitTimeString[1]);
            var ss = Convert.ToInt32(splitTimeString[2]);

            return new TimeOnly(hh, mm, ss);
        }
        catch (Exception)
        {
            throw new JsonException($"Can't serilize {timeString} to System.TimeOnly");
        }
    }

    public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
    {
        var str = value.ToLongTimeString();
        writer.WriteStringValue(str);
    }
}
