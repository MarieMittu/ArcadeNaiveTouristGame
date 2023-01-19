using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tourist : MonoBehaviour
{
    private static Tourist _instance;

    private Tourist() { }

    public static Tourist Instance
    {
        get
        {
            if (_instance == null)
                _instance = new Tourist();

            return _instance;
        }
    }

    //public DragAndDrop drad;

    //public GameObject[] tourist;

    public float speed = 1.5f;

    public string CHIESA_TAG = "Chiesa";
    public string TOWER_TAG = "Tower";
    public string CIBO_TAG = "Cibo";

    public GameObject leftArrow;
    public GameObject rightArrow;
    public bool isTouched;
    public GameObject highlighter;
    public float lightTime = 0.25f;

    //private Rigidbody2D myBody;

    private Animator animator;
    public bool inQueue = false;

    public Vector3 targetChiesa;
    public Vector3 targetCibo;
    public Vector3 targetTower;

    public bool isGoingLeft;
    public bool isGoingRight;

    public bool male;
    public bool female;

    void Awake()
    {
        //myBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        leftArrow.SetActive(false);
        rightArrow.SetActive(false);
        isTouched = false;
        StartCoroutine(HighlightTourist());
    }

    void FixedUpdate()
    {
         //myBody.velocity = new Vector2(speed, myBody.velocity.x);

    }

    IEnumerator HighlightTourist()
    {
        yield return new WaitForSeconds(lightTime);
        highlighter.SetActive(true);
        yield return new WaitForSeconds(lightTime);
        highlighter.SetActive(false);
        yield return new WaitForSeconds(lightTime);
        highlighter.SetActive(true);
        yield return new WaitForSeconds(lightTime);
        highlighter.SetActive(false);
        yield return new WaitForSeconds(lightTime);
        highlighter.SetActive(true);
        yield return new WaitForSeconds(lightTime);
        highlighter.SetActive(false);
    }

    public void OnMouseDown()
    {
        isTouched = true;
    }

    void RemoveTourist()
    {
        //Destroy(gameObject);
        Debug.Log("Removed");
        gameObject.SetActive(false);
    }

    void ChooseDirection()
    {
        
       
            if(transform.position.x <= 0 && isGoingLeft)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetCibo, speed * Time.deltaTime);
               
                animator.Play("GoAnim");
                leftArrow.SetActive(false);
                rightArrow.SetActive(false);

                Debug.Log("Go left to cibo " + transform.position.x);
            CiboQueueManager.Instance.Increase();
            CiboQueueBar.Instance.Increase();

        } else if (transform.position.x >= 0 && isGoingLeft)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetChiesa, speed * Time.deltaTime);
                
                animator.Play("GoAnim");
                leftArrow.SetActive(false);
                rightArrow.SetActive(false);
                Debug.Log("Go left to chiesa " + transform.position.x);
            ChisaQueueManager.Instance.Increase();
            ChiesaQueueBar.Instance.Increase();

        } else if (transform.position.x <= 0 && isGoingRight)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetChiesa, speed * Time.deltaTime);

                animator.Play("GoAnim");
                leftArrow.SetActive(false);
                rightArrow.SetActive(false);
                Debug.Log("Go right to chiesa " + transform.position.x);
            ChisaQueueManager.Instance.Increase();
            ChiesaQueueBar.Instance.Increase();


        } else if (transform.position.x >= 0 && isGoingRight)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetTower, speed * Time.deltaTime);

                animator.Play("GoAnim");
                leftArrow.SetActive(false);
                rightArrow.SetActive(false);
                Debug.Log("Go right to tower " + transform.position.x);
            TowerQueueBar.Instance.Increase();
            TowerQueueManager.Instance.Increase();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(CHIESA_TAG))
        {
            //animator.SetBool("inQueue", true);
            animator.Play("Scale");
            Invoke("RemoveTourist", 2f);

            ChisaQueueManager.Instance.Increase();
            ChiesaQueueBar.Instance.Increase();
            //StaminaManager.Instance.Increase();

        }
        else if (collision.gameObject.CompareTag(TOWER_TAG))
        {
            //animator.SetBool("inQueue", true);
            animator.Play("Scale");
            Invoke("RemoveTourist", 2f);

            TowerQueueBar.Instance.Increase();
            TowerQueueManager.Instance.Increase();
            //StaminaManager.Instance.Increase();

        }
        else if (collision.gameObject.CompareTag(CIBO_TAG))
        {
            //animator.SetBool("inQueue", true);
            animator.Play("Scale");
            Invoke("RemoveTourist", 2f);

            CiboQueueManager.Instance.Increase();
            CiboQueueBar.Instance.Increase();
            //StaminaManager.Instance.Increase();

        }
    }

 


    // Update is called once per frame
    void Update()
    {
        if (isTouched)
        {
            leftArrow.SetActive(true);
            rightArrow.SetActive(true);
        }
        if (MoveLeft.Instance.isMoving)
        {
            isGoingLeft = true;
        }
        if (MoveRight.Instance.isMoving)
        {
            isGoingRight = true;
        }

            ChooseDirection();

    }
}
