using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace oop
{
    public static class SaveManager
    {
        public static void Save(Character player)
        {
            StreamWriter writer = new StreamWriter("save.txt");

            writer.WriteLine($"Level={player.Level}");
            writer.WriteLine($"Stage={player.Stage}");
            writer.WriteLine($"HP={player.CurrentHp}");

            writer.Close();
        }
    }
}
