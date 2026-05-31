using System;
using System.Collections.Generic;
using System.Text;

namespace oop
{
    public class StatUpgrade : Character
    {
        // 변수
        public static List<string> AllowedStatUpgrade = new List<string>{ "HP", "ATTACK", "DEFENSE", "DODGERATE" };
        
        public required string StatType { get; set; }

        public static Dictionary<string, int> _upgradeCounts = new()
        {
            { "HP",      0 },
            { "ATTACK",  0 },
            { "DEFENSE", 0 },
            { "DODGERATE",   0 }
        };

        public static void ApplyStatUpgrade(string statType, Character chara)
        {

            // 공격력, 방어력 선택 => +10, 체력 선택 => +20, 회피확률 선택 => +5
            switch (statType)
            {
                case "HP":
                    chara.MaxHp += 20;
                    break;
                case "ATTACK":
                    chara.Attack += 10;
                    break;
                case "DEFENSE":
                    chara.Defense += 10;
                    break;
                case "DODGERATE":
                    chara.DodgeRate += 5;
                    break;
            }
            if (++_upgradeCounts[statType]==10)
            {
                AllowedStatUpgrade.Remove(statType);
            }
        }

    }
}
