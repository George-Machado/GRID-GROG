using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Player : MonoBehaviour

{
    private int _xPos;
    private int _yPos;

    private GameObject _tempGameObject;

    private AudioSource _moveSound;

    public GameObject GemGameObject;
    
    // Start is called before the first frame update
    void Start()
    {
        GemGameObject = GameObject.FindWithTag("gems");
        _moveSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    public void PlayerMovement()
    {
        _xPos = Mathf.RoundToInt(transform.position.x);
        _yPos = Mathf.RoundToInt(transform.position.y);

        var moved = false;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (_xPos <= 0)
            {
                return;
            }

            moved = true;
            _tempGameObject = GridManager.Instance._gems[_xPos - 1, _yPos];
            GridManager.Instance._gems[_xPos - 1, _yPos] = gameObject;
            GridManager.Instance._gems[_xPos, _yPos] = _tempGameObject;
            transform.position += new Vector3(-1, 0, 0);

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (_xPos >= 4)
            {
                return;
            }

            moved = true;
            _tempGameObject = GridManager.Instance._gems[_xPos + 1, _yPos];
            GridManager.Instance._gems[_xPos + 1, _yPos] = gameObject;
            GridManager.Instance._gems[_xPos, _yPos] = _tempGameObject;
            transform.position += new Vector3(+1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (_yPos >= 6)
            {
                return;
            }

            moved = true;
            _tempGameObject = GridManager.Instance._gems[_xPos, _yPos + 1];
            GridManager.Instance._gems[_xPos, _yPos + 1] = gameObject;
            GridManager.Instance._gems[_xPos, _yPos] = _tempGameObject;
            transform.position += new Vector3(0, 1, 0);
            

        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (_yPos <= 0)
            {
                return;
            }

            moved = true;
            _tempGameObject = GridManager.Instance._gems[_xPos, _yPos - 1];
            GridManager.Instance._gems[_xPos, _yPos - 1] = gameObject;
            GridManager.Instance._gems[_xPos, _yPos] = _tempGameObject;
            transform.position += new Vector3(0, -1, 0);
        }

        if (moved)
        { 
            GridManager.Instance.RefreshGrid();
            GridManager.Instance.RemoveMatches();
            PlaySound();
        }
    }

    public void PlaySound()
    {
        if (_tempGameObject.GetComponent<Gem>().IsEmpty()==false)
        {
            _moveSound.Play();
        }
    }
    
   
}
