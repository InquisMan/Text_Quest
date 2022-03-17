using System;

namespace Text_Quest
{
    public class Context
    {
        public static int room_number = 1;
        public static bool mc_has_key_card = false;
        public static bool mc_has_key = false;
        public static bool puzzle_resolved = false;
        public static void Overture()
        {
            Console.WriteLine("Вы исследуете пещеру рядом с вашим домом. Изучая её некоторое время, вы натыкаетесь на деревянную дверь. Как ни странно дверь подаётся, и вы решаете зайти внутрь.");
            Console.ReadLine();
            Console.WriteLine("Войдя в тёмное помещение, вы слышите резкий звук позади вас. Дверь захлопнулась, вы оказались в ловушке. Но на счастье в комнате горят свечи, немного освещая её. Вам уже" +
                "не так страшно.");
            Console.ReadLine();
            Console.WriteLine("Вы осознаёте, что это подземелье. Если вы попали в подземелье, то его стоит исследовать, так как здесь могут быть сокровища, но и не стоит думать, что вас не поджидают никакие опасности!");
            Console.ReadLine();
        }
        public static int CheckIntInputed(int options_number)
        {
            string input = Console.ReadLine();
            int number = 0;
            bool isConverted = int.TryParse(input, out number);
            bool isInRange = number >= 1 && number <= options_number;

            while (!isConverted || !isInRange)
            {
                Console.WriteLine("Неверная опция, попробуйте снова.");
                input = Console.ReadLine();
                isConverted = int.TryParse(input, out number);
                isInRange = number >= 1 && number <= options_number;
            }

            return number;
        }

    }

    class FirstRoom
    {
        public static void FirstRoomAction()
        {
            Console.Clear();
            Console.WriteLine("Вы находитесь в комнате #1.");
            Console.WriteLine("Дверь, в которую вы вошли, теперь закрыта накрепко, а ключа рядом вы не можете обнаружить.");
            Console.WriteLine("После некоторого изучения причудливого замка этой двери вы приходите к выводу, что здесь нужен массивный ключ такой же причудливой формы.");
            Console.WriteLine("Доступные действия: ");
            Console.WriteLine("1. Осмотреть комнату");
            int option;
            if (Context.mc_has_key == true)
            {
                Console.WriteLine("2. Покинуть подземелье");
                option = Context.CheckIntInputed(2);
            }
            else option = Context.CheckIntInputed(1);

            if (option == 1)
            {
                Console.WriteLine("Вы осматриваете комнату и обнаруживаете ещё одну дверь. Так как делать тут больше нечего, вы покидаете комнату.");
                Context.room_number = 2;
                Console.ReadLine();
            }
            else if (option == 2)
            {
                EndOfTheGame();
            }
        }
        static void EndOfTheGame()
        {
            Console.WriteLine("Игра окончена. Вы завершили прохождение подземелья!");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }

    class SecondRoom
    {
        public static void SecondRoomAction()
        {
            Console.Clear();
            Console.WriteLine("Вы находитесь в комнате #2.");
            Console.WriteLine("Эта комната значительно больше комнаты #1, здесь больше света, что позволяет разглядеть на стенах различные узоры, смысл которых вы уловить не можете.");
            Console.WriteLine("Также вы замечаете две двери. Одна из них массивная, деревянная, с большой ручкой и увесистыми петлями; другая дверь несколько иная, она металлическая, сероватая и с большим количеством потёртостей на её поверхности.");
            Console.WriteLine("Доступные действия: ");
            Console.WriteLine("1. Назад в комнату #1");
            Console.WriteLine("2. Открыть деревянную дверь");
            Console.WriteLine("3. Открыть металлическую дверь");
            int option = Context.CheckIntInputed(3);

            if (option == 1)
            {
                Console.WriteLine("Вы возвращаетесь в комнату #1.");
                Context.room_number = 1;
                Console.ReadLine();
            }
            else if (option == 2)
            {
                Console.WriteLine("Вы входите в комнату #3.");
                Context.room_number = 3;
                Console.ReadLine();
            }
            else if (option == 3)
            {
                Console.WriteLine("Вы подходите к металлической двери комнаты #4.");
                CheckKeyCard();
            }
        }
        static void CheckKeyCard()
        {
            Console.WriteLine("Перед вами находится металлическая дверь.");
            Console.WriteLine("Она совершенно не похожа на деревянную дверь. Хотя бы потому, что в ней нет привычного замка, который открывает ключ, вместо него вы видите электронный замок.");
            Console.WriteLine("Похоже, что без ключа-карты эту дверь не открыть.");
            if (!Context.mc_has_key_card)
            {
                Console.WriteLine("Возможно вы сможете открыть её позже.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Вы используете ключ-карту на электронном замке, металлическая дверь открывается.");
                Console.WriteLine("Без всяких раздумий вы входите в комнату #4.");
                Context.room_number = 4;
                Console.ReadLine();
            }
        }
    }

    class ThirdRoom
    {
        public static void ThirdRoomAction()
        {
            Console.Clear();
            Console.WriteLine("Вы попадаете в небольшое и очень пыльное помещение");
            Console.WriteLine("Комната совсем не освещена, но в ней множество разных предметов, наверняка будет не лишним обыскать тут всё");
            Console.WriteLine("Доступные действия: ");
            Console.WriteLine("1. Вернуться в комнату #2");
            int option;
            if (!Context.mc_has_key_card)
            {
                Console.WriteLine("2. Обыскать помещение");
                option = Context.CheckIntInputed(2);
            }
            else option = Context.CheckIntInputed(1);

            if (option == 1)
            {
                Console.WriteLine("Вы возвращаетесь в комнату #2");
                Context.room_number = 2;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Обыск комнаты занимает некоторое время. Сломанная мебель, грязная одежда из неизвестных материалов, кое-какие столовые приборы.");
                Console.WriteLine("Вам уже кажется, что ничего стоящего здесь нет, как вдруг под грудой тряпья вы обнаруживаете крепкий деревянный сундучок.");
                Console.WriteLine("Открыв крышку, вы видите на дне ту самую ключ-карточку со следами пыли на ней. Немного протерев карточку, вы кладёте её в карман.");
                Context.mc_has_key_card = true;
                Console.ReadLine();
            }
        }
    }

    class FourthRoom
    {
        public static void FourthRoomAction()
        {
            Console.Clear();
            Console.WriteLine("Вы находитесь в комнате средних размеров с различными старинными предметами, разложенными на полках шкафов.");
            Console.WriteLine("Вы замечаете, что здесь ещё находятся рыцарские доспехи на стойках и даже собранные целиком.");
            Console.WriteLine("Один из этих доспехов весьма необычен, вам очень хочется подойти и посмотреть на него поближе.");
            Console.WriteLine("Доступные действия: ");
            Console.WriteLine("1. Вернуться в комнату #2");
            Console.WriteLine("2. Войти в следующую комнату");
            Console.WriteLine("3. Подойти к доспеху и изучить его");
            int option = Context.CheckIntInputed(3);

            if (option == 1)
            {
                Console.WriteLine("Вы возвращаетесь в комнату #2");
                Context.room_number = 2;
                Console.ReadLine();
            }
            else if (option == 2)
            {
                if (Context.puzzle_resolved == true)
                {
                    Console.WriteLine("Вы проходите в комнату #5");
                    Context.room_number = 55;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Вы проходите в комнату #5");
                    Context.room_number = 5;
                    Console.ReadLine();
                }

            }
            else
            {
                Death();
            }
        }
        public static void Death()
        {
            Console.WriteLine("Доспехи оказались 'живыми', они напали на вас, вы пытаетесь спастись бегством, но спотыкаетесь об ковёр и падаете, а невидимый монстр, сидящий в доспехах, сворачивает вам шею.");
            Console.WriteLine("Конец игры. Вас настигла смерть.");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }

    class FifthRoom
    {
        public static void FifthRoomAction()
        {
            Console.Clear();
            Console.WriteLine("Вы попадаете в роскошное помещение со всевозможно дорогой мебелью, большими картинами.");
            Console.WriteLine("В конце комнаты вы видите массивную дверь со статуей человека с головой льва рядом.");
            Console.WriteLine("Вы подходите к этой статуе. Один её глаз поблёскивает, это наталкивает вас на мысль, что в глазу у этой статуи находится кнопка.");
            Console.WriteLine("Доступные действия: ");
            Console.WriteLine("1 Вернуться в комнату #4");
            Console.WriteLine("2 Нажать на глаз статуи");
            int option = Context.CheckIntInputed(2);

            if (option == 1)
            {
                Console.WriteLine("Вы возвращаетесь в комнату #4");
                Context.room_number = 4;
                Console.ReadLine();
            }

            else
            {
                SolveThePuzzle();
            }
        }
        static void SolveThePuzzle()
        {
            Console.WriteLine("Статуя начинает говорить:");
            Console.WriteLine("=========================================================================================");
            Console.WriteLine("'Суждено тебе пройти, если загадку отгадаешь. А ежели не отгадаешь, то будешь наказан'.");
            Console.WriteLine("Статуя говорит загадку: 'Есть я у мужа, у зверя, у мёртвого камня, у облака. ");
            Console.WriteLine("В душу не лезу, ловлю изменения облика.");
            Console.WriteLine("Дева, взглянув на меня, приосанится. ");
            Console.WriteLine("Старец нахмурится, дитятко расхулиганится. ");
            Console.WriteLine("Кто я?'");
            Console.WriteLine("=========================================================================================");
            Console.WriteLine("Введите ответ на загадку: ");
            string answer = Console.ReadLine();
            while (answer.ToLower() != "отражение")
            {
                Console.WriteLine("Ответ неверный, попробуй ещё раз.");
                answer = Console.ReadLine();
            }
            Console.WriteLine(" ");
            Console.WriteLine("Ты дал верный ответ, - сказала статуя. Проходи.");
            Console.WriteLine("Дверь открывается и вы попадаете в комнату #6.");
            Context.puzzle_resolved = true;
            Context.room_number = 6;
            Console.ReadLine();
        }
        public static void FifthRoomAction_2()
        {
            Console.Clear();
            Console.WriteLine("Вы попадаете в роскошное помещение со всевозможно дорогой мебелью, большими картинами.");
            Console.WriteLine("В конце комнаты вы видите массивную дверь со статуей человека с головой льва рядом.");
            Console.WriteLine("Статуя уже знает ваш ответ на загадку, поэтому заново вам решать ничего не нужно.");
            Console.WriteLine("Доступные действия: ");
            Console.WriteLine("1. Вернуться в комнату #4");
            Console.WriteLine("2. Пройти в комнату #6");
            int option = Context.CheckIntInputed(2);

            if (option == 1)
            {
                Console.WriteLine("Вы возвращаетесь в комнату #4");
                Context.room_number = 4;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Вы проходите в комнату #6");
                Context.room_number = 6;
                Console.ReadLine();
            }
        }
    }

    class SixthRoom
    {
        public static void SixthRoomAction()
        {
            Console.Clear();
            Console.WriteLine("Вы заходите в небольшую комнату, обшитую стальными пластинами, в ней много света, а предметов или мебели нет совсем, кроме большого сундука посередние.");
            Console.WriteLine("Вы принимаете решение посмотреть на сундук поближе. Опасности он никакой не представляет, а значит, его можно открыть.");
            Console.WriteLine("Вы открываете сундук и видите на дне большой, украшенный изумрудами ключ.");
            Console.WriteLine("Доступные действия: ");
            Console.WriteLine("1. Вернуться в комнату #5");
            int option;
            if (!Context.mc_has_key)
            {
                Console.WriteLine("2. Забрать изумрудный ключ");
                option = Context.CheckIntInputed(2);
            }
            else option = Context.CheckIntInputed(1);
            OptionsRoom6(option);
        }
        static int OptionsRoom6(int option)
        {
            if (option == 1)
            {
                Console.WriteLine("Вы возвращаетесь в комнату #5");
                Context.room_number = 55;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Вы забираете изумрудный ключ из сундука. Теперь вы можете покинуть подземелье.");
                Context.mc_has_key = true;
                Console.ReadLine();
            }
            return option;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Context.Overture();

            while (true)
            {
                if (Context.room_number == 1) FirstRoom.FirstRoomAction();
                else if (Context.room_number == 2) SecondRoom.SecondRoomAction();
                else if (Context.room_number == 3) ThirdRoom.ThirdRoomAction();
                else if (Context.room_number == 4) FourthRoom.FourthRoomAction();
                else if (Context.room_number == 5) FifthRoom.FifthRoomAction();
                else if (Context.room_number == 55) FifthRoom.FifthRoomAction_2();
                else if (Context.room_number == 6) SixthRoom.SixthRoomAction();
            }
        }
    }
}