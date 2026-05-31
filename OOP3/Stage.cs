using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;

namespace oop
{
    internal class Stage
    {
        public int Floor;
        public Stage(){}
        public void Fight(Character chara, Enemy enemy)
        {
            int temp=0;
            Floor = chara.Stage;
            if (Floor % 2 == 1)
            {
                if(Floor!=1)
                    enemy.Attack += 5;
            }
            else
            {
                enemy.MaxHp += 10;
            }
            enemy.CurrentHp = enemy.MaxHp;
            int[] tempStat = new int[3] { chara.Attack, chara.Defense, chara.DodgeRate };
            while (chara.CurrentHp > 0 && enemy.CurrentHp > 0)
            {
                int select = 0;
                Console.WriteLine($"\n현재 층수: {Floor}");
                Console.WriteLine($"캐릭터 - 최대 체력: {chara.MaxHp} 현재 체력: {chara.CurrentHp} 공격력: {chara.Attack} 방어력: {chara.Defense} 회피확률: {chara.DodgeRate}%");
                Console.WriteLine($"적 - 체력: {enemy.CurrentHp} 공격력: {enemy.Attack}");
                Console.WriteLine($"1: 공격\n2: 아이템 사용(개수: {chara.Items})\n");
                try
                {
                    select = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("잘못된 입력\n");
                }
                switch (select){
                    case 1:
                        CharAttack(chara, enemy);
                        EnemyAttack(chara, enemy);
                        break;
                    case 2:
                        if (chara.Items > 0)
                        {
                            temp=Item.UseItem(chara);
                        }
                        break;
                    default:
                        break;
                }
            }
            if (chara.CurrentHp <= 0)
            {
                Console.WriteLine("캐릭터가 사망하였습니다. 1: 부활 2: 게임 종료");
                int select = int.Parse(Console.ReadLine());
                switch (select)
                {
                    case 1:
                        chara.CurrentHp = chara.MaxHp;
                        enemy.CurrentHp = enemy.MaxHp;
                        break;
                    case 2:
                        throw new ArgumentException("게임이 종료되었습니다.");
                }
            }
            else
            {   
                List<string> stat = new List<string>
                {
                    "HP","ATTACK","DEFENSE","DODGERATE"
                };
                Console.WriteLine($"{Floor}층 클리어, 업그레이드할 스탯 입력:");
                if (temp == 1)
                {
                    chara.Attack = tempStat[0];
                    chara.Defense = tempStat[1];
                    chara.DodgeRate = tempStat[2];
                    temp = 0;
                }
                while (true)
                {
                    Console.WriteLine("1: 최대 Hp +20, 2: 공격력 +10, 3: 방어력 +10, 4: 회피확률 +5%\n");
                    string statType;
                    while (true)
                    {
                        try
                        {
                            int sel = int.Parse(Console.ReadLine());
                            statType = stat[sel - 1];
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("잘못된 입력\n");
                        }
                    }
                    if (!StatUpgrade._upgradeCounts.ContainsKey(statType)|| StatUpgrade._upgradeCounts[statType] == 10)
                    {
                        Console.WriteLine($"\n허용되지 않는 스탯 : {statType}");
                        Console.Write($"허용 스탯 목록 : ");
                        foreach(var statUp in StatUpgrade.AllowedStatUpgrade)
                        {
                            Console.Write($"{statUp} ");
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        StatUpgrade.ApplyStatUpgrade(statType, chara);
                        if (chara.Stage % 10 == 5)
                            chara.Items++;
                        chara.Stage++;
                        chara.Level++;
                        break;
                    }
                }
            }
        }
        public void CharAttack(Character chara, Enemy enemy)
        {
            enemy.CurrentHp -= chara.Attack;
            Console.WriteLine($"\n플레이어의 공격: {chara.Attack}만큼의 피해를 줌");
        }
        public void EnemyAttack(Character chara, Enemy enemy)
        {
            Random dodge = new Random();
            int DR = dodge.Next(1, 100);
            Console.Write("적의 공격: ");
            if (DR <= chara.DodgeRate)
            {
                Console.WriteLine("회피 성공\n");
            }
            else
            {
                int Damage = (enemy.Attack - chara.Defense)>0? enemy.Attack - chara.Defense:0;
                chara.CurrentHp -= Damage;
                Console.WriteLine($"{Damage}만큼의 피해를 받음\n");
            }
        }
    }
}
