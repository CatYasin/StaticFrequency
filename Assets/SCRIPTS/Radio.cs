using UnityEngine;

public class Radio : MonoBehaviour
{

    HzManager HM;
    public Transform tuner;
    public float Tunerp;

    [SerializeField] private float hz = 3f;
    [SerializeField] private float minHz = 3f;
    [SerializeField] private float maxHz = 6.4f;

    public AudioClip curClip;

    public Transform[] Tunerps;
    public int curTunerps;

    private void Awake()
    {
        HM = FindFirstObjectByType<HzManager>();
        
    }


    public void ChangeHz(float val = 0.1f)
    {
        hz += val;
        if (hz < minHz)
            hz = minHz;
        if (hz > maxHz)
            hz = maxHz;
        hz = Mathf.Round(hz * 10f) / 10f;

        Listen();
        if (val > 0)
            AddTuner();
        else
            AddTuner(-1);
    }

    private void AddTuner(int p = 1)
    {
        curTunerps += p;
        curTunerps = Mathf.Clamp(curTunerps,0, Tunerps.Length);
        tuner.position = Tunerps[curTunerps].position;
    }

    private void Listen()
    {
        curClip = HM.Listen(hz);
    }
}
