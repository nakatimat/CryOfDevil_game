using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveController : MonoBehaviour
{
    private GameController gameController;

    void Start()
    {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
    }

    void Update() { }

    public void Interact()
    {
        gameController.totalObjectivesOk++;
        Destroy(gameObject);
    }
}
