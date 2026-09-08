using System;

// Interface weapon behavior
public interface IWeaponBehavior
{
    void UseWeapon();
}

// eight classes
public class SwordBehavior : IWeaponBehavior
{
    public void UseWeapon() { Console.WriteLine("удар мечем!"); }
}

public class BowBehavior : IWeaponBehavior
{
    public void UseWeapon() { Console.WriteLine("стріляє з лука!"); }
}

public class AxeBehavior : IWeaponBehavior
{
    public void UseWeapon() { Console.WriteLine("рубає сокирою!"); }
}

public class MagicStaffBehavior : IWeaponBehavior
{
    public void UseWeapon() { Console.WriteLine("кастує вогнем!"); }
}

// Abstract class Character
public abstract class Character
{
    // reference to weapon behavior
    protected IWeaponBehavior weaponBehavior;

    // Method to set weapon behavior
    public void SetWeapon(IWeaponBehavior w)
    {
        this.weaponBehavior = w;
        Console.WriteLine("Зброю змінено.");
    }

    public void Fight()
    {
        if (weaponBehavior != null)
            weaponBehavior.UseWeapon();
        else
            Console.WriteLine("б'ється голими руками!");
    }

    // Abstract method to display character type
    public abstract void Display();
}

// Concrete character classes
public class Knight : Character
{
    public Knight() { weaponBehavior = new SwordBehavior(); }
    public override void Display() { Console.Write("Лицар "); }
}

public class Archer : Character
{
    public Archer() { weaponBehavior = new BowBehavior(); }
    public override void Display() { Console.Write("Лучник "); }
}

public class Wizard : Character
{
    public Wizard() { weaponBehavior = new MagicStaffBehavior(); }
    public override void Display() { Console.Write("Чарівник "); }
}

public class Troll : Character
{
    public Troll() { weaponBehavior = new AxeBehavior(); }
    public override void Display() { Console.Write("Троль "); }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Character player = new Knight();
        player.Display();
        player.Fight();
        player.SetWeapon(new BowBehavior());
        player.Display();
        player.Fight();
        Console.WriteLine("\nСпавниться новий ворог...");
        Character enemy = new Troll();
        enemy.Display();
        enemy.Fight();
        Console.ReadLine();
    }
}