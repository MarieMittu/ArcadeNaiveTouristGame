using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    private static MoveRight _instance;

    private MoveRight() { }

    public static MoveRight Instance
    {
        get
        {
            if (_instance == null)
                _instance = new MoveRight();

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
