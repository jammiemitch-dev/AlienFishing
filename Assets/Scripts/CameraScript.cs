using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Unity.Cinemachine;

public class CameraScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private CinemachineInputAxisController cinemachineinput;
    void Start()
    {
        cinemachineinput = GetComponent<CinemachineInputAxisController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            cinemachineinput.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            cinemachineinput.enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
