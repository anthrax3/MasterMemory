// <auto-generated />
using LiteDB;
using MasterMemory;
using MessagePack;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using TestPerfLiteDB;

namespace TestPerfLiteDB.Tables
{
   public sealed partial class TestDocTable : TableBase<TestDoc>
   {
        readonly Func<TestDoc, int> primaryIndexSelector;


        public TestDocTable(TestDoc[] sortedData)
            : base(sortedData)
        {
            this.primaryIndexSelector = x => x.id;
        }


        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public TestDoc FindByid(int key)
        {
            var lo = 0;
            var hi = data.Length - 1;
            while (lo <= hi)
            {
                var mid = (int)(((uint)hi + (uint)lo) >> 1);
                var selected = data[mid].id;
                var found = (selected < key) ? -1 : (selected > key) ? 1 : 0;
                if (found == 0) { return data[mid]; }
                if (found < 0) { lo = mid + 1; }
                else { hi = mid - 1; }
            }
            return default;
        }

        public TestDoc FindClosestByid(int key, bool selectLower = true)
        {
            return FindUniqueClosestCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<int>.Default, key, selectLower);
        }

        public RangeView<TestDoc> FindRangeByid(int min, int max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<int>.Default, min, max, ascendant);
        }

    }
}