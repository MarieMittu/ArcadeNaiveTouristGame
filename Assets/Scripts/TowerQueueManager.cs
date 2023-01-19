using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerQueueManager : MonoBehaviour
{
    private float maxPpl = 30f;
    private float pplLeft;

    public GameObject smallQ;
    public GameObject mediumQ;
    public GameObject largeQ;

    private static TowerQueueManager _instance;

    private TowerQueueManager() { }

    public static TowerQueueManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new TowerQueueManager();

            return _instance;
        }
    }


    void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        pplLeft = maxPpl;
        smallQ.gameObject.SetActive(true);
        mediumQ.gameObject.SetActive(true);
        largeQ.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (pplLeft > 0)
        {
            pplLeft -= Time.deltaTime;
            ControlAmount();

        }
        else
        {
            //StaminaManager.Instance.Decrease();
            smallQ.gameObject.SetActive(false);
            mediumQ.gameObject.SetActive(false);
            largeQ.gameObject.SetActive(false);
            //FindObjectOfType<GameManager>().EndGame();
        }
    }

    void ControlAmount()
    {
        if (pplLeft >= 20)
        {
            smallQ.gameObject.SetActive(true);
            mediumQ.gameObject.SetActive(true);
            largeQ.gameObject.SetActive(true);

        }
        else if (pplLeft < 20 && pplLeft >= 10)
        {
            smallQ.gameObject.SetActive(true);
            mediumQ.gameObject.SetActive(true);
            largeQ.gameObject.SetActive(false);

        }
        else if (pplLeft < 10 && pplLeft > 0)
        {
            smallQ.gameObject.SetActive(true);
            mediumQ.gameObject.SetActive(false);
            largeQ.gameObject.SetActive(false);

        }
    }

    public void Increase()
    {
        pplLeft += 2f;
        Debug.Log("Time Increase");
        if (pplLeft > maxPpl)
        {
            pplLeft = maxPpl;
        }

    }

    public void Decrease()
    {
        pplLeft = 0f;
    }
}
