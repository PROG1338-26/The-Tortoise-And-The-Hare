
using TortoiseAndHareLib.Interfaces;
namespace TortoiseAndHareLib.Characters;

public abstract class Racer : IMoveable, IDrawable
{
    public Racer(string name) => Name = name; 
    public string Name { get; protected set;}
    public int Pos { get; protected set { field = Math.Max(0, value); } } = 0;

    public abstract void Move();
    public abstract string Draw();
}