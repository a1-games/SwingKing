using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementTrigger : MonoBehaviour
{
    [SerializeField] private string achievementName = "name";
    //Should give the Player a Steam achievement if triggered
    //Once triggered it should become true, never to be set false again

    public void Start()
    {
        if (PlayerPrefs.GetString(achievementName, "false") == "true")
        {
            Death();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Player got the "+achievementName+" achievement!");
            PlayerPrefs.SetString(achievementName, "true");
            Death();
        }
    }

    public void Death()
    {
        Destroy(this.gameObject);
    }
}
