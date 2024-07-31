using WhatTheTea.Gratch.Models;

namespace WhatTheTea.Gratch.Core;

public interface IArranger
{
    void ArrangeMany(IEnumerable<Person> people);
}