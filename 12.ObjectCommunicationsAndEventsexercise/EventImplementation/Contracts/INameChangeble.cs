using System;
using System.Collections.Generic;
using System.Text;
public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);

public interface INameChangeble
{
    void OnNameChange(NameChangeEventArgs args);
     event NameChangeEventHandler NameChange;
    string Name { get; set; }
}