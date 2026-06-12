using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private PlayerMovement player;

    //--------------------------
    public float radiusToSpawn = 30;
    public float minimusRadius = 5;
    private float currentRadiusToSpawn;
    public Renderer meshEnemy;
    private bool spawned;
    public float scareFactory = 0.01f;
    private float currentScareFactory;

    //--------------------------
    public float distanceToAfact;
    private float distancePlayer;

    //--------------------------
    private GameController gameController;

    //----controlling spawn
    public float timeToSpawn;
    private float currentTimeToSpawn;

    void Start()
    {
        player = FindObjectOfType(typeof(PlayerMovement)) as PlayerMovement;
        meshEnemy.enabled = false;
        gameController = FindObjectOfType(typeof(GameController)) as GameController;

        currentScareFactory = scareFactory;
        currentRadiusToSpawn = radiusToSpawn;
    }

    void Update()
    {
        transform.LookAt(player.transform);

        currentTimeToSpawn += Time.deltaTime;
        if (currentTimeToSpawn > timeToSpawn && gameController.totalObjectivesOk > 0)
        {
            currentTimeToSpawn = 0;

            Spawn();
        }

        distancePlayer = Vector3.Distance(transform.position, player.transform.position);

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        Ray tempRay = new Ray(
            transform.position + new Vector3(0, transform.localScale.y / 2, 0),
            fwd
        );
        bool rayCastFail = true;
        RaycastHit hitInfo;

        if (Physics.Raycast(tempRay, out hitInfo))
        {
            if (hitInfo.collider.tag == "Player")
            {
                rayCastFail = false;
            }
        }

        if (distancePlayer < distanceToAfact && meshEnemy.isVisible && !rayCastFail)
        {
            player.scare += currentScareFactory / distancePlayer;
        }

        //damage math enemy to player
        if (gameController.totalObjectivesOk > 0)
        {
            currentRadiusToSpawn =
                radiusToSpawn
                - (
                    radiusToSpawn
                    / gameController.GetTotalObjective()
                    * gameController.totalObjectivesOk
                );
        }
    }

    public void Spawn()
    {
        if (gameController.totalObjectivesOk <= 0)
            return;

        meshEnemy.enabled = false;
        Vector3 positionToGo = player.transform.position;

        positionToGo.x += Random.Range(-currentRadiusToSpawn, currentRadiusToSpawn);
        positionToGo.z += Random.Range(-currentRadiusToSpawn, currentRadiusToSpawn);

        positionToGo.y = Terrain.activeTerrain.SampleHeight(positionToGo);

        transform.position = positionToGo;
        spawned = true;
    }

    void OnBecameInvisible()
    {
        if (spawned)
        {
            meshEnemy.enabled = true;
            spawned = false;
        }
    }
}
