using System.ComponentModel.Design;
//paths
string folderPath = @"C:\users\raine\Downloads\data\";
string heroFile = "heroes.txt";
string villainFile = "villains.txt";
string weaponFile = "weapons.txt";
//massiivid
string[] heroes = File.ReadAllLines(Path.Combine(folderPath,heroFile));
string[] villains = File.ReadAllLines(Path.Combine (folderPath, villainFile));
string[] weapon = File.ReadAllLines(Path.Combine (folderPath , weaponFile));
//hero stat
string hero = GetRandomValueFromArray(heroes);
string heroweapon = GetRandomValueFromArray(weapon);
int heroHP = GetCharacterHP(hero);
int heroStrikeStrength = heroHP;
Console.WriteLine($"Today {hero} ({heroHP} HP) with {heroweapon} saves the day!");
//villain stat
string villain = GetRandomValueFromArray(villains);
string villainweapon = GetRandomValueFromArray(weapon);
int villainHP = GetCharacterHP(villain);
int villainStrikeStrength = heroHP;
Console.WriteLine($"Today {villain} ({villainHP} HP) with {villainweapon} tries to take over the world!");
//while
while(heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, villainStrikeStrength);
    villainHP = villainHP - Hit(hero, heroStrikeStrength);
}
//if
if(heroHP > 0)
{
    Console.WriteLine($"{hero} saves the day!");
}
else if (villainHP > 0)
{
    Console.WriteLine($"Dark side wins!");
}
else
{
    Console.WriteLine("Draw!");
}
//hero/villain generator
static string GetRandomValueFromArray(string[] someArray)
{
    Random rnd = new Random();
    int randomIndex = rnd.Next(someArray.Length);
    string randomStringFromArray = someArray[randomIndex];
    return randomStringFromArray;
}
//hp generator
static int GetCharacterHP(string characterName)
{
    if(characterName.Length < 10)
    {
        return 10;
    }
    else
    {
        return characterName.Length;
    }
}
//hit generator
static int Hit(string characterName, int characterHP)
{
    Random rnd = new Random();
    int strike = rnd.Next(0, characterHP);

    if (strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target!");
}
    else if (strike == characterHP - 1)
    {
          Console.WriteLine($"{characterName} made a critical hit!");
    }
    else
    {
        Console.WriteLine($"{characterName} hit {strike}");
    }

    return strike;
}









//string[] heroes = { "DoomSlayer", "Joe Rogan", "Lara Croft", "Vin Diesel" };
//string[] villains = { "Evil Dobby", "Darth Vader", "Young Thug", "Joker", "Sauron" };
//string[] weapon = { "BFG 9000", "nuclear bomb", "AK-47", "Jax lamp", "Water pistol" };