using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Menu : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRendererMenu;

    [SerializeField] private Sprite loreSprite;
    
    [SerializeField] private VideoPlayer videoPlayer;

    [SerializeField] private GameObject continueToGame;

    [SerializeField] private GameObject goToMenu;

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
        foreach (var gameObject in listToDisable)
        {
            gameObject.SetActive(false);
        }
        
        goToMenu.SetActive(true);
        spriteRendererMenu.sprite = null;
        videoPlayer.gameObject.SetActive(true);
        videoPlayer.Play();
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