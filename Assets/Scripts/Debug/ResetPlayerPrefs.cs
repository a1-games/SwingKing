using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ResetPlayerPrefs : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private AutoSavePosition autoSaveScript;
    [SerializeField] private GrapplingGun grapplingGunScript;

    public void ResetAllPlayerPrefs(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //set saved pos to spawnpoint
            autoSaveScript.SavePosToPlayerPref(spawnPoint.position);
            autoSaveScript.SaveRotToPlayerPref(new Quaternion(0,0,0,1));

            //reset plunger to undiscovered
            grapplingGunScript.ActivatePlunger(false);

            //reload scene
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }
    }

}
