using System;
using System.Collections.Generic;
using System.Text;

namespace TortoiseAndHareLib.Characters; 
public abstract class Racer {
    public Racer(string name) => Name = name;
    public string Name { get; protected set; }
    public int Pos { get; protected set { field = Math.Max(0, value); } }
    public abstract void Move(); // must be able to move yourself
    public abstract string Draw(); // must be able to draw yourself
}
