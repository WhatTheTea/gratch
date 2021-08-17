﻿using System;
using System.Collections.Generic;
using System.Linq;

//[assembly: InternalsVisibleTo("gratch_core_tests")]

namespace gratch_core
{
    public class Person
    {
        private string name;
        public string Name { get => name; set => Rename(value); }
        public List<DateTime> DutyDates { get; internal set; }

        public Person(string name)
        {
            this.name = name;
        }

        public void Rename(string name)
        {
            foreach(var group in Group.AllInstances)
            {
                bool personExists = group.Where(person => person.Name == Name).Any();// Select group, where this person is
                bool renameExists = group.Where(reperson => reperson.Name == name).Any();
                if (personExists && !renameExists) 
                {
                    this.name = name;
                }
            }
        }
    }
}
