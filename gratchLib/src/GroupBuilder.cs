using gratch.Library.Arrangement;

namespace gratch.Library
{
    public class GroupBuilder
    {
        protected Group result = new(string.Empty);
        public bool IsComplete => !string.IsNullOrWhiteSpace(result?.Name);

        public GroupBuilder Reset()
        {
            result = new(string.Empty);
            return this;
        }

        public Group? GetResult() => IsComplete ? result : null;
        

        public GroupBuilder Name(string name)
        {
            result.Name = name;
            return this;
        }

        public GroupBuilder ArrangementType(EArrangementType type)
        {
            result.Arrangement = type switch
                {
                    EArrangementType.DontArrange => new BaseArrangement(),
                    EArrangementType.OneByOne => new OneByOneArrangement(),
                    _ => throw new ArgumentOutOfRangeException()
                };
            return this;
        }
    }

    public enum EArrangementType 
        {
            DontArrange,
            OneByOne
        }
}