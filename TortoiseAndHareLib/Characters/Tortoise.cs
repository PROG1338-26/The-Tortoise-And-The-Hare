using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TortoiseAndHareLib.Characters;

public class Tortoise : Racer {

    public Tortoise(string name) : base(name) { }

    public override void Move() {
        Random rnd = new Random();
        var move = rnd.Next(10);

        Pos += move switch {
            < 5 => 3,      // 50% 
            < 7 => -6,     // 20%
            _ => 1         // 30%
        };
        
        Pos = Math.Max(0, Pos);
    }

    public override string Draw() {

        int finish = 60;
        StringBuilder sb = new StringBuilder(80);

        sb.Append(new string('▀', Pos) + "🐢");
        if (Pos < finish)
            sb.Append(new string(' ', Math.Max(0, finish - Pos)));
        sb[60] = '|';
        return sb.ToString();
    }
}