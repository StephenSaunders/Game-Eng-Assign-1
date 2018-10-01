using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    public class GameController : MonoBehaviour
    {
        //Subject(player)
        public GameObject sphereObj;
        
        //Reactor (walls)
        public GameObject reactObj1;
        public GameObject reactObj2;
        public GameObject reactObj3;
        public GameObject reactObj4;

        //Ping sender
        Subject subject = new Subject();


        void Start()
        {
            Item thing1 = new Item(reactObj1);
            Item thing2 = new Item(reactObj2);
            Item thing3 = new Item(reactObj3);
            Item thing4 = new Item(reactObj4);
            //Add walls to reactor list
            subject.AddObserver(thing1);
            subject.AddObserver(thing2);
            subject.AddObserver(thing3);
            subject.AddObserver(thing4);
        }


        void Update()
        {
            //The Ping sends when ball color changes
            if ((sphereObj.GetComponent<Renderer>().material.color) == Color.green)
            {
                subject.Notify();
            }
            if ((sphereObj.GetComponent<Renderer>().material.color) == Color.white)
            {
                subject.Notify2();
            }
        }
    }
}
