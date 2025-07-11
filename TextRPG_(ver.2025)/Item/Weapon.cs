using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG__ver._2025_
{
    public class Weapon : Item
    {
        // 초기 장착 장비때문에 오버로딩
        public Weapon(string name, int atk, string desc, int gold)
        {
            Name = name;
            Description = desc;
            Value = atk;
            Price = gold;
        }
        public Weapon(string name, int atk, string desc, int gold, bool isEq)
        {
            Name = name;
            Description = desc;
            Value = atk;
            Price = gold;
            IsEquipped = isEq; // 장착 여부 설정
        }
    }
}
