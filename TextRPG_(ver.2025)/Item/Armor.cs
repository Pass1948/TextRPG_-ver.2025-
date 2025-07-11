using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG__ver._2025_
{
    public class Armor : Item
    {
        // 초기 장착 장비때문에 오버로딩
        public Armor(string name, int Def, string desc, int gold)
        {
            Name = name;
            Description = desc;
            Value = Def;
            Price = gold;
        }
        public Armor(string name, int Def, string desc, int gold, bool IsEq)
        {
            Name = name;
            Description = desc;
            Value = Def;
            Price = gold;
            IsEquipped = IsEq;
        }
    }
}
