using System;
using System.Collections.Generic;
using System.Text;

public class LayoutFactory
{
    public ILayout CreateFactory(string layoutType)
    {
        ILayout layout = null;
        switch (layoutType)
        {
            case "SimpleLayout":
                layout = new SimpleLayout();
                break;
            case "XmlLayout":
                layout=new XmlLayout();
                break;
                default:
                    throw new ArgumentException("Invalid Layoyt");
        }
        return layout;
    }
}
