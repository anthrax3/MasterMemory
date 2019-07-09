﻿using MasterMemory.Annotations;
using MessagePack;

namespace MasterMemory.Tests
{
    [MemoryTable("Sample"), MessagePackObject(true)]
    public class Sample
    {
        [PrimaryKey]
        [SecondaryKey(1)]
        [SecondaryKey(2)]
        [SecondaryKey(3)]
        public int Id { get; set; }
        [SecondaryKey(1)]
        [SecondaryKey(2)]
        [SecondaryKey(3)]
        [SecondaryKey(5), NonUnique]
        [SecondaryKey(6, 1), NonUnique]
        public int Age { get; set; }
        [SecondaryKey(0)]
        [SecondaryKey(1)]
        [SecondaryKey(3)]
        [SecondaryKey(4), NonUnique]
        [SecondaryKey(6, 0), NonUnique]
        public string FirstName { get; set; }
        [SecondaryKey(0)]
        [SecondaryKey(1)]
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{Id} {Age} {FirstName} {LastName}";
        }
    }
}