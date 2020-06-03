using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    private Character characterPrefab;

    [SerializeField] private Character[] possibleCharacters;
    [SerializeField] private float minTime = 3;
    [SerializeField] private float maxTime = 5;
    [SerializeField] private int maximumAttackers = 3;
    [SerializeField] private int attackersCounter = 0;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        if (attackersCounter <= maximumAttackers)
        {
            SelectCharacter();
            SummonCharacter();
        }
        StartCoroutine(Start());
    }

    public void SelectCharacter()
    {
        characterPrefab = possibleCharacters[Random.Range(0, possibleCharacters.Length)];
    }

    public void SummonCharacter()
    {
        if (characterPrefab)
        {
            Character attacker = Instantiate(characterPrefab, transform.position, Quaternion.identity);
            attacker.transform.parent = gameObject.transform;
            attackersCounter = GetComponents<Character>().Length;
        }
    }
}
