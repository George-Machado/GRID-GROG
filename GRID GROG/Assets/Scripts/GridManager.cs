using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

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
        _gems = new GameObject[Cols, Rows];
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
                    _gems[x, y] = gem;
                    gem.GetComponent<GemBoi>().SetRandomColor();
                    gem.transform.position = new Vector2(x, y);
                }

            }
        }
        GemBoi ts = HasMatch();
        while(ts != null)
        {
            ts.SetRandomColor();
            ts = HasMatch();	
        }
    }

    public GemBoi HasMatch()
    {
        for (int x = 0; x < Cols; x++)
        {
            for (int y = 0; y < Rows; y++)
            {

                GemBoi ts = _gems[x, y].GetComponent<GemBoi>();

                if (x < Cols - 2 && ts.IsMatch(_gems[x + 1, y], _gems[x + 2, y]))
                {
                    return ts;
                }

                if (y < Rows - 2 && ts.IsMatch(_gems[x, y + 1], _gems[x, y + 2]))
                {
                    return ts;
                }
            }
        }

        return null;
    }

    public void RemoveMatches()
    {
        for (int x = 0; x < Cols; x++)
        {
            for (int y = 0; y < Rows; y++)
            {

                GemBoi ts = _gems[x, y].GetComponent<GemBoi>();
                if (x < Cols - 2 && ts.IsMatch(_gems[x + 1, y], _gems[x + 2, y]))
                {
                    ts.Kill();
                    _gems[x + 1, y].GetComponent<GemBoi>().Kill();
                    _gems[x + 2, y].GetComponent<GemBoi>().Kill();
                    Debug.Log("remove x matched");


                }

                if (y < Rows - 2 && ts.IsMatch(_gems[x, y + 1], _gems[x, y + 2]))
                {
                    ts.Kill();
                    _gems[x, y + 1].GetComponent<GemBoi>().Kill();
                    _gems[x, y + 2].GetComponent<GemBoi>().Kill();
                    Debug.Log("remove y matched");
                }
            }
        }
    }


    public void RefreshGrid()
    {
        for (int x = 0; x < Cols; x++)
        {
            for (int y = 0; y < Rows; y++)
            {
                _gems[x, y].transform.position = new Vector2(x, y);
            }
        }
    }



}