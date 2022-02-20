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

using Cake.Common.Tools.DotNet.Build;
using Cake.Common.Tools.DotNet.MSBuild;
using Cake.Common.Tools.DotNet;
using Cake.Common.Tools.DotNetCore.MSBuild;
using Cake.Common;
using Cake.Frosting;

namespace ClassCalendarMaker.Build.Tasks;

[TaskName("Build")]
[IsDependentOn(typeof(CleanTask))]
public sealed class BuildTask : FrostingTask<BuildContext>
{
    public override void Run(BuildContext context)
    {
        foreach (var c in context.Component)
        {
            context.DotNetBuild($"../ClassCalendarMaker.{c}/ClassCalendarMaker.{c}.csproj", new DotNetBuildSettings
            {
                Configuration = context.MsBuildConfiguration,
                NoIncremental = context.HasArgument("rebuild"),
                Framework = context.Framework,
                MSBuildSettings = new DotNetMSBuildSettings()
                    .TreatAllWarningsAs(MSBuildTreatAllWarningsAs.Error)
            });
        }
    }
}
