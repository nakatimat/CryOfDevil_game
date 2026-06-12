using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int totalObjectivesOk = 0;
    private int totalObjectives;

    void Start()
    {
        ObjectiveController[] objectives =
            FindObjectsOfType(typeof(ObjectiveController)) as ObjectiveController[];
        totalObjectives = objectives.Length;
    }

    void Update()
    {
        if (totalObjectivesOk == totalObjectives)
        {
            Application.LoadLevel("WinGame");
        }
    }

    public int GetTotalObjective()
    {
        return totalObjectives;
    }
}
