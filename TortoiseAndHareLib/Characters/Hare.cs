using System.Text;
namespace TortoiseAndHareLib.Characters;

public class Hare : Racer
{

    public Hare(string name) : base(name)
    {}

    public override void Move()
    {
        Random rnd = new Random();
        var move = rnd.Next(10);
        Pos += move switch
        {
            < 2 => 0,   // no move,   20% 
            < 5 => 1,   // small hop  30%
            < 7 => 9,   // big hop,   20%
            < 9 => 1,   // small slip 20%
            _ => -12,   // big slip,  10%
        };
        Pos = Math.Max(0, Pos);
    }
    
    public override string Draw()
    {
        int finish = 60;
        StringBuilder sb = new StringBuilder(80);
        sb.Append(new string('▀', Pos) + "🐰");
        if (Pos < finish)
            sb.Append(new string(' ', Math.Max(0, finish - Pos)));
        sb[60] = '|';
        return sb.ToString();
    }
}