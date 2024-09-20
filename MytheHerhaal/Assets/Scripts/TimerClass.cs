using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timer : MonoBehaviour
{

    public Walking script;
    static public float time = 6;
    private TMP_Text scoreField;

    void Start()
    {
        scoreField = GetComponent<TMP_Text>();
        script = GameObject.Find("Player").GetComponent<Walking>();

    }

    void Update()
    {
        scoreField.text = "" + Mathf.RoundToInt(time);
        if (Walking.started == true && Walking.won == false)
        {
            time -= 1 * Time.deltaTime;
        }
        else if (Walking.started == true && Walking.won == true)
        {
            time += 0;
        }

        if (time < 0)
        {
            Walking.finished = true;
            time += 0;
            script.Lose();
        }

    }
}