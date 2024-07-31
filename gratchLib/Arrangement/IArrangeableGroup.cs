// <copyright file = "IArrangeableGroup.cs" company = "Digital Cloud Technologies">
// Copyright (c) Digital Cloud Technologies.All rights reserved.
// </copyright>

namespace gratch.Core.Arrangement;

public interface IArrangeableGroup
{
    IArrangement Arrangement { get; set; }
    IEnumerable<IArrangeable> Arrangeables { get; }
    IEnumerable<IArrangeable> Arranged { get; }
}