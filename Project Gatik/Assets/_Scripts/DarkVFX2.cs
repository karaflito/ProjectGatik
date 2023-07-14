using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkVFX2 : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 direction;
    private PlayerMovement playerMovement;
    private Vector3 savedDirection;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        savedDirection = playerMovement.LastDirection;
        float angle = Mathf.Atan2(savedDirection.y, savedDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    // Update is called once per frame
    void Update()
    {
        direction = savedDirection.normalized;
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
}
