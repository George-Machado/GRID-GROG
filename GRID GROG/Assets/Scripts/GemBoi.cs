using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBoi : MonoBehaviour
{
    
    private SpriteRenderer _sr;

    private int _type;

    private  Color[] gemColors = new Color[6];
    
    
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
       

        if (_sr == null) 
        {
            _sr = GetComponent<SpriteRenderer>();
        }

        _sr.color = gemColors[_type];
    }

    public void SetRandomColor()
    {
        SetColor(Random.Range(0,gemColors.Length));
    }
    public bool IsMatch (GameObject t1, GameObject t2) {
        GemBoi ts1 = t1.GetComponent<GemBoi>();
        GemBoi ts2 = t2.GetComponent<GemBoi>();

        return (ts1._type == _type && ts2._type == _type);
    }
    
    public void Kill () 
    {
        _sr.enabled = false;
    }

    


}

   
    
    

