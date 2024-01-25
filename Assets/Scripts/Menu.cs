using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRendererMenu;

    [SerializeField] private Sprite loreSprite;

    [SerializeField] private GameObject continueToGame;

    [SerializeField] private GameObject[] listToDisable;

    public void LoreExplanation()
    {
        spriteRendererMenu.sprite = loreSprite;
        continueToGame.SetActive(true);
        
        foreach (var gameObject in listToDisable)
        {
            gameObject.SetActive(false);
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("MAP");
    }

    public void Credit()
    {
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
				        Application.Quit();
#endif
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}