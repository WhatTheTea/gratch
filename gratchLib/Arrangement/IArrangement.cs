// <copyright file = "IArrangement.cs" company = "Digital Cloud Technologies">
// Copyright (c) Digital Cloud Technologies.All rights reserved.
// </copyright>

namespace gratch.Core.Arrangement;

public interface IArrangement
{
    void ArrangeAll(EArrangementMode mode = EArrangementMode.All);
    void Arrange(IArrangeable arrangeable);
    void ArrangeTo(IArrangeable arrangeable, int position);
    void RemoveArrangement(IArrangeable arrangeable);
    void SetContext(IArrangeableGroup context);
}

public enum EArrangementMode
{
    All,
    Arranged
}