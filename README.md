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
```
