using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI collectibleText;
    private int collectibleCount = 0;

    public void AddCollectible(int amount)
    {
        collectibleCount += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        collectibleText.text = "Collectibles: " + collectibleCount;
    }
}