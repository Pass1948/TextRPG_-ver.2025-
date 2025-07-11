using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG__ver._2025_
{
    public enum SceneID
    {
        MainMenu,
        ClassSelect,
        Village,
        Statistics,
        Inventory,
        Equip,
        Store,
        BuyItem
    }
    public class GameManager
    {
        private SceneID currentScene;
        private readonly Dictionary<SceneID, Scene> scenes = new();

        private Class currentClassID;       //선택된 직업 인스턴스
        public Class CurrentClass => currentClassID;  //읽기용 프로퍼티

        private bool running = true;
        public void GameRun()
        {
            Init();
            while (running)
            {
                Render();
                Update();
            }
        }

        private void Init()
        {
            Console.CursorVisible = false;

            // Scene 등록
            scenes[SceneID.MainMenu] = new MainMenuScene(this);
            scenes[SceneID.Village] = new VillageScene(this);
            scenes[SceneID.ClassSelect] = new ClassSelectScene(this);
            scenes[SceneID.Statistics] = new StatisticsScene(this);
            scenes[SceneID.Inventory] = new InventoryScene(this);
            scenes[SceneID.Equip] = new EquipScene(this);
            scenes[SceneID.Store] = new StoreScene(this);
            scenes[SceneID.BuyItem] = new BuyItemScene(this);

            // 초기 Scene 설정
            currentScene = SceneID.MainMenu;
        }

        // 현재 Scene을 렌더링
        private void Render()
        {
            Console.Clear(); // 화면을 초기화
            scenes[currentScene].Render();
        }

        private void Update()
        {
            scenes[currentScene].Update();
        }
        // ==== Scene 전환 메서드 ====
        public void SwitchScene(SceneID id) => currentScene = id;

        // ==== 게임종료 문구출력 ====
        public void GameOver(string text = "")
        {
            Console.Clear();
            Console.WriteLine($"\n{text}");
            running = false;
        }
    }
}
