using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Walking : MonoBehaviour
{
    private Animator animate;
    public float speed;
    private float inputs = 1;
    private float secondsPast = 1;
    static public bool started = false;
    static public bool finished = false;
    public static bool won = false;
    void Start()
    {
        animate = GetComponent<Animator>();
    }



    void Update()
    {
        if (transform.position.z > 55)
        {
            finished = true;
            Debug.Log("you win");
            animate.SetTrigger("win");
            animate.ResetTrigger("running");
            animate.ResetTrigger("idle");
            won = true;
        }

        secondsPast += 1 * Time.deltaTime;
        if (speed > 1)
        {
            animate.SetTrigger("running");
            animate.ResetTrigger("idle");
        }

        else if (speed <= 1)
        {
            animate.SetTrigger("idle");
            animate.ResetTrigger("running");
        }

        transform.position = transform.position += new Vector3(0, 0, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            started = true;
            inputs += 1;



        }

        if (started == true && finished == false)
        {

            speed = 2 * (inputs / secondsPast);

            if (speed >= 20)
            {
                inputs = secondsPast * 10;
            }

            if (speed < 1)
            {
                inputs = 0;
            }

        }

        else if (started == false && finished == false)
        {
            speed = 0;
        }

        else if (started == true && finished == true)
        {
            speed = 0;
        }
    }
    public void Lose()
    {
        animate.SetTrigger("lose");
        animate.ResetTrigger("running");
        animate.ResetTrigger("idle");
        Debug.Log("You lose");
    }

}