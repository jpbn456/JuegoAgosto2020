using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalText : MonoBehaviour
{
    public Text finalText;
    // Start is called before the first frame update
    void Start()
    {
        finalText.text = "I can't believe it! They actually took down the video. Thanks for your amazing " + (PlayerPrefs.GetInt("CantidadFinalDislikes")) + " dislikes. I know you totally did your best ;) ";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
