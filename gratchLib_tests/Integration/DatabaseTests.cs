using gratchLib.DAL;
using gratchLib.Entities;

namespace gratchLib_tests.Integration
{
    public class DatabaseTests : IDisposable
    {
        public SqliteContext context;
        public Group TestGroup;

        public DatabaseTests()
        {
            context = new();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            TestGroup = new("Group1");
            TestGroup.AddPerson("Pers1");
            TestGroup.AddPerson("Pers2");
            TestGroup.AddPerson("Pers3");
            TestGroup.Calendar.AddDayOff(DayOfWeek.Monday);
            TestGroup.Calendar.AddDayOff(DayOfWeek.Tuesday);
            TestGroup.Calendar.AddHoliday(new Holiday(DateTime.Today, "Holiday1"));
            TestGroup.Calendar.StartDate = DateTime.Today;
        }

        [Fact]
        public void Insert()
        {
            context.Groups.Add(TestGroup);
            context.SaveChanges();
            Assert.True(TestGroup == context.Groups.Single());
        }

        public void Dispose()
        {
            context.Dispose();
            context = null;
        }
    }
}