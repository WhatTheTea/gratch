using SQLite;

using SQLiteNetExtensions.Attributes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gratchLib
{
    [Table("People")]
    public class PersonSQLite : Person
    {
        #region DBMapping
        [PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; }

        [ForeignKey(typeof(GroupSQLite))]
        public int GroupId { get; set; }

        [ManyToOne(nameof(GroupId),CascadeOperations = CascadeOperation.All)]
        public new Group Group => base.Group;

        [Column(nameof(Name)), NotNull]
        public new string Name { get => base.Name; set => base.Name = value; }

        [Column(nameof(Position))]
        public new int Position { get => base.Position; internal set => base.Position = value; }
        #endregion
        internal PersonSQLite(Group group, string name)
        {
            this.group = group;
            this.name = name;
            Position = 0;
        }
    }
}
