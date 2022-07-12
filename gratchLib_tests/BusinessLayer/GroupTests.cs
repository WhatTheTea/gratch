using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using gratchLib.Entities;

namespace gratchLib_tests.BusinessLayer
{
    public class GroupTests
    {
        [Fact]
        public void RenameThrowsArgumentException()
        {
            var group = new Group("Group");
            group.WhenNameChanged.Subscribe(p => Assert.NotNull(p.newname));

            group.Name = "TestGroup";
            Assert.Throws<ArgumentException>(() => group.Rename(""));
        }

        public static IEnumerable<object[]?> ShiftPositionsAfterData => 
            new List<object[]?>
            {
                new object[] { new Person("P1"), null, null },
                new object[] { new Person("P1"), new Person("P2"), null },
                new object[] { new Person("P1"), new Person("P2"), new Person("P3") }   
            };

        [Theory]
        [MemberData(nameof(ShiftPositionsAfterData))]
        public void ShiftPositionsAfter(Person? p1, Person? p2, Person? p3)
        {
            var group = new GroupBuilder().Name("TestGroup")
                                          .ArrangementType(EArrangementType.OneByOne)
                                          .GetResult();
            var people = new List<Person?>() { p1, p2, p3 };

            foreach(var p in people)
            {
                if(p == null) continue;
                group.AddPerson(p);
            }
            
            group.Arrangement.RemoveArrangement(p1);

            Assert.True(p1.Position == 0);
            Assert.True(p2?.Position == 1 || p2 == null);
            Assert.True(p3?.Position == 2 || p3 == null);

            group.Arrangement.ArrangeTo(p1, 1);

            Assert.True(p1.Position == 1);
            Assert.True(p2?.Position == 2 || p2 == null);
            Assert.True(p3?.Position == 3 || p3 == null);
        }
    }

}
