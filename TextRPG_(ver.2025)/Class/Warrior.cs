using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG__ver._2025_
{
    public class Warrior : Class
    {
        public Warrior(GameManager game) : base(game)
        {
            //클래스 이름
            Name = "전사";
            MaxHp = 200;
            Level = 1;
            MaxAP = 6;
            MaxDP = 10;
            Gold = 1000;

            // 초기화
            CurHP = MaxHp;
            CurAP = MaxAP;
            CurDP = MaxDP;
            CurGold = Gold;
        }
    }
}
