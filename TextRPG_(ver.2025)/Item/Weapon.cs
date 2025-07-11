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
        public Weapon(int type, string name, int atk, string desc, int gold)
        {
            Type = type;
            Name = name;
            Description = desc;
            Value = atk;
            Price = gold;
        }
        public Weapon(int type, string name, int atk, string desc, int gold, bool isEq)
        {
            Type = type; 
            Name = name;
            Description = desc;
            Value = atk;
            Price = gold;
            IsEquipped = isEq; // 장착 여부 설정
        }
    }
}
