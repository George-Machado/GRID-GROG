using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
   const int Rows = 5;
   const int Cols = 7;
    
    
    
   private int [,] _gems = new int[Rows,Cols];
   public GameObject gemsPrefab;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GridSpawn()
    {
        for (int x = 0; x < Cols; x++)
        {
            for (int y = 0; y < Rows; y++)
            {
                int color = Random.Range(0, 9);
                _gems[x, y] = color;
            }
        }
    }
    
}
