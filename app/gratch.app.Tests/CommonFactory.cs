using DynamicData;
using gratch.app.Services;
using gratch.Models;

using NSubstitute;

namespace gratch.app.Tests;
/// <summary>
/// A set of common simple factory methods. Most complex ones should be extracted to their own classes
/// </summary>
public static class CommonFactory
{
    public static Group CreateTestGroup(string name = "test") =>
        new() { Id = "test", Name = name, BaseDateTime = DateTime.Now };

    public static IGroupManager CreateGroupManagerSubstitute(params Group[] groups)
    {
        var groupProvider = Substitute.For<IGroupManager>();
        var groupCache = new SourceCache<Group, string>(x => x.Id);
        groupCache.AddOrUpdate(groups);
        groupProvider.Groups.Returns(groupCache);

        return groupProvider;
    }
}
