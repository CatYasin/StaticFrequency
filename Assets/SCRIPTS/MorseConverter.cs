using UnityEngine;
using System.Collections.Generic;

public class MorseConverter : MonoBehaviour
{
    public float shortBeep = 0.1f;
    public float longBeep = 0.3f;
    public float silence = 0.1f;
    public int sampleRate = 44100;
    public float frequency = 800f; // beep sesi frekansý

    public AudioClip Convert(string code)
    {
        List<float> samples = new List<float>();

        foreach (char c in code)
        {
            if (c == '0') AddBeep(samples, shortBeep);
            else if (c == '1') AddBeep(samples, longBeep);
            else if (c == '2') AddSilence(samples, silence);
        }

        AudioClip clip = AudioClip.Create("Morse", samples.Count, 1, sampleRate, false);
        clip.SetData(samples.ToArray(), 0);
        return clip;
    }

    void AddBeep(List<float> s, float duration)
    {
        int count = (int)(sampleRate * duration);
        for (int i = 0; i < count; i++)
        {
            float t = (float)i / sampleRate;
            s.Add(Mathf.Sin(2 * Mathf.PI * frequency * t));
        }
    }

    void AddSilence(List<float> s, float duration)
    {
        int count = (int)(sampleRate * duration);
        for (int i = 0; i < count; i++) s.Add(0f);
    }
}