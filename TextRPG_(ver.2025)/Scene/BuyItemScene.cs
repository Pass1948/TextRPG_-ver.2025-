using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG__ver._2025_
{
    public class BuyItemScene : Scene
    {
        StoreScene store = new StoreScene(null); // 아이템 재랜더링 때문에 StoreScene 인스턴스 생성 
        public BuyItemScene(GameManager game) : base(game)
        {
        }
        public override void Render()
        {
            Print("◎상점 - 아이템 구매◎", ConsoleColor.DarkYellow);
            Print("필요한 아이템을 얻을 수도 팔수도 있는 상점입니다. \n");
            Print("[보유 골드]\n");
            GoldInfo(gameManager.CurrentClass.CurGold, "G\n", ConsoleColor.DarkMagenta);
            Print("[아이템 목록]");
            for (int i = 0; i < DataManager.StoreItems.Count; i++)
            {
                string priceStr = DataManager.StoreItems[i].IsSold ? "구매완료" : $"{DataManager.StoreItems[i].Price} G";
                Print(i + 1, $"- {DataManager.StoreItems[i].Name}  |  {DataManager.StoreItems[i].Value}  |  {DataManager.StoreItems[i].Description}  |  {priceStr}");
            }

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
                Thread.Sleep(1000); 
                return;
            }
            if (input == 0)
            {
                Console.WriteLine("\ninfo : 진열대로 다시 넘어갑니다");
                gameManager.SwitchScene(SceneID.Store);
                Thread.Sleep(1000);
                return;
            }
            int idx = input - 1;
            if (input < 0 || input > DataManager.Inventory.Count)
            {
                Console.WriteLine("\ninfo : 해당 번호의 아이템이 없습니다.");
                Thread.Sleep(1000);
                return;
            }
            BuyItem(input);
        }
        public void BuyItem(int input)
        {
            var pc = gameManager.CurrentClass;
            int idx = input - 1;
            var it = DataManager.StoreItems[idx];
            if (it.IsSold)
            {
                Console.WriteLine("\ninfo : 이미 구매한 아이템입니다.");
                Thread.Sleep(1000);
                return;
            }
            if (pc.CurGold < it.Price)
            {
                Console.WriteLine("\ninfo : 골드가 부족합니다");
                Console.WriteLine("info : 보유골드를 확인해주세요.");
                Thread.Sleep(1500);
                return;
            }
            else
            {
                it.IsSold = true;
                DataManager.Inventory.Add(it); // 구매한 아이템을 인벤토리에 추가
                Console.WriteLine($"\ninfo : [{it.Name}] 아이템을 구매했습니다.");
                pc.CurGold -= it.Price;
                store.DisplayItems();
                Thread.Sleep(1000);
            }
        }
    }
}
