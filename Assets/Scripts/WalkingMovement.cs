using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingMovement : MonoBehaviour
{

    private Animator animator;

    public float speed = 5f;
    bool turn = true;
    private SpriteRenderer spriteRenderer;

    public Vector3 targetChiesa;
    public Vector3 targetCibo;
    public Vector3 targetTower;

    bool goesToQueue = false;

    public bool isScaling;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Debug.Log(transform.localScale + " SIZE");
    }

    // Update is called once per frame
    void Update()
    {
        ChangeAnim();

        

        ChangeSize();
        //if(goesToQueue)
        //{
        //    StartCoroutine(ScaleOverTime(gameObject.transform, new Vector3(0.3f, 0.3f, 0.3f), 3f));
        //}



        if (ChiesaQueueBar.Instance.timeLeft > 20 && CiboQueueBar.Instance.timeLeft > 20 && TowerQueueBar.Instance.timeLeft > 20)
        {
            goesToQueue = false;
            //return to normal size
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, -2.83f, transform.position.z), speed * Time.deltaTime);
            if (turn)
            {
                MoveRight();
            }
            if (!turn)
            {
                MoveLeft();
            }
        } else
        {
            GoToQueue();
        }
       
        if(transform.position.x >= 10f)
        {
            turn = false;
            spriteRenderer.flipX = true;
        }
        if (transform.position.x <= -10f)
        {
            turn = true;
            spriteRenderer.flipX = false;
        }
        

    }

    void MoveRight()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    void MoveLeft()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }

    void ChangeAnim()
    {
        if(transform.position == targetChiesa || transform.position == targetCibo || transform.position == targetTower)
        {
            animator.Play("Idle");
        } else
        {
            animator.Play("WalkingAnim");
        }
    }

    IEnumerator ScaleOverTime(Transform objectToScale, Vector3 toScale, float duration)
    {
        //Make sure there is only one instance of this function running
        if (isScaling)
        {
            yield break; ///exit if this is still running
        }
        isScaling = true;

        float counter = 0;

        //Get the current scale of the object to be moved
        Vector3 startScaleSize = objectToScale.localScale;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            objectToScale.localScale = Vector3.Lerp(startScaleSize, toScale, counter / duration);
            yield return null;
        }

        isScaling = false;
    }

    void ChangeSize()
    {
        if(goesToQueue)
        {
            //StartCoroutine(ScaleOverTime(gameObject.transform, new Vector3(0.3f, 0.3f, 0.3f), 3f));
            float newScale = Mathf.Lerp(0.5f, 0.3f, Time.time);
            transform.localScale = new Vector3(newScale, newScale, newScale);
        } else
        {
            float oldScale = Mathf.Lerp(0.3f, 0.5f, Time.time);
            transform.localScale = new Vector3(oldScale, oldScale, oldScale);
        }
    }

    void GoToQueue()
    { // change size
        //transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        goesToQueue = true;

        if (ChiesaQueueBar.Instance.timeLeft < 20 && transform.position.x <= 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetChiesa, speed * Time.deltaTime);
            spriteRenderer.flipX = false;


        } else if (ChiesaQueueBar.Instance.timeLeft < 20 && transform.position.x >= 0)
        {

            transform.position = Vector3.MoveTowards(transform.position, targetChiesa, speed * Time.deltaTime);
            spriteRenderer.flipX = true;
        }
        else if (CiboQueueBar.Instance.timeLeft < 20 && transform.position.x <= -7)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetCibo, speed * Time.deltaTime);
            spriteRenderer.flipX = false;


        }
        else if (CiboQueueBar.Instance.timeLeft < 20 && transform.position.x >= -7)
        {

            transform.position = Vector3.MoveTowards(transform.position, targetCibo, speed * Time.deltaTime);
            spriteRenderer.flipX = true;
        }
        else if (TowerQueueBar.Instance.timeLeft < 20 && transform.position.x <= 7)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetTower, speed * Time.deltaTime);
            spriteRenderer.flipX = false;


        }
        else if (TowerQueueBar.Instance.timeLeft < 20 && transform.position.x >= 7)
        {

            transform.position = Vector3.MoveTowards(transform.position, targetTower, speed * Time.deltaTime);
            spriteRenderer.flipX = true;
        }

    }
}
