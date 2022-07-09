#define LOGGING
#undef LOGGING

using gratchLib.Entities;

using Xunit.Abstractions;

namespace gratchLib_tests.BusinessLayer
{
    public class ScheduleTests
    {
        private readonly ITestOutputHelper output;

        public ScheduleTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ScheduleCreation()
        {
            var Date = new DateTime(2022, 07, 06);
            var StartDate = new DateTime(2022, 07, 01);
            var EndDate = new DateTime(2022, 07, 31);

            var TestGroup = new Group("TestGroup");
            TestGroup.CreatePerson("TP1");
            TestGroup.CreatePerson("TP2");
            TestGroup.CreatePerson("TP3");

            var firstPerson = TestGroup.People.ElementAt(0);

            TestGroup.Calendar.StartDate = Date;

            var testSchedule = new Schedule(TestGroup, new DateTimeRange(StartDate, EndDate));
#if LOGGING
            output.WriteLine(testSchedule.ToString());
#endif
            Assert.True(testSchedule[StartDate] == firstPerson);
            Assert.True(testSchedule[EndDate] == firstPerson);
        }

    }
}
