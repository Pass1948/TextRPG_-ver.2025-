using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG__ver._2025_
{
    public static class DataManager
    {
        public static List<Item> StoreItems { get; private set; } = null!;
        public static List<Item> Inventory { get; private set; } = null!;
        public static void Init()
        {
            StoreItems = new List<Item>();
            Inventory = new List<Item>();
        }
    }
}
