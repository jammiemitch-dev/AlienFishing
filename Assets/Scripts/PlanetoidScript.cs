using UnityEngine;

public class Planetoid : MonoBehaviour
{
    public float speed;
    public Transform Child;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Child = transform.GetChild(0);
        speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0, 0);
        Child.Rotate(4 * Time.deltaTime, 0, 0, 0);
    }
}
