using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG__ver._2025_
{
    public abstract class Class
    {
        protected GameManager gameManager;
        protected Class(GameManager gm) => gameManager = gm;

        //클래스 이름
        public string? Name;

        //체력
        public int CurHP;
        public int MaxHp;

        //레벨
        public int Level;

        /*        //경험치
                public int CurExp;
                public int MaxExp;*/  // 경험치 시스템은 추후에 구현예정이 있다면 사용

        //공격력
        public int CurAP;
        public int MaxAP;

        //방어력
        public int CurDP;
        public int MaxDP;

        // 골드
        public int Gold;
        public int CurGold;

        // 초기 장비세팅
        public abstract void GiveStarterItems();
    }
}
