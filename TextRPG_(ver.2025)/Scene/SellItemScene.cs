using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace TextRPG__ver._2025_
{
    public class SellItemScene : Scene
    {
        public SellItemScene(GameManager game) : base(game)
        {
           
        }

        public override void Render()
        {
            Print("◎상점 - 아이템 판매◎", ConsoleColor.DarkYellow);
            Print("필요한 아이템을 얻을 수도 팔수도 있는 상점입니다. \n");
            Print("[보유 골드]\n");
            GoldInfo(gameManager.CurrentClass.CurGold, "G\n", ConsoleColor.DarkMagenta);
            Print("[아이템 목록]\n");
            Print("[장착상태]  |  [이름]  |  [공격력, 방어력]  |  [설명]\n");
            for (int i = 0; i < DataManager.Inventory.Count; i++)
            {
                string equipTag = DataManager.Inventory[i].IsEquipped ? "[E]" : "   ";
                int sellPrice = DataManager.Inventory[i].Price * 85 / 100;
                Print(i + 1, $"{equipTag} | {DataManager.Inventory[i].Name}  |  {DataManager.Inventory[i].Value}  |  {DataManager.Inventory[i].Description} |  {sellPrice}\n");
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
                Console.WriteLine("\ninfo : 잘못입력 하셨습니다");
                Thread.Sleep(1000);
                return;
            }
            SellItem(input);
        }
        public void SellItem(int input)
        {
            var pc = gameManager.CurrentClass;
            int idx = input - 1;
            var Invenit = DataManager.Inventory[idx];

           

           Invenit.IsSold = false;
           DataManager.StoreItems.Add(Invenit); // 판매한 아이템을 상점에 추가
           DataManager.Inventory.RemoveAt(idx); // 인벤토리에서 아이템 제거
            Console.WriteLine($"\ninfo : [{Invenit.Name}] 아이템을 판매했습니다.");
           pc.CurGold += Invenit.Price * 85 / 100;
           Thread.Sleep(1000);
        }
    }
}
