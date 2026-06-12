using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page : MonoBehaviour
{
    private GameObject player;
    private PagesController pg;
    public int pageIdentity;

    private float currentDistanceFromPlayer;
    public float minDistanceToCollect;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pg = player.GetComponent<PagesController>();
        pg.pages[pageIdentity] = true;
    }

    void Update()
    {
        currentDistanceFromPlayer = Vector3.Distance(
            this.transform.position,
            player.transform.position
        );

        if (currentDistanceFromPlayer < minDistanceToCollect)
        {
            CanCollect();
        }
    }

    void CanCollect()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            pg.pages[pageIdentity] = false;
            Destroy(gameObject);
        }
    }
}
