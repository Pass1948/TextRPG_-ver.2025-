using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG__ver._2025_
{
    public class Thief : Class
    {
        public Thief(GameManager game) : base(game)
        {
            //클래스 이름
            Name = "도적";
            MaxHp = 130;
            Level = 1;
            MaxAP = 10;
            MaxDP = 5;
            Gold = 1000;

            // 초기화
            CurHP = MaxHp;
            CurAP = MaxAP;
            CurDP = MaxDP;
            CurGold = Gold;
        }
    }
}
