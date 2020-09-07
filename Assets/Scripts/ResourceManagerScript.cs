using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManagerScript : MonoBehaviour
{
    //Public Variables
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI minaralText;
    //Private Variables
    private int gold;
    private int mineral;

    void Awake()
    {
        gold = 0;
        mineral = 0;
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
}
