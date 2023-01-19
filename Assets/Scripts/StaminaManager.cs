//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class StaminaManager : MonoBehaviour
//{
//    Image timerBar;
//    private float maxTime = 30f;
//    private float timeLeft;

//    private static StaminaManager _instance;

//    private StaminaManager() { }

//    public static StaminaManager Instance
//    {
//        get
//        {
//            if (_instance == null)
//                _instance = new StaminaManager();

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
//        timerBar = GetComponent<Image>();
//        timeLeft = maxTime;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (timeLeft > 0)
//        {
//            timeLeft -= Time.deltaTime;
//            timerBar.fillAmount = timeLeft / maxTime;
//        }
//        else
//        {
//            Invoke("GameOver", 4f);
//        }
//    }

//    public void Increase()
//    {
//        timeLeft += 5f;
//        Debug.Log("Time Increase");
//        if (timeLeft > maxTime)
//        {
//            timeLeft = maxTime;
//        }
//        timerBar.fillAmount = timeLeft / maxTime;
//    }

//    public void Decrease()
//    {
//        timeLeft = 0f;
//    }

//    public void GameOver()
//    {
//        FindObjectOfType<GameManager>().EndGame();
//    }

//}
