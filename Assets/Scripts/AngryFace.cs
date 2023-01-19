using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryFace : MonoBehaviour
{

    private Animator animator;

    private static AngryFace _instance;

    private AngryFace() { }

    public static AngryFace Instance
    {
        get
        {
            if (_instance == null)
                _instance = new AngryFace();

            return _instance;
        }
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ChiesaQueueBar.Instance.timeLeft > 20 && CiboQueueBar.Instance.timeLeft > 20 && TowerQueueBar.Instance.timeLeft > 20)
        {
            animator.Play("MadFace1");
        } else if(ChiesaQueueBar.Instance.timeLeft > 10 || CiboQueueBar.Instance.timeLeft > 10 || TowerQueueBar.Instance.timeLeft > 10)
        {
            animator.Play("MadFace2");
        } else if(ChiesaQueueBar.Instance.timeLeft > 0 && CiboQueueBar.Instance.timeLeft > 0 && TowerQueueBar.Instance.timeLeft > 0)
        {
            animator.Play("MadFace3");
        } else
        {
            animator.Play("FunFace");
        }
    }
}
