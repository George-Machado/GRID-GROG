using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBoi : MonoBehaviour
{
    const int TileColor = 6;

    private SpriteRenderer _sr;

    private int _type;

    private  Color[] gemColors = new Color[TileColor];
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetColor(int t)
    {
        gemColors[0] = Color.yellow;
        gemColors[1] = Color.red;
        gemColors[2] = Color.blue;
        gemColors[3] = Color.green;
        gemColors[4] = Color.magenta;
        gemColors[5] = Color.cyan;

        _type = t;
       

        if (_sr == null) {
            _sr = GetComponent<SpriteRenderer>();
        }

        _sr.color = gemColors[_type];
    }

    public void SetRandomColor()
    {
        SetColor(Random.Range(0,gemColors.Length));
    }
    



}

   
    
    

