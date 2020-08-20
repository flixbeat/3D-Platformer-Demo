using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWinCanvas : MonoBehaviour
{
    [SerializeField] PlayerController playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("TitleScreen");
        }
    }
}
