using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Flyweight design pattern main class
namespace FlyweightPattern
{
    public class Flyweight : MonoBehaviour
    {
        GameObject Clutter;
        //The list that stores all Clutters
        List<Clutter> allClutters = new List<Clutter>();

        List<Vector3> list1;
        List<Vector3> list2;
        List<Vector3> list3;


        void Start()
        {
            //List used when flyweight is enabled
            list1 = GetNum();
            list2 = GetNum();
            list3 = GetNum();

            //Create all Clutters
            for (int i = 0; i < 100000; i++)
            {
                Clutter newClutter = new Clutter();

                //Add eyes and leg positions
                //Without flyweight
               // newClutter.Set1 = GetNum();
                //newClutter.Set2 = GetNum();
                //newClutter.Set3 = GetNum();

                //With flyweight
                newClutter.Set1 = list1;
                newClutter.Set2 = list2;
                newClutter.Set3 = list3;

                allClutters.Add(newClutter);
            }
        }


        //Generate a list with body part positions
        List<Vector3> GetNum()
        {
            //Create a new list
            List<Vector3> Nums = new List<Vector3>();

            //Add body part positions to the list
            for (int i = 0; i < 1000; i++)
            {
                Nums.Add(new Vector3());
            }

            return Nums;
        }
    }
}
