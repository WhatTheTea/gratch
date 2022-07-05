using gratchLib.DAL;
using gratchLib.Entities;

namespace gratchLib_tests.DataLayer
{
    public class BasicCRUD : IDisposable
    {
        public SqliteContext context;
        public Group TestGroup;

        public BasicCRUD()
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
        }

        [Fact]
        public void Insert()
        {
            context.Groups.Add(TestGroup);
            context.SaveChanges();
            Assert.True(TestGroup == context.Groups.Single());
        }
        [Fact]
        public void Read()
        {

        }
        [Fact]
        public void Update()
        {

        }
        [Fact]
        public void Remove()
        {

        }
        [Fact]
        public void Delete()
        {

        }
        public void Dispose()
        {
            context.Dispose();
            context = null;
        }
    }
}