using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] Transform shootPoint;
    [SerializeField] GameObject projectile;

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
        if(playerMovement.Fired)
        {
            GameObject projectileInstance = Instantiate(projectile, shootPoint.transform.position, Quaternion.identity);
        }

        
    }

    



}
