using UnityEngine;
using System.Collections;

public static class MorseAudioGenerator
{
    static int sampleRate = 44100;
    static float frequency = 750f; // morse bip frekansý

    // Ses üret
    public static AudioClip GenerateTone(float duration)
    {
        int sampleLength = (int)(sampleRate * duration);
        float[] samples = new float[sampleLength];

        for (int i = 0; i < sampleLength; i++)
        {
            samples[i] = Mathf.Sin(2 * Mathf.PI * frequency * i / sampleRate) * 0.4f;
        }

        AudioClip clip = AudioClip.Create("MorseTone", sampleLength, 1, sampleRate, false);
        clip.SetData(samples, 0);
        return clip;
    }
}
