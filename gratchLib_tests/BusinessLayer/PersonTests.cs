using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using gratchLib.Entities;

namespace gratchLib_tests.BusinessLayer
{
    public class PersonTests
    {
        [Fact]
        public void BasicCreation()
        {
            var testPersonName = "testperson";
            var testGroupName = "testgroup";

            var group = new Group(testGroupName);
            var person = new Person(testPersonName, group);

            Assert.Equal(testPersonName, person.Name);
            Assert.True(group == person.Group);
        }
    }
}
