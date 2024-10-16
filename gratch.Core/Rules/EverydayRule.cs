using WhatTheTea.Gratch.Abstractions;

namespace WhatTheTea.Gratch.Core.Rules;

internal sealed class EverydayRule : IRule
{
    public bool Evaluate(DateTimeOffset dateTime) => true;
}
