using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG__ver._2025_
{
    public class EquipScene : Scene
    {
        public EquipScene(GameManager game) : base(game)
        {
        }
        public override void Render()
        {
            Print("◎인벤토리 - 장착관리◎", ConsoleColor.DarkYellow);
            Print("보유 중인 아이템을 관리할 수 있습니다.\n");
            Print("[아이템 목록]\n");
            Print("[선택]  |  [장착상태]  |  [이름]  |  [공격력, 방어력]  |  [설명]\n");
            for (int i = 0; i < DataManager.Inventory.Count; i++)
            {
                string equipTag = DataManager.Inventory[i].IsEquipped ? "[E]" : "   ";
                Print(i + 1, $"{equipTag} | {DataManager.Inventory[i].Name}  |  {DataManager.Inventory[i].Value}  |  {DataManager.Inventory[i].Description}\n", ConsoleColor.DarkGreen);
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

            // 뒤로가기
            if (input == 0)
            {
                Console.WriteLine("\ninfo : 인벤토리로 돌아갑니다");
                gameManager.SwitchScene(SceneID.Inventory);
                Thread.Sleep(1000);
                return;
            }
            
            int idx = input - 1;
            Item selected = DataManager.Inventory[idx];

            // 아이템 목록 이외 번호 입력 예외처리
            if (input < 0 || input > DataManager.Inventory.Count)
            {
                Console.WriteLine("\ninfo : 해당 번호의 아이템이 없습니다.");
                Thread.Sleep(1000);
                return;
            }

            // 선택 아이템 장착 및 해제
            selected.IsEquipped = !selected.IsEquipped;
            Info(selected.IsEquipped ? $"[{selected.Name}]을(를) 장착했습니다." : $"[{selected.Name}]을(를) 해제했습니다.");
            }
           }
}
