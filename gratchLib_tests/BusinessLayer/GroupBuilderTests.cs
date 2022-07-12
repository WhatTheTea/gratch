

namespace gratchLib_tests.BusinessLayer
{
    public class GroupBuilderTests
    {
        [Fact]
        public void BasicCreation()
        {
            var expectedName = "TestGroup";
            var expectedTypeEnum = EArrangementType.DontArrange;
            var expectedType = typeof(gratchLib.Entities.Arrangement.BaseArrangement);

            var builder = new GroupBuilder();
            builder.Name(expectedName)
                   .ArrangementType(expectedTypeEnum);

            Assert.True(builder.GetResult().Name == expectedName);
            Assert.True(builder.GetResult().Arrangement.GetType() == expectedType);
        }
    }
}