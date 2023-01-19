using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouristSpawner : MonoBehaviour
{
    private static TouristSpawner _instance;

    private TouristSpawner() { }

    public static TouristSpawner Instance
    {
        get
        {
            if (_instance == null)
                _instance = new TouristSpawner();

            return _instance;
        }
    }

    [SerializeField]
    private GameObject[] touristReference;


    public GameObject spawnedTourist;

    //[SerializeField]
    public Transform leftPos, rightPos;
    //public Transform[] spawnPos;


    private int randomIndex;
    public int randomSide;

    public bool onLeft;
    public bool onRight;


    void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTourists()); //first variant
    }

    void Update()
    {
       
    }

    //first variant
    IEnumerator SpawnTourists()
    {

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3, 5));

            randomIndex = Random.Range(0, touristReference.Length);
            randomSide = Random.Range(0, 2);

            spawnedTourist = Instantiate(touristReference[randomIndex]);

            //left side
            if (randomSide == 0)
            {
                spawnedTourist.transform.position = leftPos.position;
                onLeft = true;
                //spawnedTourist.GetComponent<Tourist>().speed = Random.Range(2, 4);

            }
            else
            {
                //right side
                spawnedTourist.transform.position = rightPos.position;
                onRight = true;
                //spawnedTourist.GetComponent<Tourist>().speed = Random.Range(2, 4);

            }
        }
    }

    //public IEnumerator SpawnTourists(int touristNum)
    //{
    //    while(true)
    //    {
    //        yield return new WaitForSeconds(Random.Range(4, 7));
    //        for (int i = 0; i < touristNum; i++)
    //        {
    //            randomIndex = Random.Range(0, touristReference.Length);
    //            randomSide = Random.Range(0, 2);

    //            //spawnedTourist = Instantiate(touristReference[randomIndex]);

    //            if (randomSide == 0)
    //            {
    //                Instantiate(touristReference[randomIndex], leftPos.position, Quaternion.identity);
    //            }
    //            else
    //            {
    //                Instantiate(touristReference[randomIndex], rightPos.position, Quaternion.identity);
    //            }


    //        }
    //    }
    //}

}