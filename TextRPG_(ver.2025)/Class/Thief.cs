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
        public override void GiveStarterItems()
        {
            // 아이템을 데이터 매니저의 인벤토리에 추가
            DataManager.Inventory.AddRange(new Item[]
            {
               new Armor(2, "가죽 갑옷", 2, "도적의 기본적인 장비", 10, true),
               new Weapon(2, "단검", 2, "도적의 기본적인 무기", 10, true),
            });
        }
    }
}
