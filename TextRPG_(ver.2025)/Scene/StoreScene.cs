using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG__ver._2025_
{
    public class StoreScene : Scene
    {
        public StoreScene(GameManager game) : base(game)
        {
        }
        public override void Render()
        {
            var pc = gameManager.CurrentClass;
            int gold = pc.CurGold;

            DisplayItems();
            Print("◎상점◎", ConsoleColor.DarkYellow);
            Print("필요한 아이템을 얻을 수 있는 상점입니다. \n");
            Print("[보유 골드]\n");
            Print(gold, "G\n", ConsoleColor.DarkMagenta);
            Print("[아이템 목록]");
            for (int i = 0; i < DataManager.StoreItems.Count; i++)
            {
                string priceStr = DataManager.StoreItems[i].IsSold ? "구매완료" : $"{DataManager.StoreItems[i].Price} G";
                Print($"- {DataManager.StoreItems[i].Name}  |  {DataManager.StoreItems[i].Value}  |  {DataManager.StoreItems[i].Description}  |  {priceStr}");
            }

            Print(1, "아이템 구매");
            Print(0, "뒤로가기");
            Console.WriteLine("\n원하시는 행동을 입력해주세요");
            Console.Write(">>");
        }
        public override void Update()
        {
            int input;
            if (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("\n잘못 입력 하셨습니다.");
                Thread.Sleep(1000); // 1초 대기
                return;
            }

            if (input == 1)
            {
                Console.WriteLine("\ninfo : 아이템 구매하러 갑니다");
                gameManager.SwitchScene(SceneID.BuyItem);
                Thread.Sleep(1000);
                return;
            }
            if (input == 0)                 // 뒤로가기
            {
                Console.WriteLine("\ninfo : 마을로 돌아갑니다");
                gameManager.SwitchScene(SceneID.Inventory);
                Thread.Sleep(1000);
                return;
            }

        }
        public void DisplayItems()
        {
            if (DataManager.StoreItems.Count > 0) return;
            DataManager.StoreItems.AddRange(new Item[]
            {
                // 갑옷
               new Armor ("수련자 갑옷", 2, "얇은 가죽으로 만들어진 기본 방어구입니다.", 120),
               new Armor ("무쇠갑옷", 5, "튼튼한 무쇠 갑옷입니다.",   200),
               new Armor ("스파르타의 갑옷", 9, "스파르타 전사의 전설적 갑옷입니다.",  300),

               //무기
               new Weapon("낡은 검", 2, "쉽게 볼 수 있는 낡은 검입니다.", 100),
               new Weapon("청동 도끼", 5, "어디선가 쓰던 청동 도끼입니다.", 200),
               new Weapon("스파르타의 창", 7, "스파르타 전사들이 쓰던 전설의 창입니다.", 300)
            });
        }
     }
}
