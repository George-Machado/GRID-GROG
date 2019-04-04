using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class midnightdickbonanaza : MonoBehaviour
{

    private int setAsideDice;
    private int remainingDice = 12;
    private int turnsTaken = 1;
    private float averageturns;

    public int turnssss;
    
    // Start is called before the first frame update
    void Start()
    {
        RollDice();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RollDice()
    {
        

        for (int i = 0; i < turnssss; i++)
        {
            while (setAsideDice < 12)
            {
               int onesrolled = 0;
                for (int j = 0; j < remainingDice; j++)
                {
                  int roll =  Random.Range(1, 7);
                  if (roll == 1)
                  {
                      onesrolled++;

                      setAsideDice++;

                      remainingDice--;

                  }
                  
                  
                }

                turnssss++;
            }
            Debug.Log("That took " + turnsTaken + " turns!");
            averageturns += turnsTaken;
            
            turnsTaken = 0;
            remainingDice = 12;
            setAsideDice = 0;
            
        }
        averageturns /= turnssss;
        Debug.Log("That took " + averageturns+ " turns on average!");

    }
}
