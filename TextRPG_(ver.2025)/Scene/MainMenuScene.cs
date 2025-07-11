using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG__ver._2025_
{
    public class MainMenuScene : Scene
    {
        public MainMenuScene(GameManager game) : base(game)
        {
        }
        public override void Render()
        {
            Print("◎메인메뉴◎", ConsoleColor.DarkYellow);
            Print("스파르타 텍스트 RPG에 오시걸 환영합니다");
            Print("게임을 진행하실려면 1번을 입력하여 직업을 선택하여 주시기 바랍니다.\n");

            Print(1, "직업선택하기", ConsoleColor.DarkCyan);
            Print(0, "게임종료", ConsoleColor.Magenta);

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
                case 1:
                    gameManager.SwitchScene(SceneID.ClassSelect);
                    Console.WriteLine("\ninfo : 게임을 시작합니다.");
                    Thread.Sleep(1000);
                    break;
                case 0:
                    gameManager.GameOver("\ninfo : 게임을 종료했습니다.");
                    break;
                default:
                    Console.WriteLine("\ninfo : 잘못 입력 하셨습니다.");
                    Thread.Sleep(1000);
                    break;
            }
        }
    }
}
