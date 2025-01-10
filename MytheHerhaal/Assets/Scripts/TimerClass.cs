using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Walking script;
    public static float time = 6f; // Initial timer value
    private TMP_Text scoreField;

    void Start()
    {
        scoreField = GetComponent<TMP_Text>();
        script = GameObject.Find("Player").GetComponent<Walking>();
    }

    void Update()
    {
        // Update the timer display
        scoreField.text = Mathf.CeilToInt(time).ToString();

        if (Walking.started && !Walking.won && !Walking.finished)
        {
            // Countdown timer during active gameplay
            time -= Time.deltaTime;

            // Check if time has run out
            if (time <= 0)
            {
                time = 0; // Ensure the timer doesn't go negative
                Walking.finished = true;
                script.Lose(); // Trigger lose logic
            }
        }
        else if (Walking.won)
        {
            // Stop the timer when the player wins
            time = Mathf.CeilToInt(time);
        }
    }
}
