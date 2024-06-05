using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHead : MonoBehaviour
{
    public float rotationSpeed = 20.0f;

    void Update()
    {
        // Rota el objeto permanentemente
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
