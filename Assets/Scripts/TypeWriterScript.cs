using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Typewriter : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    public float speed = 0.03f;
    private string savedtext;

    private LerpUIScript LerpScript;
    bool HasScript = false;
    
    void Start()
    {

        if (GetComponentInParent<LerpUIScript>())
        {
            LerpScript = GetComponentInParent<LerpUIScript>();
            HasScript = true;
        }


        textMesh = GetComponent<TextMeshProUGUI>();
        savedtext = textMesh.text;
        StartCoroutine(Type());
    }
    private void Update()
    {


        if (HasScript)
        {
            if (!LerpScript.IsOpened)
            {
                savedtext = null;
                return;
            }
        }
        

        if(textMesh.text != savedtext)
        {
            savedtext = textMesh.text;
            StartCoroutine(Type());
        }
    }
    IEnumerator Type()
    {
        textMesh.ForceMeshUpdate();
        int totalChars = textMesh.textInfo.characterCount;
        textMesh.maxVisibleCharacters = 0;

        for (int i = 0; i <= totalChars; i++)
        {
            textMesh.maxVisibleCharacters = i;
            yield return new WaitForSeconds(speed);
        }
    }
}