using System.Text;
using Spectre.Console;
using Spectre.Console.Rendering;
using TortoiseAndHareLib.Characters;

namespace TheRace;

class Program {
    static void Main(string[] args) {
        Console.OutputEncoding = Encoding.UTF8;

        // 
        // buid a race 
        // 
        const int finishLine =  60;
        var race = new Race(finishLine);

        // add some racers
        race.AddRacer(new Tortoise("Antony"));
        race.AddRacer(new Hare("Benedict"));
        race.AddRacer(new Tortoise("Colin"));
        race.AddRacer(new Hare("Daphne"));
        race.AddRacer(new Hare("Eloise"));

        // run the race
        race.StartRace();
    }
}
