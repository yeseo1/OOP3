using System;
using System.Collections.Generic;
using System.Text;

namespace oop
{
    internal class Enemy
    {
        public int CurrentHp {  get; set; }
        public int Attack {  get; set; }
        public int MaxHp { get; set;  }
        public Enemy(){
            MaxHp = 100;
            Attack = 30;
        }
    }
}
