using UnityEngine;

public class LerpUIScript : MonoBehaviour
{
    //Instead of having the same code in multiple scripts use this instead -
    public Vector3 OpenedPosition;
    public Vector3 ClosedPosition;
    private RectTransform RectTransform;
    public bool IsOpened;
    public float LerpSpeed;
    public KeyCode InputKey;

    [SerializeField] private GameObject FishingSlider;
    //All UI elements to ignore
    public GameObject[] UI_Elements;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject gm in UI_Elements)
        {
            if (gm.GetComponent<LerpUIScript>().IsOpened || FishingSlider.activeSelf)
            {
                IsOpened = false;
            }
        }

        
        if (Input.GetKeyDown(InputKey))
        {
            IsOpened = !IsOpened;
        }


        if (IsOpened)
        {
            RectTransform.anchoredPosition = Vector2.Lerp(RectTransform.anchoredPosition, OpenedPosition, LerpSpeed * Time.deltaTime);
        }
        else
        {
            RectTransform.anchoredPosition = Vector2.Lerp(RectTransform.anchoredPosition, ClosedPosition, LerpSpeed * Time.deltaTime);
        }
    }
}
