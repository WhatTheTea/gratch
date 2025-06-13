namespace gratch.Arrangement.Rules;

internal class RulesCollection() : List<IRule>, IRulesCollection
{
    public bool EvaluateFor(DateTime dateTime) =>
        this.Select(x => x.Evaluate(dateTime))
            .Aggregate(true, (res, val) => res && val);
}
