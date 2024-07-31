using WhatTheTea.Gratch.Models;

namespace WhatTheTea.Gratch.Core;

public class BasicArranger(TimeProvider timeProvider) : IArranger
{
    public void ArrangeMany(IEnumerable<Person> people) => throw new NotImplementedException();
}
