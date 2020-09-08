using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceManagerScript : MonoBehaviour
{
    //Public Variables
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI minaralText;
    public TextMeshProUGUI populationText;
    //Private Variables
    private int gold;
    private int mineral;
    private int populationCurrent;
    private int populationMax;

    void Awake()
    {
        gold = 50;
        mineral = 50;
        populationCurrent = 0;
        populationMax = 5;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = "<sprite index=0> :" + gold;
        minaralText.SetText("<sprite index=1> :" + mineral);
        populationText.SetText("<sprite index=2> :" + populationCurrent + " / " + populationMax);
    }

    public void updateMinaralCount(int change)
    {
        mineral += change;
    }
    public int getMineral()
    {
        return mineral;
    }
    public void updateGoldCount(int change)
    {
        gold += change;
    }
    public int getGold()
    {
        return gold;
    }
    public void updateCurrentPopulationCount(int change)
    {
        populationCurrent += change;
    }
    public int getCurrentPopulation()
    {
        return populationCurrent;
    }
    public void updateMaxPopulationCount(int change)
    {
        populationMax += change;
    }
    public int getMaxPopulation()
    {
        return populationMax;
    }

    public bool canBuy(int goldAmount, int mineralAmount)
    {
        return gold > goldAmount && mineral > mineralAmount;
    }
    public void buyBuilding(int goldAmount, int minaralAmount)
    {
        gold -= goldAmount;
        mineral -= minaralAmount;
    }
}
