using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG__ver._2025_
{
    public class InventoryScene : Scene
    {
        public InventoryScene(GameManager game) : base(game)
        {
        }
        public override void Render()
        {
            Print("◎인벤토리◎", ConsoleColor.DarkYellow);
            Print("보유 중인 아이템을 관리할 수 있습니다.\n");
            Print("[아이템 목록]\n");
            Print("[장착상태]  |  [이름]  |  [공격력, 방어력]  |  [설명]\n");
            for (int i = 0; i < DataManager.Inventory.Count; i++)
            {
                string equipTag = DataManager.Inventory[i].IsEquipped ? "[E]" : "   ";
                Print($"{equipTag} | {DataManager.Inventory[i].Name}  |  {DataManager.Inventory[i].Value}  |  {DataManager.Inventory[i].Description}\n");
            }

            Print(1, "장착 관리");
            Print(0, "뒤로가기");
            Console.WriteLine("\n원하시는 행동을 입력해주세요");
            Console.Write(">>");
        }
        public override void Update()
        {
            string input = Console.ReadLine();

            int index;
            if (!int.TryParse(input, out index))
            {
                Console.WriteLine("\n잘못 입력 하셨습니다.");
                Thread.Sleep(1000); // 1초 대기
                return;
            }

            switch (index)
            {
                case 1:
                    Console.WriteLine("\ninfo : 장비관리하러 갑니다");
                    gameManager.SwitchScene(SceneID.Equip);
                    Thread.Sleep(1000);
                    break;
                case 0:
                    Console.WriteLine("\ninfo : 마을로 돌아갑니다");
                    gameManager.SwitchScene(SceneID.Village);
                    Thread.Sleep(1000);
                    break;
                default:
                    Console.WriteLine("\n잘못 입력 하셨습니다.");
                    Thread.Sleep(1000);
                    break;
            }
        }
    }
}
