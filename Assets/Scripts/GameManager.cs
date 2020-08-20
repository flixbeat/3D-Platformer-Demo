using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] int currentLevel;
    private HUDCanvas hudCanvasScript;


    // Start is called before the first frame update
    void Start()
    {
        hudCanvasScript = GameObject.FindWithTag("HUDCanvas").GetComponent<HUDCanvas>();
        hudCanvasScript.SetLevelText(currentLevel);
    }

}
