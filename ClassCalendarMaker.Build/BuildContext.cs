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

using Cake.Common;
using Cake.Core;
using Cake.Frosting;

namespace ClassCalendarMaker.Build;

public class BuildContext : FrostingContext
{
    public string MsBuildConfiguration { get; set; }
    public string PublishRid { get; set; }
    public string Framework { get; set; }
    public ICollection<string> Component { get; set; }

    public BuildContext(ICakeContext context) : base(context)
    {
        MsBuildConfiguration = context.Argument("configuration", "Release");
        PublishRid = context.Argument("rid", "portable");
        Framework = context.Argument("framework", "net6.0");
        Component = context.Arguments<string>("component", new string[] { "Core", "Cli" });
    }
}
