using UnityEngine;

public class MorseCooder : MonoBehaviour
{
    [Header("--------Components--------")]
    public AudioSource audioSource;                                          
                                          
    [Header("------------Code----------")]
    public string Code = "";

    [Header("----User Input Confing----")]
    private float durButton;
    [SerializeField] private float longThreshold = 0.4f;

    private float durWait;
    [SerializeField] private float BigSpaceThre = 1f;
    [SerializeField] private float doneThre = 5f;
    

    private bool isPressing;


    [Header("----Duration Of Spaces----")]
    public float shortDur = 0.1f;
    public float longDur = 0.3f;
    public float spaceDur = 0.05f;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (durWait > BigSpaceThre)
            {
                Space();
            }

            isPressing = true;
            durButton = 0;
            durWait = 0;
        }

        if (isPressing)
        {
            durButton += Time.deltaTime;
        }
        else if (Code.Length > 0 && !isPressing) 
        {
            durWait += Time.deltaTime;
            if (durWait > doneThre)
            {
                Debug.Log(MorseUtility.DigitsToText(Code));
                Code = "";

            }
        }




        if (Input.GetKeyUp(KeyCode.X))
        {
            isPressing = false;

            if (durButton > longThreshold)
            {
                Long();
            }
            else
            {
                Short();
            }

        }

    }


    private void Space()
    {
        Code += "222";
        
    }


    private void Short()
    {
        Code += "0";
        PlayAudio(shortDur);
        
    }

    private void Long()
    {
        Code += "1";
        PlayAudio(longDur);
    }


    private void PlayAudio(float Dur)
    {
        audioSource.PlayOneShot(MorseAudioGenerator.GenerateTone(Dur));

    }

}
