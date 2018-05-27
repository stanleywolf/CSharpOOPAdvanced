using System;
using System.Collections.Generic;
using System.Text;



public class Dispatcher:INameChangeble,INameable
{
    public event NameChangeEventHandler NameChange;

    public Dispatcher(string name)
    {
        this.name = name;
    }

    private string name;
    public string Name
    {
        get { return this.name; }
         set
        {
            this.OnNameChange(new NameChangeEventArgs(value));
            this.name = value;
        }
    }
    
    public void OnNameChange(NameChangeEventArgs args)
    {
        if (this.NameChange != null)
        {
            this.NameChange.Invoke(this,args);
        }
    }
}
