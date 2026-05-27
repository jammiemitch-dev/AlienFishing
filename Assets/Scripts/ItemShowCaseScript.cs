using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemShowCaseScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //for some reason the script wouldnt work unless these were public ---
    public TextMeshProUGUI textbox;
    public Image img;
    //-------------------------------------------------------------------------
    private float ScaleStart;
    private float ScaleEnd;
    private RectTransform rectTransform;
    private RectTransform ImgTransform;
    public float LerpSpeed;


    private float freq = 0.66f;

    void Start()
    {
        img = GetComponentInChildren<Image>();
        rectTransform = GetComponent<RectTransform>();
        ScaleStart = 0;
        ScaleEnd = 1;


        ImgTransform = img.gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Change LerpSpeed depeding on if GameObject is coming or going
        if (ScaleEnd == 1)
        {
            LerpSpeed = 2.2f;
        }
        else
        {
            LerpSpeed = 4f;
        }



        //If gameobject scale isnt where it should be or "ScaleEnd"
        if (transform.localScale.x != ScaleEnd)
        {
            ChangeScale();
        }

        if (Input.anyKeyDown && !Input.GetKey(KeyCode.Space))
        {
            LerpThenDisable();
        }

        RotateSprite();



        if (ScaleStart < 0.01f && ScaleEnd == 0)
        {
            gameObject.SetActive(false);
        }


        


    }
    private void OnEnable()
    {
        ScaleStart = 0;
        ScaleEnd = 1;
    }



    void ChangeScale()
    {
        ScaleStart = Mathf.Lerp(ScaleStart, ScaleEnd, LerpSpeed * Time.deltaTime);
        rectTransform.localScale = new Vector3(ScaleStart,ScaleStart,ScaleStart);
    }

    //Changes ScaleEnd so that the update function still runs the same but the Lerp has a new Goal
    void LerpThenDisable()
    {
        ScaleEnd = 0; 
    }


    public void SetValues(Item item)
    {
        textbox.text = item.name;
        img.sprite = item.Sprite;


        if (item.rarity != Item.Rarity.Common)
        {
            textbox.color = Color.turquoise;
        }
        else
        {
            textbox.color = Color.white;
        }
    }



    void RotateSprite()
    {
        ///ROTATION STUFF
        ///
        // 10 represents the amplitude
        float y = Mathf.Sin(Time.time * freq) * 10f;
        ImgTransform.localEulerAngles = new Vector3(0, 0, y);
        Debug.Log(y);
    }
}
