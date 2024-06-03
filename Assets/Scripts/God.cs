using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class God : MonoBehaviour
{
    private static God instance;
    public static God AskFor { get => instance; }
    public void Awake()
    {
        instance = this;
    }
    //--------------------------------//
    //--------- ^ ASK FOR ^ ----------//
    //--------------------------------//

    [HideInInspector] public int coins;
    [SerializeField] private TMP_Text coinText;
    
    [Header("Player Items")]
    public GameObject player;
    public List<GameObject> activeHooks;

    public void Start()
    {
        RefreshCoinUI();
    }

    public void RefreshCoinUI()
    {
        coinText.text = coins.ToString();
    }

}
