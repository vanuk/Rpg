using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenManager : MonoBehaviour
{
    public int sc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Scene()
    {
        SceneManager.LoadScene(sc);
    }
}
