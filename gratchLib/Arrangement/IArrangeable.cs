// <copyright file = "IArrangeable.cs" company = "Digital Cloud Technologies">
// Copyright (c) Digital Cloud Technologies.All rights reserved.
// </copyright>

namespace gratch.Core.Arrangement;

public interface IArrangeable
{
    int Position { get; set; }
    bool IsArranged { get; }
}