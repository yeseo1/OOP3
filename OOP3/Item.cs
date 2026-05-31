using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace oop
{
    internal class Item{
        public static int UseItem(Character chara)
        {
            while (true)
            {
                int item = 0;
                Console.WriteLine("\n1: Hp 30 회복 2: 공격력 15 증가 3: 방어력 15 증가 4: 회피확률 10% 증가 5: 돌아가기");
                Console.WriteLine("※회복을 제외한 항목은 해당 층에서만 적용\n");
                while (true)
                {
                    {
                        try
                        {
                            item = int.Parse(Console.ReadLine());
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("잘못된 입력");
                        }
                    }
                }
                switch (item) {
                    case 1:
                        chara.CurrentHp += chara.MaxHp - chara.CurrentHp >= 30 ? 30 : chara.MaxHp - chara.CurrentHp;
                        chara.Items--;
                        return 0;
                    case 2:
                        chara.Attack += 15;
                        chara.Items--;
                        return 1;
                    case 3:
                        chara.Defense += 15;
                        chara.Items--;
                        return 1;
                    case 4:
                        chara.DodgeRate += 10;
                        chara.Items--;
                        return 1;
                    case 5:
                        return 0;
                    default:
                        break;
                } 
            }
        }
    }
}
