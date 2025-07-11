using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG__ver._2025_
{
    public class ClassSelectScene : Scene
    {
        public ClassSelectScene(GameManager game) : base(game)
        {
        }
        public override void Render()
        {
            Print("◎직업 선택◎", ConsoleColor.DarkYellow);
            Print("직업을 선택해주세요.\n");
            Print(1, "전사", ConsoleColor.DarkCyan);
            Print(2, "마법사", ConsoleColor.DarkCyan);
            Print(3, "도적", ConsoleColor.DarkCyan);
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
                Console.WriteLine("\n잘못 입력 하셨습니다.");
                Thread.Sleep(1000); // 1초 대기
                return;
            }

            switch (index)
            {
                case 1:
                    gameManager.SwitchScene(SceneID.Village);
                    gameManager.SwitchClass(ClassID.Warrior);
                    break;
                case 2:
                    gameManager.SwitchScene(SceneID.Village);
                    gameManager.SwitchClass(ClassID.Wizard);
                    break;
                case 3:
                    gameManager.SwitchScene(SceneID.Village);
                    gameManager.SwitchClass(ClassID.Thief);
                    break;
                case 0:
                    gameManager.SwitchScene(SceneID.MainMenu);
                    Console.WriteLine("\ninfo : 메인메뉴로 돌아갑니다");
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
