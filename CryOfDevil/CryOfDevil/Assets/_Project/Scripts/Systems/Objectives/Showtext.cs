using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Showtext : MonoBehaviour
{
    public Text text;

    [Range(1, 10)]
    public float distance = 3;
    private GameObject player;

    void Start()
    {
        text.enabled = false;
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < distance)
        {
            text.enabled = true;
        }
        else
        {
            text.enabled = false;
        }
    }
}
