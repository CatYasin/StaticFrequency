using UnityEngine;

public class MorseCooder : MonoBehaviour
{


    private float durButton;
    [SerializeField] private float longThreshold = 0.5f;

    private float durWait;
    [SerializeField] private float BigSpaceThre = 1f;
    [SerializeField]private float doneThre = 5f;
    

    private bool isPressing;
    


    public string Code = "";


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
        Code += "2";
    }


    private void Short()
    {
        Code += "0";
    }

    private void Long()
    {
        Code += "1";
    }

}
