using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonListenerClass : ObserverPatternListener
{
    protected override void Listen(object[] parameters)
    {
        Debug.Log("a: "+parameters[0].ToString()+"b: "+parameters[1].ToString());
    }
}
