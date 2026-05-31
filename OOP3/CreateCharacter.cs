using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace oop
{
    public class CreateCharacter : Character
    {
        // 생성자
        [SetsRequiredMembers] // required 문제 해결
        public CreateCharacter(int userId, string userNickname, int characterId, string classType)
            : base(userId, userNickname, characterId, classType) { }

        // 캐릭터 생성
        public static CreateCharacter Create()
        {
            Console.WriteLine("--- 캐릭터 생성 ---");

            int userId = InputUserId();
            string userNickname = InputUserNickname();
            int characterId = InputCharacterId();
            string classType = InputClassType();

            var character = new CreateCharacter(userId, userNickname, characterId, classType);

            Console.WriteLine("--- 캐릭터 생성 완료 ---");
            
            return character;
        }

        private static int InputUserId()
        {
            // UserId 입력
            Console.Write("UserId를 입력해주세요 : ");
            int userId = int.Parse(Console.ReadLine());
            return userId;
        }

        private static string InputUserNickname()
        {
            // UserNickname 입력
            Console.Write("UserNickname을 입력해주세요 : ");
            string userNickname = Console.ReadLine();
            return userNickname;
        }

        private static int InputCharacterId()
        {
            // CharacterId 입력
            Console.Write("CharacterId를 입력해주세요 : ");
            int characterId = int.Parse(Console.ReadLine());
            return characterId;
        }

        private static string InputClassType()
        {
            while (true)
            {
                // ClassType 입력
                Console.WriteLine("직업 선택");
                Console.WriteLine("1. WARRIOR\n2. ARCHER");
                Console.Write("원하는 직업의 번호를 입력해주세요 : ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        return "WARRIOR";
                    case "2":
                        return "ARCHER";
                    default:
                        Console.WriteLine("1 또는 2를 입력해주세요.");
                        break;
                }
            }
        }


        // Character 생성 결과 출력 (User.PrintInfo() Override)
        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("\nPrint Character Info\n");
            Console.WriteLine($"CharacterId : {CharacterId}");
            Console.WriteLine($"UserId      : {UserId}");

            Console.WriteLine($"ClassType   : {ClassType}");
            Console.WriteLine($"Level       : {Level}");
            Console.WriteLine($"Stage       : {Stage}");

            Console.WriteLine($"CurrentHp   : {CurrentHp}");
            Console.WriteLine($"MaxHp       : {MaxHp}");
            Console.WriteLine($"Attack      : {Attack}");
            Console.WriteLine($"Defense     : {Defense}");
            Console.WriteLine($"DodgeRate   : {DodgeRate}");
            Console.WriteLine($"Created Date : {CreatedAt}");
            Console.WriteLine($"Updated Date : {UpdatedAt}");
        }
    }
}
