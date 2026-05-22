using UnityEngine;
using System.Collections;

public class EarthRotationScript : MonoBehaviour
{
    private float RotationSpeed;

    private void Start()
    {
        RotationSpeed = 7f;
    }

    private void Update()
    {
        transform.Rotate(0, RotationSpeed * Time.deltaTime, 0, 0);
    }

}