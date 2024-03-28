using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.ComponentModel.Design;
using System.Net.NetworkInformation;

namespace TDD
{
    /// <summary>
    /// vi skapar en klass för time där tänker vi att detta kommer vara mer läsbart och mer orgnasierat för de andra som ska 
    /// jobba med TDD projektet. där har vi samlat allt vad gäller Time i det klassen 
    /// </summary>
    public class Time
    {
        private TimeOnly time;
        private const int mittPåDagen = 12;
        public Time(int hours, int minuter, int seconds)
        {
            time = new TimeOnly(hours, minuter, seconds);
        }
        /// <summary>
        /// i den metoden så gör vi en convert för time till en string eftersom detta va ett krav. 
        /// den metoden  kollar först om tiden ska vara i 24 timmar format är det true så skriver vi stringen i den formaten med HH så att
        /// efter kl 12 ska den skriva 13, men om det är inte sant så ska vi skriva stringen enligt följande hh och tt för att den ska skriva 
        /// PM eller AM, men efter kl12 eftermiddag den ska skriva 01 och inte 13. 
        /// </summary>
        /// <param name="is24timmar"> om tiden är 24timmar</param>
        /// <param name="hours">timmar vi skickar in variablen timma till metoden  </param>
        /// <returns> metoden retunerar tid format i en string</returns>
        public string CovertToString(bool is24timmar)
        {
            if (is24timmar)
            {
                return time.ToString("HH:mm:ss");
            }
            else
            {

                return time.ToString("hh:mm:ss tt", CultureInfo.InvariantCulture);
            }
        }
        /// <summary>
        /// den metoden kollar om det är Am eller PM, logiken är enkel och det är att vi tittar om tiden är större eller lika med 12
        /// då är det eftermiddag är det inte så returnerar metoden förmiddag. 
        /// </summary>
        /// <param name="h">vi skickar in variablen som sparar timmarna i för att jämföra med </param>
        /// <returns>två värde anget är varibalen timmar större eller lika med 12 så ska den returnerar eftermiddag eller förmiddag</returns>
        public string IsAm(int h)
        {
            if (h >= mittPåDagen)
            {
                return "Det är eftermiddag";

            }
            else
            {
                return "Det är förmiddag";

            }
        }
        /// <summary>
        /// metoden tittar om tiden som vi har skickat in är rätt eller inte så att man ska inte kunna matta in felaktiga värden inne
        /// så att timmerna ska vara mellan 0 och 23 efter 23 då ska det vara 00, minuterna ska också vara mellan 0 och 60 så blir den 0 efter 
        /// 60, och samma för sekunderna 
        /// </summary>
        /// <param name="h">timmar </param>
        /// <param name="m">minuter</param>
        /// <param name="s">sekunder</param>
        /// <returns>metoden returnerar false eller true. om värden inte stämmer överäns med kraven som vi har då ska den returnerar false 
        /// annars så metoden ska förväntas returnerar true</returns>
        public static bool IsVaild(int h, int m, int s)
        {
            return h >= 0 && h <= 23 && m >= 0 && m <= 59 && s >= 0 && s <= 59;
        }
        /// <summary>
        /// i den metoden så lägger vi till tid  vi skickar in en variabel typ int som vi först gör en kontroll över är det mindre än eller lika
        /// med 0 då ska vi int göra något med tiden som vi har annars så först kollar vi om tiden som vi vill lägga till är större än eller lika
        /// med 59 så först kollar vi om sekunderna är 59 så ska vi inte lägga till sekunder medan detta ska gå över till minuterna 
        /// </summary>
        /// <param name="secondsToAdd">värdet som användaren vill lägga till tiden</param>
        /// <returns>metoden ska returnerar:
        /// 1.om det vi vill lägga till mindre än 0  eller 0 så ska vi skicka tillbaka tiden utan något förändring
        /// 2. lägga till sekunder
        /// 3. annars så kontrollerar vi minuterna 
        /// </returns>
        public string AddSeconds(int secondsToAdd)
        {
            if (secondsToAdd <= 0)
            {
                return time.ToString("hh:mm:ss");
            }
            else
            {
                if (secondsToAdd <= 59)
                {
                    time = time.Add(TimeSpan.FromSeconds(secondsToAdd));
                    return time.ToString("HH:mm:ss");
                }
                else
                {
                    time = time.Add(TimeSpan.FromMinutes(secondsToAdd));
                }
                return time.ToString("hh:mm:ss");
            }

        }
        /// <summary>
        /// samma logik som i metoden ovan men subtract (-) 
        /// </summary>
        /// <param name="secondsToSubtract">tiden som användaren vill tar bort från tiden</param>
        /// <returns></returns>
        public string SubtractSeconds(int secondsToSubtract)
        {
            if (secondsToSubtract <= 0)
            {
                return time.ToString("hh:mm:ss");
            }
            else
            {
                if (secondsToSubtract <= 59)
                {
                    time = time.Add(TimeSpan.FromSeconds(-secondsToSubtract));
                    return time.ToString("HH:mm:ss");
                }
                else
                {
                    time = time.Add(TimeSpan.FromSeconds(-secondsToSubtract));
                }
                return time.ToString("hh:mm:ss");
            }
        }
        /// <summary>
        /// vi använder ++ operator för att ligga till 1 antegen till sekunder annars så är till timmerna eller minuterna men det ska 
        /// börja med att lägga till sek. är sek lika med 59 då ska det gå till minuterna och sedan timmarna. 
        /// </summary>
        /// <param name="time">objekt av klassen </param>
        /// <returns></returns>
        public static  Time operator ++(Time time)
        {
            if (time.time.Second >= 59)
            {
                return new Time(time.time.Add(TimeSpan.FromSeconds(+1)).Hour,
               time.time.Add(TimeSpan.FromSeconds(+1)).Minute, time.time.Add(TimeSpan.FromSeconds(+1)).Second);

            }
            else 
            {
                return new Time(time.time.Add(TimeSpan.FromSeconds(+1)).Hour,
                    time.time.Add(TimeSpan.FromSeconds(+1)).Minute, time.time.Add(TimeSpan.FromSeconds(+1)).Second);
            }
            
        }
        public static Time operator --(Time time)
        {
            return new Time(time.time.Add(TimeSpan.FromSeconds(-1)).Hour, 
                time.time.Add(TimeSpan.FromSeconds(-1)).Minute, time.time.Add(TimeSpan.FromSeconds(-1)).Second);
        }
        // <summary>
        /// för att skapa en mindre än  metod så det är ett krav att vi har en matchande metod för större än 
        /// </summary>
        /// /// <param name="time1"> den är ett objekt av klassen</param>
        /// <param name="time2"> också ett objekt av klassen Time</param>
        /// <returns>Den metoden mindre än kolla om time1 objektet av klassen är mindre än time2 och då retunerar den true bara</returns>
        public static bool operator <(Time time1, Time time2)
        {
            return time1.time < time2.time;
        }
        /// <summary>
        /// den metoden kollar om time1 mindre än time2 
        /// </summary>
        /// <param name="time1">ett objekt av klass Time</param>
        /// <param name="time2">Ett objekt av klass Time</param>
        /// <returns>Den metoden retunerar true bara om time1 större än time2</returns>
        public static bool operator >(Time time1, Time time2)
        {
            return time1.time > time2.time;
        }
        public static bool operator !=(Time time1, Time time2)
        {
            return !(time1 == time2);
        }
        public static bool operator ==(Time time1, Time time2)
        {
            return time1.time == time2.time;
        }




    }
}


