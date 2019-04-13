using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
   public static GridManager Instance;
   
   const int Rows = 7;
   const int Cols = 5;

   public GameObject[,] _gems;
   
   public GameObject gemsPrefab;
   public GameObject playerPrefab;
   
   

    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        InstantiateGrid();
    }

    

    // Update is called once per frame
   

    public void InstantiateGrid()
    {
        _gems = new GameObject[Cols,Rows];
        for (int x = 0; x < Cols; x++)
        {
            for (int y = 0; y < Rows; y++)
            {
                if (x == 2 && y == 3)
                {
                    GameObject player = Instantiate(playerPrefab);
                    player.transform.position = new Vector2(x, y);
                    
                }
                else
                {
                    GameObject gem = Instantiate(gemsPrefab);
                    gem.GetComponent<GemBoi>().SetRandomColor();
                    gem.transform.position = new Vector2(x, y);
                }
                
            }
        }
    }

   public void RefreshGrid()
    {
        for (int x = 0; x < Rows; x++)
        {
            for (int y = 0; y < Cols; y++)
            {
                if ([x, y].CompareTag("Player"))
                {

                }
                else
                {
                    
                }
                
            }
        }
    }

    
    
}
