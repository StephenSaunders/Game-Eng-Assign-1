using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CommandPattern
{
    public class InputHandler : MonoBehaviour
    {
        public Transform Player2;
        //The different keys we need
        private Command buttonW, buttonS, buttonA, buttonD, buttonB, buttonZ, buttonR;
        //Stores all commands for replay and undo
        public static List<Command> past = new List<Command>();
        private Rigidbody rb;

        void Start()
        {
            //Bind keys with commands
            buttonB = new DoNothing();
            buttonW = new moveForward();
            buttonS = new moveReverse();
            buttonA = new moveLeft();
            buttonD = new moveRight();
            buttonZ = new undoCommand();
            rb = GetComponent<Rigidbody>();
        }


        //Check if we press a key, if so do what the key is binded to 
        public void FixedUpdate()
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                buttonA.run(Player2, buttonA);
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                buttonD.run(Player2, buttonD);
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                buttonS.run(Player2, buttonS);
            }
            else if (Input.GetKeyDown(KeyCode.I))
            {
                buttonW.run(Player2, buttonW);
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                buttonZ.run(Player2, buttonZ);
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                buttonB.run(Player2, buttonZ);
            }
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Pickup"))
            {
                other.gameObject.SetActive(false);
            }
        }

    }
}