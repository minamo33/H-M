using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStart : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            OnRetry();
        }
    }
    public void OnRetry()
    {
        SceneManager.LoadScene("InGame");
    }
}
