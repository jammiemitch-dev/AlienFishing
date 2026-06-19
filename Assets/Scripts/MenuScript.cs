using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    public AudioSource ButtonClick;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPressed(GameObject buttonGameObject)
    {
        ButtonClick.Play();
        if (buttonGameObject.name.Contains("Quit"))
        {
            Application.Quit();
        }
        else if (buttonGameObject.name.Contains("Start"))
        {
            SceneManager.LoadScene("EarthScene");
        }
    }
}
