using UnityEngine;

public class RandomThings : MonoBehaviour
{
    [SerializeField] private AudioClip[] randomSoundsList;

    private void Start()
    {
        InputReader._instance.onRandomThingsEvent.AddListener(DoRandomThings);
    }

    private void DoRandomThings()
    {
        AudioManager._instance.PlayRandomSound(randomSoundsList);
    }
}
