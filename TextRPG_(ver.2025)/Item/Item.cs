using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG__ver._2025_
{
    public abstract class Item
    {
        public string Name { get; protected set; } = "";
        public string Description { get; protected set; } = "";
        public int Value { get; protected set; }
        public bool IsEquipped { get; set; } = false; // 장착 여부
        public int Price { get; protected set; }
        public bool IsSold { get; set; }  // 상점에서 구매 완료했는지 표시
    }
}
