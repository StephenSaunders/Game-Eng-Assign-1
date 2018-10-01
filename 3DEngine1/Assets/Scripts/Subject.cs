using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ObserverPattern
{
    //"Observed" object that notifies reactors
    public class Subject
    {

        const string DLL_NAME = "Observer";

        [DllImport(DLL_NAME)]
        private static extern void notify();

        [DllImport(DLL_NAME)]
        private static extern void notify2();

        [DllImport(DLL_NAME)]
        private static extern bool update();

        [DllImport(DLL_NAME)]
        private static extern bool update2();


        List<Observer> observers = new List<Observer>();

        public void Notify() //Ping for 1 action
        {
            for (int a = 0; a < observers.Count; a++)
            {
                observers[a].OnNotify();
            }
        }

        public void Notify2()//Ping for another action
        {
            for (int a = 0; a < observers.Count; a++)
            {
                observers[a].OnNotify2();
            }
        }

        //Add observer to the list
        public void AddObserver(Observer another)
        {
            observers.Add(another);
        }

        //Remove observer from the list
        public void RemoveObserver(Observer another)
        {
        }
    }
}
