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

using Cake.Common.Tools.DotNet.Publish;
using Cake.Common.Tools.DotNet;
using Cake.Common.Tools.DotNetCore.MSBuild;
using Cake.Frosting;
using ClassCalendarMaker.Build.Tasks;

namespace ClassCalendarMaker.Build;

[TaskName("Publish")]
[IsDependentOn(typeof(BuildTask))]
public sealed class PublishTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        foreach (var c in context.Component)
        {
            context.DotNetPublish($"../ClassCalendarMaker.{c}/ClassCalendarMaker.{c}.csproj", new DotNetPublishSettings
            {
                Configuration = context.MsBuildConfiguration,
                SelfContained = false,
                OutputDirectory = $"../publish/{c}",
                Framework = context.Framework,
                Runtime = context.PublishRid is "portable" ? null : context.PublishRid,
                MSBuildSettings = new DotNetCoreMSBuildSettings()
                    .TreatAllWarningsAs(MSBuildTreatAllWarningsAs.Error)
            });
        }
    }
}
