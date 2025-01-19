namespace gratch.Arrangement.Rules.Common;

internal sealed class EverydayRule : IRule
{
    public bool Evaluate(DateTimeOffset dateTime) => true;
}
