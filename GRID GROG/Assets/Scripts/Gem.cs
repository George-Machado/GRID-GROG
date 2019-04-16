using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Gem : MonoBehaviour
{   
    private SpriteRenderer _spriteRenderer;

    private int myType;

    public bool removed = false;

    private  Color[] gemColors = new Color[6];
    public ParticleSystem exlposion;
    
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void SetColor(int t)
    {
        gemColors[0] = Color.yellow;
        gemColors[1] = Color.red;
        gemColors[2] = Color.blue;
        gemColors[3] = Color.green;
        gemColors[4] = Color.magenta;
        gemColors[5] = Color.cyan;
     
        myType = t;
       

        if (_spriteRenderer == null) 
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        _spriteRenderer.color = gemColors[myType];
    }

    public void SetRandomColor()
    {
        SetColor(Random.Range(0,gemColors.Length));
    }
    public bool CheckMatchThree (GameObject t1, GameObject t2) {
        
        if (t1.GetComponent<Player>() != null || t2.GetComponent<Player>() != null) return false;
        
        Gem gemToCompare1 = t1.GetComponent<Gem>();
        Gem gemToCompare2 = t2.GetComponent<Gem>();

        if (gemToCompare1.removed || gemToCompare2.removed) return false;

        return (gemToCompare1.GetType() == myType && gemToCompare2.GetType() == myType);
    }

    public int GetType()
    {
        return myType;
    }
    
    public void Kill () 
    {
        _spriteRenderer.enabled = false;
        Instantiate(exlposion, transform.position, Quaternion.identity);
        StartCoroutine(SetRemovedAfterOneFrame());
    }

    public IEnumerator SetRemovedAfterOneFrame()
    {
        yield return new WaitForEndOfFrame();
        removed = true;
        GridManager.Instance.AddOneToScore();
        
    }
}

   
    
    

