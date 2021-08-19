﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace gratch_core
{
    public class Person : ICloneable
    {
        private string _name;
        public string Name { get => _name; set => Rename(value); }
        private string _groupName;
        public string GroupName
        {
            get => _groupName;
            internal set
            {
                _groupName = value;
            }
        }
        internal List<DateTime> DutyDates { get; set; }

        public Person(string name)
        {
            _name = name;
        }

        public void Rename(string name)
        {
            foreach (var group in Group.AllInstances)
            {
                bool personExists = group.Where(person => person.Name == Name).Any();// Select group, where this person is
                bool renameExists = group.Where(reperson => reperson.Name == name).Any();
                if (personExists && !renameExists)
                {
#if DEBUG
                    Console.WriteLine(DateTime.Now + $" | Person | Renaming {Name} to {name}");
#endif
                    _name = name;
                }
                else
                {
#if DEBUG
                    Console.WriteLine(DateTime.Now + $" | Person | Rename failed. Name: {Name}, Rename: {name}");
#endif
                }
            }
        }
        //ICloneable
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
