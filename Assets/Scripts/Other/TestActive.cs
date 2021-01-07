using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestActive : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject hookedGameObject;

    public Button Show;
    public Button Hide;
    
    void Start()
    {
        Show.onClick.RemoveAllListeners();
        Hide.onClick.RemoveAllListeners();
        
        Show.onClick.AddListener(() =>
        {
            hookedGameObject?.SetActive(true);
        });
        
        Hide.onClick.AddListener(() =>
        {
            hookedGameObject?.SetActive(false);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
