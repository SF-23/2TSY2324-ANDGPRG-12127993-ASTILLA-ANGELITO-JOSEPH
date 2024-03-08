using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] Transform crystal;
    public Transform Crystal { get { return crystal; } }

    [SerializeField] public int playerGold;
    [SerializeField] int startGold;
    [SerializeField] TextMeshProUGUI goldCountTxt;

	private void Awake()
	{
		instance = this; 
	}

	// Start is called before the first frame update
	void Start()
    {
        playerGold = startGold;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGoldTxt();
    }

    void UpdateGoldTxt()
    {
        goldCountTxt.text = "GOLD: " + playerGold;
    }

    public void SpendGold(int towerPrice)
    {
        playerGold -= towerPrice;
    }
}
