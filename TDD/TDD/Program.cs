namespace TDD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hours = 13;// timme
            int minutes = 00;// minut 
            int seconds =05;
            Time time = new Time(13, 59, 59); // should be 14:00:00
            //Time time2 = new Time(14, 30, 15);
            if (Time.IsVaild(hours,minutes,seconds))
            {
                //kl 13 00 05 sedan lägger vi till 55sek 
                // då blir det , sedan lägger vi till ++ oprator 
                //va blir den då 13 01 01
                // den ska vara 13 01 00
                //Time time = new Time(hours, minutes, seconds);
                Console.WriteLine(time.CovertToString(true,hours));
                //Console.WriteLine(time2.CovertToString(true,hours));
                //Console.WriteLine(time2.CovertToString(false,hours));
                Console.WriteLine(time.CovertToString(false, hours));
                Console.WriteLine(time.IsAm(hours));
                //time.AddSeconds(55);
                //Console.WriteLine(time.CovertToString(true,hours));

                //time.SubtractSeconds(3);
                time++;
                Console.WriteLine(time.CovertToString(true, hours));
                --time;
                Console.WriteLine(time.CovertToString(true, hours));
                //++time2;
                //Console.WriteLine(time2.CovertToString(true, hours));


            }
            else
            {
                Console.WriteLine("Not Vaild");
            }
        }
    }
}
