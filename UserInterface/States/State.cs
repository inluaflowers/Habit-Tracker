using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface;

namespace UserInterface.States;
public abstract class State
{
    public InterfaceContext? Context;
    public void SetContext(InterfaceContext context)
    {
        Context = context;
    }
    public void NullContextCheck()
    {
        if (Context is null)
        {
            throw new Exception($"Context is Not Set for {this}");
        }
    }
    public abstract void Display();
}

