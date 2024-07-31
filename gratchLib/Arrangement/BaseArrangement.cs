// <copyright file = "BaseArrangement.cs" company = "Digital Cloud Technologies">
// Copyright (c) Digital Cloud Technologies.All rights reserved.
// </copyright>

namespace gratch.Core.Arrangement;

public class BaseArrangement : IArrangement
{
    protected IArrangeableGroup? context;

    protected IArrangeableGroup? Context => context;
    public BaseArrangement()
    {

    }

    public BaseArrangement(IArrangeableGroup context)
    {
        SetContext(context);
    }

    public virtual void SetContext(IArrangeableGroup context)
    {
        this.context = context;
    }

    public virtual void Arrange(IArrangeable arrangeable)
    {
        _ = arrangeable ?? throw new ArgumentNullException(nameof(arrangeable));
    }
    public virtual void ArrangeTo(IArrangeable arrangeable, int position)
    {
        _ = arrangeable ?? throw new ArgumentNullException(nameof(arrangeable));
    }
    public virtual void ArrangeAll(EArrangementMode mode = EArrangementMode.All)
    {

    }

    public virtual void RemoveArrangement(IArrangeable arrangeable)
    {
        _ = arrangeable ?? throw new ArgumentNullException(nameof(arrangeable));
    }
}