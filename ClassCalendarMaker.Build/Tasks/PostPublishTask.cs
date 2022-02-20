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

using System.IO.Compression;
using Cake.Frosting;

namespace ClassCalendarMaker.Build.Tasks;

[TaskName("PostPublish")]
[IsDependentOn(typeof(PublishTask))]
public class PostPublishTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        foreach (var c in context.Component)
        {
            ZipFile.CreateFromDirectory($"../publish/{c}",
                $"../publish/ClassCalendarMaker.{c}-{context.MsBuildConfiguration}-{context.Framework}-{context.PublishRid}.zip");
        }
    }
}
