# GoF_Csharp-20.State_pattern

The State Pattern is a behavioral design pattern that allows an object to change its behavior when its internal state changes. It is particularly useful in scenarios where an object's behavior depends on its internal state, and this behavior needs to be changed dynamically at runtime without affecting the object's clients.

In the provided C# sample, the State Pattern is demonstrated with a simple example involving a Context class and multiple concrete state classes (StateA and StateB) that implement the IState interface. Here's how the pattern works:

State Interface (IState): This interface defines the contract for concrete state classes. It typically includes one or more methods that represent the different behaviors associated with different states. In this sample, the IState interface defines a single method, Handle(Context context), which is responsible for performing the behavior associated with a particular state.

Concrete State Classes (StateA and StateB): These classes implement the IState interface and provide specific implementations for the behavior associated with each state. In this example, StateA and StateB each have their own Handle methods that print out messages indicating the current state and potentially change the state of the Context object.

Context Class (Context): The Context class maintains a reference to the current state (IState instance) and provides methods to interact with the state. In this sample, the Context class has a State property that holds the current state and a Request method. When the Request method is called, it delegates the request handling to the current state by calling the Handle method on the current state, passing in the context object itself.

In the Main method of the Program class:

An initial state (StateA) is set for the Context object.
The Request method is called three times on the Context object. The behavior of each call depends on the current state. The output will alternate between "State A: Handling request." and "State B: Handling request." as the states change and handle the requests.
This pattern allows for easy addition of new states and their associated behaviors without modifying existing code. It also encapsulates the state-specific behavior within the respective state classes, promoting clean separation of concerns and maintainability.

In summary, the State Pattern allows an object to change its behavior based on its internal state by encapsulating each state's behavior in separate state classes and dynamically switching between these states at runtime.

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









