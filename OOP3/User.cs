using System;
using System.Collections.Generic;
using System.Text;

namespace oop
{
    public class User
    {
        // 변수
        public required int UserId          { get; set; }
        public required string UserNickname { get; set; }
        public DateTime CreatedAt  { get; set; }

        // 생성자
        public User() { }

        public User(int id, string nickname)
        {
            UserId = id;
            UserNickname = nickname;
            CreatedAt = DateTime.Now;
        }

        // User 생성 결과 출력 (Override)
        public virtual void PrintInfo()
        {
            Console.WriteLine("\nPrint User Info\n");
            Console.WriteLine($"UserId       : {UserId}");
            Console.WriteLine($"UserNickname : {UserNickname}");
            Console.WriteLine($"Created Date : {CreatedAt}");
        }
    }
}
