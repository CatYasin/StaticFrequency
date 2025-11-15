
using System.Collections.Generic;
using UnityEngine;


public class HzManager : MonoBehaviour
{

    [SerializeField] private float MinHz = 3f;
    [SerializeField] private float MaXHz = 6.4f;

    public Dictionary<float,Hz> LHZ = new Dictionary<float,Hz>();



    private void Awake()
    {
        LHZ.Clear();

        int MinI = (int)(MinHz * 10);
        int MaxI = (int)(MaXHz * 10);


        for (int i = MinI; i <= MaxI;i++)
        {
            float HzVal = (float)i / 10f;
            LHZ.Add(HzVal, new Hz(HzVal));
        }
    }

    public class Hz
    {


        public float HzMark { get; private set; }
        public AudioClip CurAudio { get; private set; } 

        public Hz(float Hz)
        {
            HzMark = Hz;
        }

        public void DiffAudio(AudioClip clip)
        {
            CurAudio = clip;
        }
    }

    public void Publish(float val,AudioClip clip)
    {
        if (val < MinHz || val > MaXHz)
            return;
        if (LHZ.TryGetValue(val, out Hz hz))
        {
            hz.DiffAudio(clip);
        }
        
    }

    public AudioClip Listen(float val)
    {
        LHZ.TryGetValue(val, out Hz cük);
        return cük.CurAudio;
    }
    
    

}
