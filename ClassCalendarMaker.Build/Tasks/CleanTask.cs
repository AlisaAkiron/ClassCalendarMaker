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

using Cake.Common.IO;
using Cake.Frosting;

namespace ClassCalendarMaker.Build.Tasks;

[TaskName("Clean")]
public class CleanTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        foreach (var c in context.Component)
        {
            context.CleanDirectory($"../ClassCalendarMaker.{c}/bin/{context.MsBuildConfiguration}");
        }
        context.CleanDirectory("../publish");
    }
}
