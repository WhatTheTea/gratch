﻿using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace gratch_core
{
    public class Person : ICloneable
    {
        #region events
        internal static event PersonHandler PersonChanged;
        internal delegate void PersonHandler(object sender);
        #endregion

        private string _name;
        public string Name { get => _name; set => Rename(value); }
        internal ObservableCollection<DateTime> DutyDates { get; set; }

        public Person(string name)
        {
            _name = name;

            DutyDates.CollectionChanged += DutyDates_CollectionChanged;
        }

        private void DutyDates_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            PersonChanged.Invoke(this);
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
                    PersonChanged.Invoke(this);
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
