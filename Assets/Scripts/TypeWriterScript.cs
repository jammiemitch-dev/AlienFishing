using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Typewriter : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    public float speed = 0.0001f;
    private string savedtext;
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        savedtext = textMesh.text;
        StartCoroutine(Type());
    }
    private void Update()
    {
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