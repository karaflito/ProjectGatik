using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildScritp : MonoBehaviour
{
    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.rotation;
    }

    void LateUpdate()
    {
        transform.rotation = initialRotation;
    }
}
