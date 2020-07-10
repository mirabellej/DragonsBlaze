using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [Tooltip("Particle Effects Prefab on Enemy")] [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] float fxDuration = 10f;
    [SerializeField] int scoreIncrease = 10;
   // [SerializeField] float healthPoints = 100f;
    [SerializeField] int max_hits = 2;

    ScoreBoard scoreBoard;

    void Start()
    {
        // Add box collider
        Collider boxCollider = gameObject.AddComponent<BoxCollider>(); // add box collider
        boxCollider.isTrigger = false; // make sure it is not a trigger collider

        scoreBoard = FindObjectOfType<ScoreBoard>();
    }


    public void OnParticleCollision(GameObject other)
    {
        print(max_hits);
        scoreBoard.ScoreHit(scoreIncrease);
        max_hits--;
       if (max_hits == 0)
        {
            KillEnemy();
        }

    }

    public void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
        Destroy(fx, fxDuration);
    }

}
