using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] Transform shootPoint;
    [SerializeField] GameObject projectile;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float nextFire = 0.0f;


    PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        ProjectileSpawn();
    }


    private void ProjectileSpawn()
    {
        // Check if the player has fired and enough time has passed since the last shot
        if (playerMovement.Fired && Time.time > nextFire)
        {

            Vector3 spawnPosition = shootPoint.position + shootPoint.right * 5f;
            GameObject projectileInstance = Instantiate(projectile, spawnPosition , Quaternion.identity);

            // Update the nextFire time stamp
            nextFire = Time.time + fireRate;
        }

        
    }

    



}
