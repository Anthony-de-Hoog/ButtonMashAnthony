using UnityEngine;

public class Walking : MonoBehaviour
{
    private Animator animate;
    public float speed = 5;
    private float inputs = 0;
    private float secondsPast = 0;
    public static bool started = false;
    public static bool finished = false;
    public static bool won = false;

    void Start()
    {
        animate = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "WinningLine")
        {
            Debug.Log("You win!");
            animate.SetTrigger("win");
            animate.ResetTrigger("running");
            animate.ResetTrigger("idle");
            won = true;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key pressed");
            started = true;
            inputs += 1;
        }

        if (won)
        {
            animate.ResetTrigger("running");
            animate.SetTrigger("win");
            inputs = 0;
        }

        if (finished)
        {
            Lose();
        }

        if (started && !finished)
        {
            secondsPast += Time.deltaTime;
            if (secondsPast > 0)
            {
                speed = 2 * (inputs / secondsPast);
            }

            if (speed > 0 && !animate.GetCurrentAnimatorStateInfo(0).IsName("running"))
            {
                animate.SetTrigger("running");
                animate.ResetTrigger("idle");

                Debug.Log("!!");
            }

            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else
        {
            speed = 0;
            animate.SetTrigger("idle");
            animate.ResetTrigger("running");
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
