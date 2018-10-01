using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

namespace ObserverPattern
{
    //Observer object
    public abstract class Observer
    {

        public abstract void OnNotify();
        public abstract void OnNotify2();
    }

    public class Item : Observer
    {
        //The reactive object that will do something
        GameObject reactObj;
      
        public Item(GameObject reactObj)
        {
            this.reactObj = reactObj;
        }

        //Reactive response to observer ping
        public override void OnNotify()
        {
            reactObj.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        }

        public override void OnNotify2()
        {
            reactObj.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
        }
    }

}