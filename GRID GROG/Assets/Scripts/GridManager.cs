using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
   public static GridManager Instance;
   
   const int Rows = 7;
   const int Cols = 5;
    
   private int [,] _gems = new int [Cols,Rows];
   
   public GameObject gemsPrefab;
   
   

    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        InstantiateGrid();
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiateGrid()
    {
        for (int x = 0; x < Cols; x++)
        {
            for (int y = 0; y < Rows; y++)
            {
                GameObject gem = Instantiate(gemsPrefab);
                gem.GetComponent<GemBoi>().SetRandomColor();
                gem.transform.position = new Vector2(x , y );
               
            }
        }
    }

    
    
}
