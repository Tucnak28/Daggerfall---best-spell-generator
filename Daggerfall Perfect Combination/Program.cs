using System;
using System.Threading;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
namespace Daggerfall_Perfect_Combination
{
    class Program
    {
        static TimeSpan MTTime;
        static void Main(string[] args)
        {
            Task[] tasks = new Task[10];
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 10; i++)
            {
                int iCopy = i; // You should not use 'i' directly in the thread start as it creates a closure over a changing value which is not thread safe. You should create a copy that will be used for that specific variable.
                tasks[iCopy] = Task.Factory.StartNew(Loop1, "text");
                Thread.Sleep(10);
            }
            /*double resultThread1 = 0;
            double resultThread2 = 0;
            double resultThread3 = 0;
            double resultThread4 = 0;
            double resultThread5 = 0;
            double resultThread6 = 0;
            double resultThread7 = 0;
            double resultThread8 = 0;
            double resultThread9 = 0;
            double resultThread10 = 0;
            Thread Thread1 = new Thread(() => { resultThread1 = Loop1(); });
            Thread Thread2 = new Thread(() => { resultThread2 = Loop1(); });
            Thread Thread3 = new Thread(() => { resultThread3 = Loop1(); });
            Thread Thread4 = new Thread(() => { resultThread4 = Loop1(); });
            Thread Thread5 = new Thread(() => { resultThread5 = Loop1(); });
            Thread Thread6 = new Thread(() => { resultThread6 = Loop1(); });
            Thread Thread7 = new Thread(() => { resultThread7 = Loop1(); });
            Thread Thread8 = new Thread(() => { resultThread8 = Loop1(); });
            Thread Thread9 = new Thread(() => { resultThread9 = Loop1(); });
            Thread Thread10 = new Thread(() => { resultThread10 = Loop1(); });
            Thread1.Start();
            Thread.Sleep(10);
            Thread2.Start();
            Thread.Sleep(10);
            Thread3.Start();
            Thread.Sleep(10);
            Thread4.Start();
            Thread.Sleep(10);
            Thread5.Start();
            Thread.Sleep(10);
            Thread6.Start();
            Thread.Sleep(10);
            Thread7.Start();
            Thread.Sleep(10);
            Thread8.Start();
            Thread.Sleep(10);
            Thread9.Start();
            Thread.Sleep(10);
            Thread10.Start();

            Thread1.Join();
            Thread2.Join();
            Thread3.Join();
            Thread4.Join();
            Thread5.Join();
            Thread6.Join();
            Thread7.Join();
            Thread8.Join();
            Thread9.Join();
            Thread10.Join();*/
            Task.WaitAll(tasks);
            stopwatch.Stop();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            MTTime = stopwatch.Elapsed;
            Console.WriteLine("Time: " + MTTime);
            //Console.WriteLine(new[] { resultThread1, resultThread2, resultThread3, resultThread4, resultThread5, resultThread6, resultThread7, resultThread8, resultThread9, resultThread10 }.Max());

        }
        public static void Loop1(Object stateInfo)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int Level = 1;
            int Skill = 1;
            int DurationA = 1;
            int DurationB = 1;
            int MagnitudeA = 1;
            int MagnitudeB = 1;
            int offset = 1;
            int attempts = 1000000;
            double HighestMagnitudeMin = 0;
            double HighestMagnitudeMax = 0;
            double HighestMagnitudeIncMin = 0;
            double HighestMagnitudeIncMax = 0;
            double HighestMagnitudePer = 0;
            double HighestMagnitude = 0;
            double HighestEffects = 0;
            double HighestGoldCost = 0;
            double HighestSpellPoint = 0;
            double HighestPointByMagnitude = 0;
            double HighestDurationMin = 0;
            double HighestDurationMax = 0;
            double HighestDurationPer = 0;
            double HighestMagnitudeAndDuration = 0;
            double MagnitudeMin = 0;
            double MagnitudeMax = 0;
            double MagnitudeIncMin = 0;
            double MagnitudeIncMax = 0;
            double MagnitudePer = 0;
            double Magnitude = 0;
            double Effects = 0;
            double GoldCost = 0;
            double SpellPoint = 0;
            double PointByMagnitude = 0;
            double DurationMin = 0;
            double DurationMax = 0;
            double DurationPer = 0;
            double MagnitudeAndDuration = 0;
            FastRandom rnd = new FastRandom();
            for (int i = 0; i < attempts; i++)
            {
                MagnitudeMin = rnd.Next(1, 101); //*it always drops 1-1
                MagnitudeMax = rnd.Next(Convert.ToInt32(MagnitudeMin), 101); //*it always drops 1-1
                MagnitudeIncMin = rnd.Next(1, 101);
                MagnitudeIncMax = rnd.Next(Convert.ToInt32(MagnitudeIncMin), 101);
                MagnitudePer = rnd.Next(1, 21);
                DurationMin = rnd.Next(1, 61);
                DurationMax = rnd.Next(1, 61);
                DurationPer = rnd.Next(1, 21);
                Effects = rnd.Next(1, 4);
                Magnitude = ((MagnitudeMin + MagnitudeMax) / 2) + ((MagnitudeIncMin + MagnitudeIncMax) / 2) * Math.Floor(Level / MagnitudePer);
                MagnitudeAndDuration = (Magnitude * (DurationMin + DurationMax * Math.Floor(Level / DurationPer))) * Effects;
                //GoldCost = (offset + MagnitudeA * ((MagnitudeMin + MagnitudeMax) / 2) + MagnitudeB * Math.Truncate(((MagnitudeIncMin + MagnitudeIncMax) / 2) / MagnitudePer)) * Effects; //Only magnitude
                GoldCost = (offset + DurationA * DurationMin + DurationB * Math.Truncate(DurationMax / DurationPer) + offset + MagnitudeA * Math.Truncate((MagnitudeMin + MagnitudeMax) / 2) + MagnitudeB * Math.Truncate(Math.Truncate((MagnitudeIncMin + MagnitudeIncMax) / 2) / MagnitudePer)) * Effects;
                SpellPoint = Math.Truncate(GoldCost * (110 - Skill) / 400);
                PointByMagnitude = MagnitudeAndDuration / SpellPoint;
                if (HighestPointByMagnitude < PointByMagnitude)
                {
                    HighestDurationMin = DurationMin;
                    HighestDurationMax = DurationMax;
                    HighestDurationPer = DurationPer;
                    HighestPointByMagnitude = PointByMagnitude;
                    HighestMagnitude = Magnitude;
                    HighestMagnitudeAndDuration = MagnitudeAndDuration;
                    HighestMagnitudeMin = MagnitudeMin;
                    HighestMagnitudeMax = MagnitudeMax;
                    HighestMagnitudeIncMin = MagnitudeIncMin;
                    HighestMagnitudeIncMax = MagnitudeIncMax;
                    HighestMagnitudePer = MagnitudePer;
                    HighestEffects = Effects;
                    HighestGoldCost = GoldCost;
                    HighestSpellPoint = SpellPoint;
                    //Console.WriteLine(HighestPointByMagnitude);
                }
            }
            Console.WriteLine(HighestPointByMagnitude);
            Console.WriteLine("DurationMin: " + HighestDurationMin);
            Console.WriteLine("DurationMax: " + HighestDurationMax);
            Console.WriteLine("DurationPer: " + HighestDurationPer);
            Console.WriteLine("MagnitudeMin: " + HighestMagnitudeMin);
            Console.WriteLine("MagnitudeMax: " + HighestMagnitudeMax);
            Console.WriteLine("MagnitudeIncMin: " + HighestMagnitudeIncMin);
            Console.WriteLine("MagnitudeIncMax: " + HighestMagnitudeIncMax);
            Console.WriteLine("MagnitudePer: " + HighestMagnitudePer);
            Console.WriteLine("Effects: " + HighestEffects);
            Console.WriteLine("Gold Cost: " + HighestGoldCost);
            Console.WriteLine("MagnitudeAndDuration: " + HighestMagnitudeAndDuration);
            Console.WriteLine("Magnitude: " + HighestMagnitude);
            Console.WriteLine("Spell Point: " + HighestSpellPoint);
            Console.WriteLine("");
            stopwatch.Stop();
            MTTime = stopwatch.Elapsed;
            Console.WriteLine("Time: " + MTTime);
            Console.WriteLine("");
            //return HighestPointByMagnitude;
        }
    }
}