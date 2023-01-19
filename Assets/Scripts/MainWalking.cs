using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWalking : MonoBehaviour
{

    private Animator animator;

    public float speed = 5f;
    bool turn = true;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (turn)
        {
            MoveRight();
        }
        if (!turn)
        {
            MoveLeft();
        }

        if (transform.position.x >= 10f)
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
}
