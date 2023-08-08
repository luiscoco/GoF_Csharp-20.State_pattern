# GoF_Csharp-20.State_pattern


```csharp
﻿using System;

class Program
{
    static void Main(string[] args)
    {
        // Create context with initial state
        Context context = new Context(new StateA());

        // Perform requests, behavior changes based on state
        context.Request();
        context.Request();
        context.Request();
    }
}

// State interface
interface IState
{
    void Handle(Context context);
}

// Concrete state classes
class StateA : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("State A: Handling request.");
        // Change state if needed
        context.State = new StateB();
    }
}

class StateB : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("State B: Handling request.");
        // Change state if needed
        context.State = new StateA();
    }
}

// Context class
class Context
{
    public IState State { get; set; }

    public Context(IState initialState)
    {
        State = initialState;
    }

    public void Request()
    {
        State.Handle(this);
    }
}
```

## How to setup Github actions

![Csharp Github actions](https://github.com/luiscoco/GoF_Csharp-16.Iterator_pattern/assets/32194879/1263a83b-d11c-4a48-ad5c-c22eecd42836)









