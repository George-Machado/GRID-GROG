using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.SceneManagement;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;

    const int rows = 7;
    const int columns = 5;

    private bool checkedForMatches = false;

    public GameObject[,] _gems;
    public TextMeshProUGUI scoreText;
    public GameObject gemsPrefab;
    public GameObject playerPrefab;

    private int _score;

    private void Awake()
    {
        InstantiateGrid();
    }

    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        
        Instance = this;
    }

    void Update()
    {
        if (!checkedForMatches)
        {
            checkedForMatches = true;
           
            CheckForMatches();
            
        }
    }

    public void CheckForMatches()
    {
        Gem problemGem = HasMatch();
        
        while(problemGem != null)
        {
            problemGem.SetRandomColor();
            problemGem = HasMatch();	
        }
    }

    public void InstantiateGrid()
    {
        _gems = new GameObject[columns, rows];
        
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                if (x == 2 && y == 3)
                {
                    GameObject player = Instantiate(playerPrefab);
                    _gems[2, 3] = player;
                    player.transform.position = new Vector2(x, y);

                }
                else
                {
                    GameObject gem = Instantiate(gemsPrefab);
                    _gems[x, y] = gem;
                    gem.GetComponent<Gem>().SetRandomColor();
                    gem.transform.position = new Vector2(x, y);
                }

            }
        }
        
    }

    public Gem HasMatch()  // This is used when initializing the grid to make sure it doesn't start w/ any matches
    {
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                if (_gems[x, y].GetComponent<Player>() != null) continue;
                
                Gem currentGem = _gems[x, y].GetComponent<Gem>();

                if (x + 2 < columns)
                {
                    var horizontal1 = _gems[x + 1, y];
                    var horizontal2 = _gems[x + 2, y];

                    if (horizontal1.GetComponent<Player>() == null &&
                        horizontal2.GetComponent<Player>() == null)
                    {
                        if (currentGem.CheckMatchThree(horizontal1, horizontal2))
                        {
                            return currentGem;
                        }
                    }
                }
                
                if (y + 2 < rows)
                {
                    var vertical1 = _gems[x, y + 1];
                    var vertical2 = _gems[x, y + 2];

                    if (vertical1.GetComponent<Player>() == null &&
                        vertical2.GetComponent<Player>() == null)
                    {
                        if (currentGem.CheckMatchThree(vertical1, vertical2))
                        {
                            return currentGem;
                        }
                    }
                }
            }
        }

        return null;
    }

    public void RemoveMatches()
    {
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                if (_gems[x, y].GetComponent<Player>() != null) continue;
                
                Gem currentGem = _gems[x, y].GetComponent<Gem>();

                if (x + 2 < columns)
                {
                    var horizontal1 = _gems[x + 1, y];
                    var horizontal2 = _gems[x + 2, y];

                    if (horizontal1.GetComponent<Player>() == null &&
                        horizontal2.GetComponent<Player>() == null)
                    {
                        if (currentGem.CheckMatchThree(horizontal1, horizontal2))
                        {
                          
                            RemoveMatchedGems(currentGem.gameObject, horizontal1, horizontal2);
                        }
                    }
                }
                
                if (y + 2 < rows)
                {
                    var vertical1 = _gems[x, y + 1];
                    var vertical2 = _gems[x, y + 2];

                    if (vertical1.GetComponent<Player>() == null &&
                        vertical2.GetComponent<Player>() == null)
                    {
                        if (currentGem.CheckMatchThree(vertical1, vertical2))
                        {
                           
                            RemoveMatchedGems(currentGem.gameObject, vertical1, vertical2);
                        }
                    }
                }
            }
        }
    }

    public void RemoveMatchedGems(GameObject gem1, GameObject gem2, GameObject gem3)
    {
        gem1.GetComponent<Gem>().Kill();
        gem2.GetComponent<Gem>().Kill();
        gem3.GetComponent<Gem>().Kill();
        
       
    }

    public void AddOneToScore()
    {
        _score += 1;
        scoreText.text = "Score: " + _score;
    }


    public void RefreshGrid()
    {
        int[] numGems = new int[6];
        
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                _gems[x, y].transform.position = new Vector2(x, y);
                
                if (_gems[x, y].GetComponent<Gem>()!= null && !_gems[x,y].GetComponent<Gem>().IsEmpty())
                {
                    if (_gems[x, y].GetComponent<Gem>().GetType() == 0)
                    {
                        numGems[0]++;

                    }

                    if (_gems[x, y].GetComponent<Gem>().GetType() == 1)
                    {
                        numGems[1]++;

                    }

                    if (_gems[x, y].GetComponent<Gem>().GetType() == 2)
                    {
                        numGems[2]++;

                    }

                    if (_gems[x, y].GetComponent<Gem>().GetType() == 3)
                    {
                        numGems[3]++;

                    }

                    if (_gems[x, y].GetComponent<Gem>().GetType() == 4)
                    {
                        numGems[4]++;

                    }

                    if (_gems[x, y].GetComponent<Gem>().GetType() == 5)
                    {
                        numGems[5]++;

                    }
                }
            }
        }
        CheckForGameOver(numGems);
        Debug.Log(numGems[0]+" , " + numGems[1]+" , "+ numGems[2]+" , "+ numGems[3]+" , "+numGems[4]+" , "+ numGems[5]);
    }
    
 

    public void CheckForGameOver(int[] numberGems)
    {
        int numZeroes = 0;

        for (int x = 0; x < numberGems.Length; x++)
        {
            if (numberGems[x] < 3 && numberGems[x] != 0)
            {
                SceneManager.LoadScene("End Screen");
            }

            if (numberGems[x] == 0) 
            {
                numZeroes++;
            }
           
        } if (numZeroes == 6)
        {
            SceneManager.LoadScene("Win screen");
        }
        
    }




}