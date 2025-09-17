using UserInterface.States;
namespace UserInterface;
public class InterfaceContext
{
    public State State = null;
    public Cache? Cache = null;

    public InterfaceContext(State state)
    {
        TransitionTo(state);
    }
    public void TransitionTo(State state)
    {
        State = state;
        State.SetContext(this);
        Display();
    }

    public void Display()
    {
        State.Display();
    }
}


