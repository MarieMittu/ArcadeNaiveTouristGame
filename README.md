# Q-rence: Tourist vs. Tourists
Q-rence is a 2D arcade game, kind of endless sorting (*not endless runner!*), developed in Unity. Here I will explain some functionality of the game logic. You can also try this game on a [TestFlight](https://testflight.apple.com/join/yRu6w645).
## How To Play
In the game there are 3 queues and a tourist walking around waiting for any of the queues to become smaller. Your aim is to lead the appearing tourists to the queues, so that none of them finishes and the walking guy remains angry.
![IMG_4160](https://user-images.githubusercontent.com/92306135/214847972-e897b7bd-3f82-4a02-952f-7b58aeaf8fe5.PNG)
Every time the new tourist is spawned, you have to tap on them, so that 2 arrows will appear, and you can choose the direction to a queue.
![IMG_4159](https://user-images.githubusercontent.com/92306135/214848713-335de98f-0f1b-4cb2-9a9d-752bfb3fb9d2.PNG)
## The Code Snippet: Arrows and Directions
Firstly, in Unity editor make the sprites of RightArrow and LeftArrow children of the Tourist prefab. Then, in the C# script:
```c#
public class Tourist : MonoBehaviour
{
    public bool isTouched;
    void Start()
        {
          leftArrow.SetActive(false);
          rightArrow.SetActive(false);
          isTouched = false;
        }
     public void OnMouseDown()
        {
          isTouched = true;
        }
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
     // a function to define the moving direction for a tourist, connectin the tapped arrow, tourist's position and positions of places to visit
     void ChooseDirection()
        {
          if(transform.position.x <= 0 && isGoingLeft)
            {
              transform.position = Vector3.MoveTowards(transform.position, targetCibo, speed * Time.deltaTime);

              animator.Play("GoAnim");
              leftArrow.SetActive(false);
              rightArrow.SetActive(false);
              CiboQueueManager.Instance.Increase();
              CiboQueueBar.Instance.Increase();

            } else if (transform.position.x >= 0 && isGoingLeft)
            {
               transform.position = Vector3.MoveTowards(transform.position, targetChiesa, speed * Time.deltaTime);

               animator.Play("GoAnim");
               leftArrow.SetActive(false);
               rightArrow.SetActive(false);
               ChisaQueueManager.Instance.Increase();
               ChiesaQueueBar.Instance.Increase();

            } else if (transform.position.x <= 0 && isGoingRight)
            {
              transform.position = Vector3.MoveTowards(transform.position, targetChiesa, speed * Time.deltaTime);

              animator.Play("GoAnim");
              leftArrow.SetActive(false);
              rightArrow.SetActive(false);
              ChisaQueueManager.Instance.Increase();
              ChiesaQueueBar.Instance.Increase();


            } else if (transform.position.x >= 0 && isGoingRight)
            {
              transform.position = Vector3.MoveTowards(transform.position, targetTower, speed * Time.deltaTime);

              animator.Play("GoAnim");
              leftArrow.SetActive(false);
              rightArrow.SetActive(false);
              TowerQueueBar.Instance.Increase();
              TowerQueueManager.Instance.Increase();
            }
        }
}
```
To detect, whether the tourist is moving left or right, create 2 supportive scripts: `MoveLeft` and `MoveRight` and attach them to the left and right arrows respectively.
```c#
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
```
```c#
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
```
## The Code Snippet: Behaviour of the Walking Guy
Every time a queue becomes smaller, the walking tourist immediately moves there.

https://user-images.githubusercontent.com/92306135/214857400-eb7d79cd-097a-4704-80ad-59e7fe5ff205.mp4

How to write this logic in a script?
Declare variables: bools, animator, positions, etc.
```c#
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
}
```
Get components:
```c#
public class WalkingMovement : MonoBehaviour
{
   // previous code
   
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
}
```
Define methods for the default walking left-right and vice versa, while the queues are all too long:
```c#
public class WalkingMovement : MonoBehaviour
{
   // previous code
   
   void MoveRight()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    void MoveLeft()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
}
```
Then create a method for moving to the shortest queue:
```c#
public class WalkingMovement : MonoBehaviour
{
   // previous code
   
   void GoToQueue()
    {
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
```
When the walking guy reaches the queue, he should stop walking and stay still. Write a method for that as well:
```c#
public class WalkingMovement : MonoBehaviour
{
   // previous code
   
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
}
```
And finally put everything into the `Update`:
```c#
public class WalkingMovement : MonoBehaviour
{
   // previous code
   
  void Update()
    {
        ChangeAnim();
        if (ChiesaQueueBar.Instance.timeLeft > 20 && CiboQueueBar.Instance.timeLeft > 20 && TowerQueueBar.Instance.timeLeft > 20)
        {
            goesToQueue = false;
            //return to normal size
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, -2.83f, transform.position.z), speed *            Time.deltaTime);
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
}
```
