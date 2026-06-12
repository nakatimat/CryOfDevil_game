using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PagesController : MonoBehaviour
{
    private PlayerConfig playerConfig;
    public bool[] pages;

    void Start()
    {
        playerConfig = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerConfig>();
    }

    void Update() { }
}
