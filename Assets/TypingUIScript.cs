using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingUIScript : MonoBehaviour
{
    public GameObject TTSObject;
    private TextToSpeechScript _theTextToSpeech;
    public InputField theTypeBox;

    public Dropdown theDropdownList;
    private List<string> theVoiceName;
    private List<Dropdown.OptionData> theOptions = new List<Dropdown.OptionData>();


    // Start is called before the first frame update
    void Start()
    {
        _theTextToSpeech = TTSObject.GetComponent<TextToSpeechScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_theTextToSpeech.NameListReady())
        {
            theVoiceName = _theTextToSpeech.GetName();
            theVoiceName.Sort();
            SetDropdownValues();
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            _theTextToSpeech.SynthesizeThis(theTypeBox.text);
            theTypeBox.text = "";
        }

        if(theDropdownList.captionText.text !="")
        {
            _theTextToSpeech.SetVoice(theDropdownList.captionText.text);
        }
    }

    private void SetDropdownValues()
    {
        foreach(var variable in theVoiceName)
        {
            Dropdown.OptionData newData = new Dropdown.OptionData();
            newData.text = variable;

            theOptions.Add(newData);
        }

        foreach(Dropdown.OptionData message in theOptions)
        {
            theDropdownList.options.Add(message);
        }
    }
}
