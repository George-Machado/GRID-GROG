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
        gemColors[0] = new Color32(223,187,36,255);
        gemColors[1] = new Color32(35,31,32,255);
        gemColors[2] = new Color32(104, 123, 160,255);
        gemColors[3] = new Color32(128,151,120,255);
        gemColors[4] = new Color32(209, 155, 111, 255);
        gemColors[5] = new Color32(135, 62, 53, 255);
     
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
    
    public bool IsEmpty()
    {

        if (_spriteRenderer.enabled == false)
        {
            return true;
        }

        return false;

    }

    public IEnumerator SetRemovedAfterOneFrame()
    {
        yield return new WaitForEndOfFrame();
        removed = true;
        GridManager.Instance.AddOneToScore();
        
    }
}

   
    
    

