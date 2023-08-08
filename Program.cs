using System;

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

