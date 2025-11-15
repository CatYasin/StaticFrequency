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
        tuner.position = new Vector3(tuner.position.x + (Tunerp * p), tuner.position.y, tuner.position.z);
    }

    private void Listen()
    {
        curClip = HM.Listen(hz);
    }
}
