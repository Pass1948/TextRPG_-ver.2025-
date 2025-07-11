using System;
using System.Collections;
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
    public enum ClassID
    {
        Class,
        Thief,
        Warrior,
        Wizard
    }

    public class GameManager
    {
        private SceneID currentScene;
        private readonly Dictionary<SceneID, Scene> scenes = new();

        private ClassID currentClass;
        private readonly Dictionary<ClassID, Class> playerClass = new();

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

             // 플레이어 클래스 등록
            playerClass[ClassID.Thief] = new Thief(this);
            playerClass[ClassID.Warrior] = new Warrior(this);
            playerClass[ClassID.Wizard] = new Wizard(this);

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

        // ==== Class 전환 메서드 ====
        public void SwitchClass(ClassID id)
        {

            if (!playerClass.TryGetValue(id, out var pc))
            {
                Console.WriteLine("\n존재하지 않는 클래스입니다.");
                Thread.Sleep(800);
                return;
            }
            currentClassID = playerClass[id];

            Console.WriteLine($"\ninfo : {id} 클래스을 선택했습니다.\n");
            Console.WriteLine("마을로 입장합니다.");
            Thread.Sleep(1000);
        }

        // 장착확인 테스트 아이템 생성 메서드
        public void GiveTestItems()
        {
            var rtan = new Weapon("르탄피규어", 999, "스파르탄SD 피규어... \"이게왜... 여기있지?\"", 999);
            var rtanPants = new Armor("르탄빤쓰", 999, "르탄 빤쓰다! \"뭐야이거?!\"", 999);

            // 아이템을 데이터 매니저의 인벤토리에 추가
            DataManager.Inventory.AddRange(new Item[]
            {
               rtan,
               rtanPants,
            });
        }

        // ==== 게임종료 문구출력 ====
        public void GameOver(string text = "")
        {
            Console.Clear();
            Console.WriteLine($"\n{text}");
            running = false;
        }
    }
}
