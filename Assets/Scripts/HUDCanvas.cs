using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDCanvas : MonoBehaviour
{
    [SerializeField] Text levelValue;
    [SerializeField] Text lifeValue;
    [SerializeField] Text coinsValue;

    private int levelCount;
    public int lifeCount;
    private int coinsCount;

    void Start()
    {
        // parse texts to ints
        levelCount = int.Parse(levelValue.text);
        lifeCount = int.Parse(lifeValue.text);
        coinsCount = int.Parse(coinsValue.text);

        LoadValues();
    }

    void LoadValues()
    {
        levelCount = PlayerPrefs.GetInt("level");
        lifeCount = PlayerPrefs.GetInt("life");
        coinsCount = PlayerPrefs.GetInt("coins");

        if (lifeCount == 0) lifeCount = 3;
    }

    public void SetLevelText(int level)
    {
        levelCount = level;
        UpdateUI();
    }

    public void DeductLife()
    {
        lifeCount -= 1;
        UpdateUI();
    }

    public void AddLife()
    {
        lifeCount += 1;
        UpdateUI();
    }

    public void AddCoin()
    {
        coinsCount += 1;

        // add life when collected 7 coins and reset coins to 0
        if (coinsCount == 7)
        {
            lifeCount += 1;
            coinsCount = 0;
        }

        UpdateUI();
    }

    public void UpdateUI()
    {
        PlayerPrefs.SetInt("level", levelCount);
        PlayerPrefs.SetInt("life", lifeCount);
        PlayerPrefs.SetInt("coins", coinsCount);

        levelValue.text = levelCount.ToString();
        lifeValue.text = lifeCount.ToString();
        coinsValue.text = coinsCount.ToString();
    }

}
