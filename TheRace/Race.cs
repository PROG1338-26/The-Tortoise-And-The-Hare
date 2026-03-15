using Spectre.Console;
using Spectre.Console.Rendering;
using System.Security.Cryptography;
using System.Text;
using TortoiseAndHareLib.Characters;

namespace TheRace;

public class Race
{
    private List<Racer> racers;
    private int _finishLine;
    private Random _rng = new Random();

    public Race(int length = 60)
    { 
        _finishLine = length;
        racers = new List<Racer>();
    }

    public void AddRacer(Racer racer) => racers.Add(racer);

    public void StartRace()
    {
        // 
        // run the race
        // 

        AnsiConsole.Clear();
        AnsiConsole.Live(DrawRace())
            .Start(ctx =>
            {

                while (!isOver())
                {
                    // update 
                    foreach (var r in racers) {
                        if (_rng.Next(10) == 0) 
                            r.Move();
                    }
                    
                    // render
                    ctx.UpdateTarget(new Panel(DrawRace(racers.ToArray())));

                    Thread.Sleep(15); // 30fps
                }

            });

        //
        // announce the winner
        //
        var winners = racers.Where(r => r.Pos > _finishLine);
        var win = Align.Center(new Markup("[bold green]The winner is: " + winners.First().Name + "[/]"));
        AnsiConsole.Clear();
        AnsiConsole.Write(new Panel(new Rows(DrawRace(racers.ToArray()), win)));
    }

    private bool isOver()
    {
        foreach (var r in racers)
            if (r.Pos > _finishLine) 
                return true;

        return false;
    }
    
    //private IRenderable DrawRace(params IDrawable[] racers)
    private IRenderable DrawRace(params Racer[] racers)
    {
        // Header
        var top = Align.Center(new FigletText("The Race"));

        // Table
        var table = new Table().Expand().BorderColor(Color.White);
        table.AddColumn("Racer", col => col.Width(10).LeftAligned());
        table.AddColumn("Position", col => col.Width(_finishLine + 15).LeftAligned());


        // draw each racer
        foreach (var r in racers)
        {
            table.AddRow(r.Name, r.Draw());
        }

        var bot = new Panel(table).RoundedBorder().NoBorder();
        return new Rows(top, bot);
    }
}