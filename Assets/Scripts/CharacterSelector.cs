using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterSelector : MonoBehaviour
{
    [SerializeField]
    private Character characterPrefab;

    [SerializeField]
    private DefenderSpawner defenderSpawner;

    private Gold gold;

    private void Start()
    {
        gold = FindObjectOfType<Gold>();
        if (!gold)
            Debug.LogError("There is no object of gold type");
    }

    public void Summon()
    {
        if (gold.HasEnought(characterPrefab.cost))
        {
            gold.SpendGold(characterPrefab.cost);
            defenderSpawner.SummonCharacter(characterPrefab);
        }
    }
}
