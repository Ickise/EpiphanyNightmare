using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlayer : MonoBehaviour
{
    public void OnDeath()
    {
        SceneManager.LoadScene("Menu");
    }
}