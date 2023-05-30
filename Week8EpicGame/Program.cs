string folderPath = @"C:\Users\userName\Desktop\dataForRKE132\";
string heroFile = "heroes.txt";
string villainFile = "villains.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainFile));

string[] weapon = { "Wooden Sword", "Assault Rifle", "Wooden Spoon", "Tulips", "Keyboard", "Ancient Spellbook" };

string hero = GetRandomValueFromArray(heroes);
string heroWeapon = GetRandomValueFromArray(weapon);
int heroHP = GetCharacterHP(hero);
int heroStrikeStrength = heroHP;
Console.WriteLine($"Today {hero} ({heroHP} HP) saves the day using {heroWeapon}!");

string villain = GetRandomValueFromArray(villains);
string villainWeapon = GetRandomValueFromArray(weapon);
int villainHP = GetCharacterHP(villain);
int villainStrikeStrength = heroHP;
Console.WriteLine($"Today {villain} ({villainHP} HP), wielding the {villainWeapon} is the enemy!");

while(heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, villainStrikeStrength);
    villainHP = villainHP - Hit(hero , heroStrikeStrength);
}

Console.WriteLine($"Hero {hero} HP: {heroHP}");
Console.WriteLine($"Villain {villain} HP: {villainHP}");

if(heroHP >0)
{
    Console.WriteLine($"{hero} saves the day!");
}
else if(villainHP > 0)
{
    Console.WriteLine($"{hero} has been defeated by {villain}");
}
else
{
    Console.WriteLine("Its a draw");
}

static string GetRandomValueFromArray(string[] someArray)
{
    Random rnd = new Random();
    int randomIndex = rnd.Next(0 , someArray.Length);
    string randomStringFromArray = someArray[randomIndex];
    return randomStringFromArray;
}

static int GetCharacterHP(string characterName)
{
    if (characterName.Length < 10)
    {
        return 10;
    }
    else
    {
        return characterName.Length;
    }
}

static int Hit(string characterName , int characterHP)
{
    Random rnd = new Random();
    int strike = rnd.Next(0 , characterHP);

    if(strike == 0)
    {
        Console.WriteLine($"{characterName} Missed!");
    }
    else if(strike == characterHP - 1)
    {
        Console.WriteLine($"{characterName} made a crit!");
    }
    else
    {
        Console.WriteLine($"{characterName} hit {strike}");
    }
    return strike;
}