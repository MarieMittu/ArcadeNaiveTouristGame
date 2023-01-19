using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private static MoveLeft _instance;

    private MoveLeft() { }

    public static MoveLeft Instance
    {
        get
        {
            if (_instance == null)
                _instance = new MoveLeft();

            return _instance;
        }
    }

    public bool isMoving;

    void Awake()
    {
        _instance = this;
    }

    public void OnMouseDown()
    {
        isMoving = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
