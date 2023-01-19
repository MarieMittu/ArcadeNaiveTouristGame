//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CiboQueueManager : MonoBehaviour
//{
//    private float maxQSize = 30f;
//    private float qSizeLeft;

//    public GameObject smallQ;
//    public GameObject mediumQ;
//    public GameObject largeQ;

//    private static QueueManager _instance;

//    private QueueManager() { }

//    public static QueueManager Instance
//    {
//        get
//        {
//            if (_instance == null)
//                _instance = new QueueManager();

//            return _instance;
//        }
//    }


//    void Awake()
//    {
//        _instance = this;
//    }

//    // Start is called before the first frame update
//    void Start()
//    {
//        qSizeLeft = maxQSize;
//        smallQ.gameObject.SetActive(true);
//        mediumQ.gameObject.SetActive(true);
//        largeQ.gameObject.SetActive(true);
//    }

//    void PplAmount()
//    {
//        if(qSizeLeft >= 20)
//        {
//            smallQ.gameObject.SetActive(true);
//            mediumQ.gameObject.SetActive(true);
//            largeQ.gameObject.SetActive(true);

//        } else if(qSizeLeft < 20 && qSizeLeft >= 10)
//        {
//            smallQ.gameObject.SetActive(true);
//            mediumQ.gameObject.SetActive(true);
//            largeQ.gameObject.SetActive(false);

//        } else if(qSizeLeft > 0 && qSizeLeft < 10)
//        {
//            smallQ.gameObject.SetActive(true);
//            mediumQ.gameObject.SetActive(false);
//            largeQ.gameObject.SetActive(false);
//        }
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (qSizeLeft > 0)
//        {
//            qSizeLeft -= Time.deltaTime;
//            PplAmount();
//        }
//        else
//        {
//            smallQ.gameObject.SetActive(false);
//            FindObjectOfType<GameManager>().EndGame();
//        }
//    }

//    public void Increase()
//    {
//        qSizeLeft += 5f;
//        Debug.Log("Time Increase");
//        if (qSizeLeft > maxQSize)
//        {
//            qSizeLeft = maxQSize;
//        }
//    }
//}
