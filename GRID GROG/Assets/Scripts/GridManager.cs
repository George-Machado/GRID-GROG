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
   private  Color[] gemColors = new Color[6];

    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        SetColor();
        InstantiateGrid();
    }

    private void SetColor()
    {
        gemColors[0] = Color.yellow;
        gemColors[1] = Color.red;
        gemColors[2] = Color.blue;
        gemColors[3] = Color.green;
        gemColors[4] = Color.magenta;
        gemColors[5] = Color.cyan;
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

                int color = Random.Range(0, 6);
                _gems[x,y] = color;
                
                GameObject gem = Instantiate(gemsPrefab);
                gem.transform.position = new Vector3(x , y );
                gem.GetComponent<SpriteRenderer>().color = gemColors[color];
                
            }
        }
    }
    
}
