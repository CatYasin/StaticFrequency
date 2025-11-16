using UnityEngine;

public class Test123 : MonoBehaviour
{
    public MorseConverter converter;
    public AudioSource audioSource;

    void Start()
    {
        string morse = "01020110"; // örnek
        AudioClip clip = converter.Convert(morse);
        audioSource.PlayOneShot(clip);
    }

}
