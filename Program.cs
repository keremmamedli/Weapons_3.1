using System;

namespace Weapons_Task3._1
{
    public interface IZoomable
    {
        void Shoot();
        void Reload();
    }

    public abstract class Weapons : IZoomable
    {
        public int TotalBulletCount { get; set; }
        public int CurrentBulletCount { get; set; }

        public abstract void Shoot();
        public abstract void Reload();

        public Weapons(int totalBulletCount, int currentBulletCount)
        {
            if (totalBulletCount <= 0)
            {
                throw new InvalidOperationException("Bullet count cannot be zero or negative number. Please enter a positive count.");
            }

            if (currentBulletCount < 0)
            {
                throw new InvalidOperationException("Current bullet count cannot be negative. Please enter a non-negative count.");
            }
            if(currentBulletCount > totalBulletCount)
            {
                throw new InvalidOperationException("Current Bullet Count bigger than Total count, Enter less than Total Bullet Count please");
            }

            TotalBulletCount = totalBulletCount;
            CurrentBulletCount = currentBulletCount;

            if (CurrentBulletCount == 0)
            {
                throw new InsufficientBulletCountException("Please reload the weapon.");
            }
        }
    }

    public class M416 : Weapons, IZoomable
    {
        public M416(int totalBulletCount, int currentBulletCount) : base(totalBulletCount, currentBulletCount)
        {
        }

        public override void Shoot()
        {
            CurrentBulletCount -= 1;
            Console.WriteLine("M416 Shooting...");
            Console.WriteLine("Current Bullet Value is: " + CurrentBulletCount);
        }

        public override void Reload()
        {
            CurrentBulletCount = TotalBulletCount;
            Console.WriteLine("M416 Reloading...");
            Console.WriteLine("Reloaded, Current Bullet count is: " + CurrentBulletCount); 
        }
    }

    public class AK47 : Weapons, IZoomable
    {
        public AK47(int totalBulletCount, int currentBulletCount) : base(totalBulletCount, currentBulletCount)
        {
        }

        public override void Shoot()
        {
            CurrentBulletCount -= 1;
            Console.WriteLine("AK-47 Shooting...");
            Console.WriteLine("Current Bullet Value is: " + CurrentBulletCount);
        }

        public override void Reload()
        {
            CurrentBulletCount = TotalBulletCount;
            Console.WriteLine("AK-47 Reloading...");
            Console.WriteLine("Reloaded, Current Bullet count is: " + CurrentBulletCount);

        }
    }

    public class P92 : Weapons, IZoomable
    {
        public P92(int totalBulletCount, int currentBulletCount) : base(totalBulletCount, currentBulletCount)
        {
        }

        public override void Shoot()
        {
            CurrentBulletCount -= 1;
            Console.WriteLine("P-92 Shooting...");
            Console.WriteLine("Current Bullet Value is: " + CurrentBulletCount);
        }

        public override void Reload()
        {
            CurrentBulletCount = TotalBulletCount;
            Console.WriteLine("P-92 Reloading...");
            Console.WriteLine("Reloaded, Current Bullet count is: " + CurrentBulletCount);
        }

        public void Zoom()
        {
            Console.WriteLine("View enlarged 3 times");
        }
    }

    public class AWP : Weapons, IZoomable
    {
        public AWP(int totalBulletCount, int currentBulletCount) : base(totalBulletCount, currentBulletCount)
        {
        }

        public override void Shoot()
        {
            CurrentBulletCount -= 1;
            Console.WriteLine("AWP Shooting...");
            Console.WriteLine("Current Bullet Value is: " + CurrentBulletCount);
        }

        public override void Reload()
        {
            CurrentBulletCount = TotalBulletCount;
            Console.WriteLine("AWP Reloading...");
            Console.WriteLine("Reloaded, Current Bullet count is: " + CurrentBulletCount);
        }

        public void Zoom()
        {
            Console.WriteLine("View enlarged 8 times");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var m416 = new M416(50, 22);
                m416.Shoot();
                m416.Reload();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (InsufficientBulletCountException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            try
            {
                var ak47 = new AK47(65, 22);
                ak47.Shoot();
                ak47.Reload();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (InsufficientBulletCountException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            try
            {
                var p92 = new P92(80, 22);
                p92.Shoot();
                p92.Reload();
                p92.Zoom();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (InsufficientBulletCountException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            try
            {
                var awp = new AWP(5, 3);
                awp.Shoot();
                awp.Reload();
                awp.Zoom();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (InsufficientBulletCountException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    public class InsufficientBulletCountException : Exception
    {
        public InsufficientBulletCountException(string message) : base(message)
        {
        }
    }
}