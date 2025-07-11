using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG__ver._2025_
{
    public class Weapon : Item
    {
        public Weapon(string name, int atk, string desc, int gold)
        {
            Name = name;
            Description = desc;
            Value = atk;
            Price = gold;
        }
    }
}
