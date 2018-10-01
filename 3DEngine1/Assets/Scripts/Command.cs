using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CommandPattern
{
    public abstract class Command
    {
        //distance to move
        public float moveDistance = 2f;

        public abstract void run(Transform Player2, Command command); //each command can move(and save) and undo action
        public virtual void undo(Transform Player2) { }
        public virtual void move(Transform Player2) { }
    }

    public class moveForward : Command
    {
        public override void run(Transform Player2, Command command)
        {
            move(Player2);
            InputHandler.past.Add(command);
        }
        public override void undo(Transform Player2)
        {
            Player2.Translate(-Player2.forward * moveDistance);
        }
        public override void move(Transform Player2)
        {
            Player2.Translate(Player2.forward * moveDistance);
        }
    }


    public class moveReverse : Command
    {
        public override void run(Transform Player2, Command command)
        {
            move(Player2);
            InputHandler.past.Add(command);
        }
        public override void undo(Transform Player2)
        {
            Player2.Translate(Player2.forward * moveDistance);
        }
        public override void move(Transform Player2)
        {
            Player2.Translate(-Player2.forward * moveDistance);
        }
    }


    public class moveLeft : Command
    {
        public override void run(Transform Player2, Command command)
        {
            move(Player2);
            InputHandler.past.Add(command);
        }
        public override void undo(Transform Player2)
        {
            Player2.Translate(Player2.right * moveDistance);
        }
        public override void move(Transform Player2)
        {
            Player2.Translate(-Player2.right * moveDistance);
        }
    }


    public class moveRight : Command
    {
        public override void run(Transform Player2, Command command)
        {
            move(Player2);
            InputHandler.past.Add(command);
        }
        public override void undo(Transform Player2)
        {
            Player2.Translate(-Player2.right * moveDistance);
        }
        public override void move(Transform Player2)
        {
            Player2.Translate(Player2.right * moveDistance);
        }
    }
    //undo one command
    public class undoCommand : Command
    {
        public override void run(Transform Player2, Command command)
        {
            List<Command> past = InputHandler.past;
            if (past.Count > 0)
            {
                Command lastCommand = past[past.Count - 1];
                //move the box with this command
                lastCommand.undo(Player2);
                //Remove the command from the list
                past.RemoveAt(past.Count - 1);
            }
        }
    }
    //For keys with no binding
    public class DoNothing : Command
    {
        public override void run(Transform Player2, Command command)
        {
            //Nothing will happen if we press this key
        }
    }
}