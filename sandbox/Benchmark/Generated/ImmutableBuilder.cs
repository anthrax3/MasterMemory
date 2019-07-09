﻿using MasterMemory;
using TestPerfLiteDB.Tables;

namespace TestPerfLiteDB
{
    public sealed class ImmutableBuilder : ImmutableBuilderBase
   {
        MemoryDatabase memory;

        public ImmutableBuilder(MemoryDatabase memory)
        {
            this.memory = memory;
        }

        public MemoryDatabase Build()
        {
            return memory;
        }

        public void ReplaceAll(System.Collections.Generic.IList<TestDoc> data)
        {
            var newData = CloneAndSortBy(data, x => x.id, System.Collections.Generic.Comparer<int>.Default);
            var table = new TestDocTable(newData);
            memory = new MemoryDatabase(
                table
            
            );
        }

        public void RemoveTestDoc(int[] keys)
        {
            var data = RemoveCore(memory.TestDocTable.GetRawDataUnsafe(), keys, x => x.id, System.Collections.Generic.Comparer<int>.Default);
            var newData = CloneAndSortBy(data, x => x.id, System.Collections.Generic.Comparer<int>.Default);
            var table = new TestDocTable(newData);
            memory = new MemoryDatabase(
                table
            
            );
        }

        public void Diff(TestDoc[] addOrReplaceData)
        {
            var data = DiffCore(memory.TestDocTable.GetRawDataUnsafe(), addOrReplaceData, x => x.id, System.Collections.Generic.Comparer<int>.Default);
            var newData = CloneAndSortBy(data, x => x.id, System.Collections.Generic.Comparer<int>.Default);
            var table = new TestDocTable(newData);
            memory = new MemoryDatabase(
                table
            
            );
        }

    }
}