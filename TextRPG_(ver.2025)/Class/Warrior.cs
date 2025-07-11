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
        public override void GiveStarterItems()
        {
            var ironArmor = new Armor("무쇠갑옷", 1, "전사의 기본적인 장비.", 10);
            var ironSword = new Weapon("쇠검", 6, "전사의 기본적인 무기", 10);

            // 아이템을 데이터 매니저의 인벤토리에 추가
            DataManager.Inventory.AddRange(new Item[]
            {
               ironArmor,
               ironSword,
            });
        }
    }
}
