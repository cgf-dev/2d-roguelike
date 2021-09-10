using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshairs : MonoBehaviour
{
    public float rotationSpeed = 100f;


    private void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, rotationSpeed) * Time.deltaTime);
    }
}
