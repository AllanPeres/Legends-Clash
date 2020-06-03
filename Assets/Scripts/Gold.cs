using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{

    [SerializeField]
    private int gold;

    [SerializeField]
    private int goldByTime = 10;

    private Text goldText;

    private const int MAX_AMOUNT = 999, MIN_AMOUNT = 0;

    private void Start()
    {
        goldText = GetComponent<Text>();
        UpdateDisplay();
        StartCoroutine(GainGoldByTime());
    }

    private void UpdateDisplay()
    {
        goldText.text = gold.ToString();
    }

    private IEnumerator GainGoldByTime()
    {
        yield return new WaitForSeconds(0.5f);
        GainGold(goldByTime);
        StartCoroutine(GainGoldByTime());
    }

    public void GainGold(int amount)
    {
        if ((gold + amount< MAX_AMOUNT))
        {
            gold += amount;
            UpdateDisplay();
        }
    }

    public void SpendGold(int amount)
    {
        Debug.Log("Before spend Gold: " + gold + " - amount:" + amount);
        if (gold - amount >= MIN_AMOUNT)
        {
            gold -= amount;
            Debug.Log("After spend Gold: " + gold + " - amount:" + amount);
            UpdateDisplay();
        }
    }

    public bool HasEnought(int amount)
    {
        return gold >= amount;
    }
}
