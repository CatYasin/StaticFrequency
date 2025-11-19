using System.Collections;
using UnityEngine;

public class MorsePlayer : MonoBehaviour
{
    public AudioSource source;

    public float shortDur = 0.1f;
    public float longDur = 0.3f;
    public float spaceDur = 0.05f;

    private Coroutine Playco;


    [ContextMenu("---PLAY---")]
    public void PlayMorse(string code)
    {
        if (Playco != null)
        {
            Playco = null;
        }
        Playco = StartCoroutine(Play(code));
    }

    private void Start()
    {
        PlayMorse("222100020121000201");
    }


    private IEnumerator Play(string code)
    {
        foreach (char c in code)
        {
            if (c == '0') // Short
            {
                source.PlayOneShot(MorseAudioGenerator.GenerateTone(shortDur));
                yield return new WaitForSeconds(shortDur + spaceDur);
            }
            else if (c == '1') // Long
            {
                source.PlayOneShot(MorseAudioGenerator.GenerateTone(longDur));
                yield return new WaitForSeconds(longDur + spaceDur);
            }
            else if (c == '2') // Kelime boþluðu
            {
                yield return new WaitForSeconds(0.4f);
            }
        }
    }
}
