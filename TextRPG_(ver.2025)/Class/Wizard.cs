using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG__ver._2025_
{
    public class Wizard : Class
    {
        public Wizard(GameManager game) : base(game)
        {
            //클래스 이름
            Name = "마법사";
            MaxHp = 100;
            Level = 1;
            MaxAP = 10;
            MaxDP = 3;
            Gold = 1000;

            // 초기화
            CurHP = MaxHp;
            CurAP = MaxAP;
            CurDP = MaxDP;
            CurGold = Gold;
        }
    }
}
