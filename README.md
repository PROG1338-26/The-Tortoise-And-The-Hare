# The Race



The classic race between the Tortoise and the Hare. We have two designs, implemented in two different Libraries. I have made the Namespaces the same in the two libraries (normally not a good idea, but this is what allow us to just swap between the two libraries without making any other changes).



## Plod and Hop Table

move probabilities for Tortoises and Hares

| Animal   | name       | %    | move    |
| -------- | ---------- | ---- | ------- |
| Tortoise | Fast Plod  | 50   | +3 sq   |
|          | slip       | 20   | -6 sq   |
|          | slow plod  | 30   | +1 sq   |
| Hare     | Sleep      | 20   | no move |
|          | small hop  | 30   | +1 sq   |
|          | big hop    | 20   | +9 sq   |
|          | small slip | 20   | -2 sq   |
|          | big slip   | 10   | -12 sq  |



# Race State Diagram





```mermaid
stateDiagram
state if_state <<choice>>
state merge <<choice>>
[*] --> initialize
initialize --> add_racers
add_racers --> start_the_race
start_the_race --> merge
merge --> if_state
if_state --> Announce_Winner: winner
if_state --> move_racers: no winner
move_racers --> draw_tracks
draw_tracks --> pause
pause --> merge

Announce_Winner --> [*]
```

---



# Design using inheritance only

```mermaid
classDiagram  
    class Racer {  
        <<abstract>>  
        +string Name  
        +int Pos  
        +Racer(string name)  
        +Move()* void  
        +Draw()* string  
    }  
  
    class Tortoise {  
        +Tortoise(string name)  
        +Move() void  
        +Draw() string  
    }  
  
    class Hare {  
        +Hare(string name)  
        +Move() void  
        +Draw() string  
    }  
  
    Racer <|-- Tortoise : extends  
    Racer <|-- Hare : extends
```

---



# Design using Interfaces

When we use interfaces instead of straight inheritance it changes the way we think of and organize our objects.  

- **Inheritance** encourages us to design classes as family trees. When we need to add a behaviours by creating new inherited classes with added functionality. 
  - This can be limiting, sometimes otherwise unrelated classes my require the same behavior
  - Family trees don't allow independent mixing and matching of behaviours
- **Interface** encourages us to design with more of a focus on capabilities. If a class implements an Interface it is saying that it has that capability (it can do the behaviour that the interface describes). 



```mermaid
classDiagram  
    class IMoveable {  
        <<interface>>  
        +int Pos  
        +Move() void  
    }  
  
    class IDrawable {  
        <<interface>>  
        +string Name  
        +Draw() string  
    }  
  
    class Racer {  
        <<abstract>>  
        +string Name  
        +int Pos  
        +Racer(string name)  
        +Move()* void  
        +Draw()* string  
    }  
  
    class Tortoise {  
        +Tortoise(string name)  
        +Move() void  
        +Draw() string  
    }  
  
    class Hare {  
        +Hare(string name)  
        +Move() void  
        +Draw() string  
    }  
  
    IMoveable <|.. Racer : implements  
    IDrawable <|.. Racer : implements  
    Racer <|-- Tortoise : extends  
    Racer <|-- Hare : extends
```



---

# The Race app design



```mermaid
classDiagram  
  x
    namespace TheRace {  
        class Program {  
            +Main(string[] args)$ void  
        }  
  
        class Race {  
            -List~Racer~ racers  
            -int _finishLine  
            -Random _rng  
			
            +AddRacer(Racer racer) void  
            +StartRace() void  
            -isOver() bool  
            -DrawRace(Racer[] racers) IRenderable  
        }  
    }  
  
  
    Program ..> Race : creates  
```



## State Chart 

- Create the Race object
- add racers 
- start the race
  - has anyone won yet
    - yes: announce the winner and exit the loop
    - no: keep going
  - move all the racers (one turn)
  - draw the current state of the race
  - repeat





```mermaid
stateDiagram
state if_state <<choice>>
state merge <<choice>>
[*] --> initialize
initialize --> add_racers
add_racers --> start_the_race
start_the_race --> merge
merge --> if_state
if_state --> Announce_Winner: winner
if_state --> move_racers: no winner
move_racers --> draw_tracks
draw_tracks --> pause
pause --> merge

Announce_Winner --> [*]
```

---



