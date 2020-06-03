using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField]
    private Character characterPrefab;

    public void SelectCharacter(Character selctedCharacter)
    {
        characterPrefab = selctedCharacter;
    }

    public void SummonCharacter()
    {
        if (characterPrefab)
            Instantiate(characterPrefab, transform.position, Quaternion.identity);
    }

    public void SummonCharacter(Character character)
    {
        Instantiate(character, transform.position, Quaternion.identity);
    }
}
