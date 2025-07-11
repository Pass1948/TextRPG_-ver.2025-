using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG__ver._2025_
{
    public class VillageScene : Scene
    {
        public VillageScene(GameManager game) : base(game)
        {
        }
        public override void Render()
        {
            Print("◎마을◎", ConsoleColor.DarkYellow);
            Print("스파르타 마을에 오신 여러분 환영합니다");
            Print("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");

            Print(1, "상태보기", ConsoleColor.DarkCyan);
            Print(2, "인벤토리", ConsoleColor.DarkCyan);
            Print(3, "상점", ConsoleColor.DarkCyan);
            Print(0, "직업다시 선택하기\n", ConsoleColor.Magenta);

            Print("원하시는 행동을 입력해주세요");
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
                case 1:
                    gameManager.SwitchScene(SceneID.Statistics);
                    Console.WriteLine("\ninfo : 상태를 확인합니다.");
                    Thread.Sleep(1000);
                    break;
                case 2:
                    gameManager.SwitchScene(SceneID.Inventory);
                    Console.WriteLine("\ninfo : 인벤토리를 확인합니다.");
                    Thread.Sleep(1000);
                    break;
                case 3:
                    gameManager.SwitchScene(SceneID.Store);
                    Console.WriteLine("\ninfo : 상점으로 갑니다.");
                    Thread.Sleep(1000);
                    break;
                case 0:
                    gameManager.SwitchScene(SceneID.ClassSelect);
                    Console.WriteLine("\ninfo : 직업선택창으로 돌아갑니다");
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
