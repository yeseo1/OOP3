using System;
using System.Collections.Generic;
using System.Text;

namespace oop
{
    public class Character : User
    {
        // 변수
        // 캐릭터 기본 정보
        public required int CharacterId { get; set; }

        // 허용할 직업
        public static readonly string[] AllowedClassTypes = { "WARRIOR", "ARCHER" };

        private string _classType = string.Empty;
        public required string ClassType
        {
            get => _classType;
            set
            {
                if (!AllowedClassTypes.Contains(value)) // SQL CHECK 역할
                {
                    throw new ArgumentException( // 예외 처리
                        $"허용되지 않는 직업 : {value}\n" +
                        $"허용 직업 목록 : {AllowedClassTypes}"
                    );
                }
                _classType = value;
            }
        }

        public int Level { get; set; }
        public int Stage { get; set; }

        public required int CurrentHp { get; set; }
        public required int MaxHp     { get; set; }

        public required int Attack    { get; set; }
        public required int Defense   { get; set; }
        public required int DodgeRate { get; set; }
        public required int Items { get; set; }

        public bool IsDead => CurrentHp == 0; // Indexer

        public new DateTime CreatedAt { get; set; } // Hiding
        public DateTime UpdatedAt { get; set; }

        // 생성자
        public Character() { }

        public Character(int userId, string userNickname, int characterId, string classType) 
            : base(userId, userNickname) // User 생성자 호출
        {
            CharacterId = characterId;
            UserId = userId;
            ClassType = classType;

            Level = 1;
            Stage = 1;

            ClassTypeBase(classType);
            CurrentHp = MaxHp;

            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        // 직업별 스탯 초기화
        public void ClassTypeBase(string classType)
        {
            switch (classType)
            {
                case "WARRIOR":
                    MaxHp = 100;
                    Attack = 50;
                    Defense = 80;
                    DodgeRate = 0;
                    break;
                case "ARCHER":
                    MaxHp = 80;
                    Attack = 80;
                    Defense = 40;
                    DodgeRate = 10;
                    break;
            }
        }
    }
}
