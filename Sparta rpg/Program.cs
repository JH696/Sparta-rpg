using System;
using System.ComponentModel.Design;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Timers;
using Sparta_rpg;

namespace Sparta_rpg
{
    class Program
    {
        static void Main(string[] args)  // 게임 시작으로
        {
            Game game = new Game();

            game.Start();
        }
    }

    public class Player  // 플레이어 데이터
    {
        public string name = "";
        public int atk = 0;
        public int amr = 0;
        public int hp = 0;
        public int gold = 1500;
        public int level = 01;


        public string[] inventory = new string[8]  // 인벤토리 공간
        {
            "", "",  "",  "",  "",  "",  "",  ""
        };

        public void ShowStatus()  // 스탯창
        {
            Console.Clear();
            bool status = true;

            while (status)
            {
                Console.WriteLine($"Lv. {level}");
                Console.WriteLine($"{name} ( 전사 )");
                Console.WriteLine($"공격력 : 10 +({atk})");
                Console.WriteLine($"방어력 : 5 +({amr})");
                Console.WriteLine($"체력 : 100 +({hp})");
                Console.WriteLine($"골드 : {gold} G");
                Console.WriteLine("\n0.나가기");
                Console.Write("\n>> ");
                string input1 = Console.ReadLine();

                switch (input1)
                {
                    case "0":  // 나가기
                        status = false;
                        break;

                    default:
                        Console.WriteLine("올바른 값을 입력하세요.");
                        Console.WriteLine("아무 키나 누르세요.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }

        public void ShowInventory()  // 인벤토리 표시
        {
            bool enterInventory = true;

            while (enterInventory)  // 인벤토리 (아이템 목록)
            {
                Console.Clear();
                Console.WriteLine("인벤토리\n보유 중인 아이템을 관리할 수 있습니다.\n\n[아이템 목록]");
                for (int i = 0; i < inventory.Length; i++)
                {
                    Console.WriteLine($"{inventory[i]}");
                }

                Console.WriteLine("\n1.장착 관리\n0.나가기");
                Console.Write("\n>> ");
                string input1 = Console.ReadLine();

                switch (input1)
                {
                    case "0":
                        enterInventory = false;
                        break;

                    case "1":
                        Equip();
                        break;

                    default:
                        Console.WriteLine("올바른 값을 입력하세요.");
                        Console.WriteLine("아무 키나 누르세요.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void Equip() // 장착 관리
        {
            bool enterEquip = true;

            while (enterEquip)
            {
                Console.Clear();
                Console.WriteLine("인벤토리 - 장착 관리\n보유 중인 아이템을 관리할 수 있습니다.\n\n[아이템 목록]");
                for (int i = 0; i < inventory.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {inventory[i]}");
                }

                Console.WriteLine("\n장착 또는 장착 해제할 무기의 번호를 입력해주세요.\n0.나가기");
                Console.Write("\n>> ");
                string input1 = Console.ReadLine();

                switch (input1)
                {
                    case "0":
                        enterEquip = false;
                        break;

                    case "1":  // 1번 아이템 장착
                        if (inventory[0] != "")
                        {
                            if (inventory[0] == "녹슨 갑옷      | 방어력 +5  | 부식돼 부스러기가 떨어집니다.")
                            {
                                inventory[0] = "[E] " + inventory[0];
                                amr += 5;

                                Console.WriteLine("아이템을 장착했습니다.");
                                Console.WriteLine("아무 키나 누르세요.");
                                Console.ReadKey();
                            }
                            else  // 장착 해제
                            {
                                inventory[0] = inventory[0].Replace("[E] ", "");
                                amr -= 5;

                                Console.WriteLine("아이템을 장착 해제했습니다.");
                                Console.WriteLine("아무 키나 누르세요.");
                                Console.ReadKey();
                            }
                        }
                        else  // 비어있음
                        {
                            Console.WriteLine("장착할 아이템이 없습니다.");
                            Console.WriteLine("아무 키나 누르세요.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;

                    case "2":  // 2번 아이템 장착
                        if (inventory[1] != "")
                        {
                            if (inventory[1] == "멀쩡한 갑옷    | 방어력 +9  | 보호 받는 기분을 느낍니다.")
                            {
                                inventory[1] = "[E] " + inventory[1];
                                amr += 9;

                                Console.WriteLine("아이템을 장착했습니다.");
                                Console.WriteLine("아무 키나 누르세요.");
                                Console.ReadKey();
                            }
                            else  // 장착 해제
                            {
                                inventory[1] = inventory[1].Replace("[E] ", "");
                                amr -= 9;

                                Console.WriteLine("아이템을 장착 해제했습니다.");
                                Console.WriteLine("아무 키나 누르세요.");
                                Console.ReadKey();
                            }
                        }
                        else  // 비어있음
                        {
                            Console.WriteLine("장착할 아이템이 없습니다.");
                            Console.WriteLine("아무 키나 누르세요.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;

                    case "3":  // 3번 아이템 장착
                        if (inventory[2] != "")
                        {
                            if (inventory[2] == "광이 나는 갑옷 | 방어력 +15 | 거울 대용으로 쓸 수 있습니다.")
                            {
                                inventory[2] = "[E] " + inventory[2];
                                amr += 15;

                                Console.WriteLine("아이템을 장착했습니다.");
                                Console.WriteLine("아무 키나 누르세요.");
                                Console.ReadKey();
                            }
                            else  // 장착 해제
                            {
                                inventory[2] = inventory[2].Replace("[E] ", "");
                                amr -= 15;

                                Console.WriteLine("아이템을 장착 해제했습니다.");
                                Console.WriteLine("아무 키나 누르세요.");
                                Console.ReadKey();
                            }
                        }
                        else // 비어있음
                        {
                            Console.WriteLine("장착할 아이템이 없습니다.");
                            Console.WriteLine("아무 키나 누르세요.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;

                    case "4":  // 4번 아이템 장착
                        if (inventory[3] != "")
                        {
                            if (inventory[3] == "녹슨 검        | 공격력 +2  | 파상풍으로 죽을 겁니다.")
                            {
                                inventory[3] = "[E] " + inventory[3];
                                atk += 2;

                                Console.WriteLine("아이템을 장착했습니다.");
                                Console.WriteLine("아무 키나 누르세요.");
                                Console.ReadKey();
                            }
                            else  // 장착 해제
                            {
                                inventory[3] = inventory[3].Replace("[E] ", "");
                                atk -= 2;

                                Console.WriteLine("아이템을 장착 해제했습니다.");
                                Console.WriteLine("아무 키나 누르세요.");
                                Console.ReadKey();
                            }
                        }
                        else  // 비어있음
                        {
                            Console.WriteLine("장착할 아이템이 없습니다.");
                            Console.WriteLine("아무 키나 누르세요.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;

                    case "5":  // 5번 아이템 장착
                        if (inventory[4] != "")
                        {
                            if (inventory[4] == "멀쩡한 검      | 공격력 +5  | 자신감을 불어 넣어줍니다.")
                            {
                                inventory[4] = "[E] " + inventory[4];
                                atk += 5;

                                Console.WriteLine("아이템을 장착했습니다.");
                                Console.WriteLine("아무 키나 누르세요.");
                                Console.ReadKey();
                            }
                            else  // 장착 해제
                            {
                                inventory[4] = inventory[4].Replace("[E] ", "");
                                atk -= 5;

                                Console.WriteLine("아이템을 장착 해제했습니다.");
                                Console.WriteLine("아무 키나 누르세요.");
                                Console.ReadKey();
                            }
                        }
                        else  // 비어있음
                        {
                            Console.WriteLine("장착할 아이템이 없습니다.");
                            Console.WriteLine("아무 키나 누르세요.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;

                    case "6":  // 6번 아이템 장착
                        if (inventory[5] != "")
                        {
                            if (inventory[5] == "광이 나는 검   | 공격력 +7  | 적의 눈을 멀게 합니다.")
                            {
                                inventory[5] = "[E] " + inventory[5];
                                atk += 7;

                                Console.WriteLine("아이템을 장착했습니다.");
                                Console.WriteLine("아무 키나 누르세요.");
                                Console.ReadKey();
                            }
                            else  // 장착 해제
                            {
                                inventory[5] = inventory[5].Replace("[E] ", "");
                                atk -= 7;

                                Console.WriteLine("아이템을 장착 해제했습니다.");
                                Console.WriteLine("아무 키나 누르세요.");
                                Console.ReadKey();
                            }
                        }
                        else  // 비어있음
                        {
                            Console.WriteLine("장착할 아이템이 없습니다.");
                            Console.WriteLine("아무 키나 누르세요.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;

                    case "7":  // 7번 아이템 장착
                        if (inventory[6] != "")
                        {
                            if (inventory[6] == "불길한 검      |     ??     | 검이 나를 쳐다보는 것만 같다.")
                            {
                                inventory[6] = "[E] " + inventory[6];

                                inventory[6] = inventory[6].Replace("    ??   ", "타락 + 99");

                                atk += 20;
                                level += 665;

                                Console.WriteLine("저주가 당신을 덮칩니다.");
                                Console.WriteLine("아무 키나 누르세요.");
                                Console.ReadKey();
                            }
                            else  // 장착 해제
                            {
                                inventory[6] = inventory[6].Replace("[E] ", "");
                                atk -= 20;
                                level -= 665;
                                Console.WriteLine("아이템을 장착 해제했습니다.");
                                Console.WriteLine("아무 키나 누르세요.");
                                Console.ReadKey();
                            }
                            {
                                Console.WriteLine("검을 놓을 수 없습니다.");
                                Console.WriteLine("아무 키나 누르세요.");
                                Console.ReadKey();
                            }
                        }
                        else  // 비어있음
                        {
                            Console.WriteLine("장착할 아이템이 없습니다.");
                            Console.WriteLine("아무 키나 누르세요.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;

                    default:
                        Console.WriteLine("올바른 값을 입력해주세요.");
                        Console.WriteLine("아무 키나 누르세요.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
    }

    public class Items  // 아이템 목록
    {
        public string[] items = new string[]
        {
             "녹슨 갑옷      | 방어력 +5  | 부식돼 부스러기가 떨어집니다. | 500G",
             "멀쩡한 갑옷    | 방어력 +9  | 보호 받는 기분을 느낍니다.    | 1000G",
             "광이 나는 갑옷 | 방어력 +15 | 거울 대용으로 쓸 수 있습니다. | 3000G",
             "녹슨 검        | 공격력 +2  | 파상풍으로 죽을 겁니다.       | 500G",
             "멀쩡한 검      | 공격력 +5  | 자신감을 불어 넣어줍니다.     | 1000G",
             "광이 나는 검   | 공격력 +7  | 적의 눈을 멀게 합니다.        | 3000G",
             "불길한 검      |     ??     | 검이 나를 쳐다보는 것만 같다. | 10000G"
        };
    }

    public class Game
    {
        private Player player;
        private Items itemsClass;
        private string[] items;
        private string[] inventory;

        public Game()
        {
            player = new Player();
            itemsClass = new Items();
            items = itemsClass.items;
        }

        public void Start()  // 게임시작
        {
            Console.Write("당신의 이름은 무엇입니까?: ");
            player.name = Console.ReadLine();
            Console.Clear();

            bool town = true;

            while (town)  // 마을 (로비)
            {
                Console.Clear();
                Console.WriteLine($"스파르타 마을 오신 것을 환영합니다 {player.name}.\n이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");

                if ($"{player.name}" == "Hero")  // 이름이 Hero라면 추가 골드 지급
                {
                    player.gold += 76277;
                }

                Console.WriteLine("\n1.상태 보기\n2.인벤토리\n3.상점\n4.던전");
                Console.Write("\n원하시는 행동을 입력해주세요.\n\n>> ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":  // 스탯창
                        player.ShowStatus();
                        break;

                    case "2": // 인벤토리
                        player.ShowInventory();
                        break;

                    case "3":  // 상점
                        Shoping1();
                        break;

                    default:
                        Console.WriteLine("올바른 값을 입력하세요.");
                        Console.WriteLine("아무 키나 누르세요.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
        public void Shoping1() // 상점 1
        {
            bool shop = true;

            while (shop)  // 아이템 진열
            {
                Console.Clear();
                Console.WriteLine("상점");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                Console.WriteLine("\n[보유 골드]");
                Console.WriteLine($"{player.gold} G");
                Console.WriteLine("\n[아이템 목록]");
                for (int i = 0; i < items.Length; i++)
                {
                    Console.WriteLine($"{items[i]}");
                }
                Console.WriteLine("\n1.아이템 구매\n0.나가기");
                Console.Write("\n>> ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":  // 아이템 구매
                        Shoping2();
                        break;

                    case "0":  // 타운 (로비)
                        shop = false;
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("올바른 값을 입력하세요.");
                        Console.WriteLine("아무 키나 누르세요.");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                }
            }
        }

        public void Shoping2()  // 상점 2
        {
            bool shoping = true;

            while (shoping)  // 아이템 구매
            {
                Console.Clear();
                Console.WriteLine("상점 - 아이템 구매");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                Console.WriteLine("\n[보유 골드]");
                Console.WriteLine($"{player.gold} G");
                Console.WriteLine("\n[아이템 목록]");
                for (int i = 0; i < items.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {items[i]}");
                }
                Console.WriteLine("\n0.나가기");
                Console.Write("\n>> ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "0":  // 나가기
                        shoping = false;
                        Console.Clear();
                        break;

                    case "1":  // 1번 아이템 구입

                        if (player.gold >= 500)
                        {
                            if (player.inventory[0] == "")
                            {
                                player.inventory[0] = "녹슨 갑옷      | 방어력 +5  | 부식돼 부스러기가 떨어집니다.";
                                items[0] = items[0].Replace("500G", "구매완료");
                                player.gold -= 500;
                                Console.WriteLine("구매의 성공했습니다.");
                            }
                            else  // 보유 중
                            {
                                Console.WriteLine("이미 보유한 아이템입니다.");
                            }
                        }
                        else  // 골드 부족
                        {
                            Console.WriteLine("골드가 부족합니다.");
                        }
                        Console.WriteLine("아무 키나 누르세요.");
                        Console.ReadKey();
                        break;

                    case "2":  // 2번 아이템 구입

                        if (player.gold >= 1000)
                        {
                            if (player.inventory[1] == "")
                            {
                                player.inventory[1] = "멀쩡한 갑옷    | 방어력 +9  | 보호 받는 기분을 느낍니다.";
                                items[1] = items[1].Replace("1000G", "구매완료");
                                player.gold -= 1000;
                                Console.WriteLine("구매의 성공했습니다.");
                            }
                            else  // 보유 중
                            {
                                Console.WriteLine("이미 보유한 아이템입니다.");
                            }
                        }
                        else  // 골드 부족
                        {
                            Console.WriteLine("골드가 부족합니다.");
                        }
                        Console.WriteLine("아무 키나 누르세요.");
                        Console.ReadKey();
                        break;

                    case "3":  // 3번 아이템 구입

                        if (player.gold >= 1500)
                        {
                            if (player.inventory[2] == "")
                            {
                                player.inventory[2] = "광이 나는 갑옷 | 방어력 +15 | 거울 대용으로 쓸 수 있습니다.";
                                items[2] = items[2].Replace("3000G", "구매완료");
                                player.gold -= 3000;
                                Console.WriteLine("구매의 성공했습니다.");
                            }
                            else  // 보유 중
                            {
                                Console.WriteLine("이미 보유한 아이템입니다.");
                            }
                        }
                        else  // 골드 부족
                        {
                            Console.WriteLine("골드가 부족합니다.");
                        }
                        Console.WriteLine("아무 키나 누르세요.");
                        Console.ReadKey();
                        break;

                    case "4":  // 4번 아이템 구입

                        if (player.gold >= 500)
                        {
                            if (player.inventory[3] == "")
                            {
                                player.inventory[3] = "녹슨 검        | 공격력 +2  | 파상풍으로 죽을 겁니다.";
                                items[3] = items[3].Replace("500G", "구매완료");
                                player.gold -= 500;
                                Console.WriteLine("구매의 성공했습니다.");
                            }
                            else  // 보유 중
                            {
                                Console.WriteLine("이미 보유한 아이템입니다.");
                            }
                        }
                        else  // 골드 부족
                        {
                            Console.WriteLine("골드가 부족합니다.");
                        }
                        Console.WriteLine("아무 키나 누르세요.");
                        Console.ReadKey();
                        break;

                    case "5":  // 5번 아이템 구입

                        if (player.gold >= 1000)
                        {
                            if (player.inventory[4] == "")
                            {
                                player.inventory[4] = "멀쩡한 검      | 공격력 +5  | 자신감을 불어 넣어줍니다.";
                                items[4] = items[4].Replace("1000G", "구매완료");
                                player.gold -= 1000;
                                Console.WriteLine("구매의 성공했습니다.");
                            }
                            else  // 보유 중
                            {
                                Console.WriteLine("이미 보유한 아이템입니다.");
                            }
                        }
                        else  // 골드 부족
                        {
                            Console.WriteLine("골드가 부족합니다.");
                        }
                        Console.WriteLine("아무 키나 누르세요.");
                        Console.ReadKey();
                        break;

                    case "6":  // 6번 아이템 구입

                        if (player.gold >= 3000)
                        {
                            if (player.inventory[5] == "")
                            {
                                player.inventory[5] = "광이 나는 검   | 공격력 +7  | 적의 눈을 멀게 합니다.";
                                items[5] = items[5].Replace("3000G", "구매완료");
                                player.gold -= 3000;
                                Console.WriteLine("구매의 성공했습니다.");
                            }
                            else  // 보유 중
                            {
                                Console.WriteLine("이미 보유한 아이템입니다.");
                            }
                        }
                        else  // 골드 부족
                        {
                            Console.WriteLine("골드가 부족합니다.");
                        }
                        Console.WriteLine("아무 키나 누르세요.");
                        Console.ReadKey();
                        break;

                    case "7":  // 7번 아이템 구입

                        if (player.gold >= 10000)
                        {
                            if (player.inventory[6] == "")
                            {
                                player.inventory[6] = "불길한 검      |     ??     | 검이 나를 쳐다보는 것만 같다.";
                                items[6] = items[6].Replace("10000G", "구매완료");
                                player.gold -= 10000;
                                Console.WriteLine("구매의 성공했습니다.");
                            }
                            else  // 보유 중
                            {
                                Console.WriteLine("이미 보유한 아이템입니다.");
                            }
                        }
                        else  // 골드 부족
                        {
                            Console.WriteLine("골드가 부족합니다.");
                        }
                        Console.WriteLine("아무 키나 누르세요.");
                        Console.ReadKey();
                        break;

                    default:

                        Console.WriteLine("올바른 값을 입력하세요.");
                        Console.WriteLine("아무 키나 누르세요.");
                        Console.ReadKey();
                        break;

                }
            }
        }

    }
}





