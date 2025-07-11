using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG__ver._2025_
{
    public class StatisticsScene : Scene
    {
        public StatisticsScene(GameManager game) : base(game)
        {

        }
        public override void Render()
        {
            var pc = gameManager.CurrentClass;
            int bonusAP = 0;
            int bonusDP = 0;
            foreach (var it in DataManager.Inventory)
            {
                if (!it.IsEquipped) continue;   // 해체된 건 건너뜀
                if (it is Weapon) bonusAP += it.Value;
                if (it is Armor) bonusDP += it.Value;
            }
            Print("◎상태보기◎", ConsoleColor.DarkYellow);
            Print("캐릭터의 정보가 표시됩니다.\n");
            Print($"직업  : {pc.Name}");
            Print($"레벨  : {pc.Level}");
            Print($"공격력 : {pc.CurAP + bonusAP}" + (bonusAP > 0 ? $" ( +{bonusAP} )" : ""));
            Print($"방어력 : {pc.CurDP + bonusDP}" + (bonusDP > 0 ? $" ( +{bonusDP} )" : ""));
            Print($"체력 : {pc.CurHP}");
            Print($"Gold : {pc.Gold}\n");
            Print(0, "뒤로가기", ConsoleColor.Magenta);
            Print("\n원하시는 행동을 입력해주세요");
            Console.Write(">>");
        }

        public override void Update()
        {
            string input = Console.ReadLine();

            int index;
            if (!int.TryParse(input, out index))
            {
                Console.WriteLine("\ninfo : 잘못 입력 하셨습니다.");
                Thread.Sleep(1000); // 1초 대기
                return;
            }

            switch (index)
            {
                case 0:
                    gameManager.SwitchScene(SceneID.Village);
                    Console.WriteLine("\ninfo : 마을로 돌아갑니다");
                    Thread.Sleep(1000);
                    break;
                default:
                    Console.WriteLine("\ninfo : 잘못 입력 하셨습니다.");
                    Thread.Sleep(1000);
                    break;
            }
        }
    }
}
