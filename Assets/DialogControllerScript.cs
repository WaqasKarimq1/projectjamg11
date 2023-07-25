using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogControllerScript : MonoBehaviour
{
    public GameObject DialogBox;
    public TextMeshProUGUI Dialog;
    string DialogText;
    public Image SpeakingCharacter;
    public Sprite[] Characters = new Sprite[5];
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCutScene(int cutSceneID)
    {
        if (cutSceneID == 0) { StartCoroutine(IntroDialog()); }
        if (cutSceneID == 1) { StartCoroutine(WaveOneEnd()); }
        if (cutSceneID == 2) { StartCoroutine(WaveTwoEnd()); }
        if (cutSceneID == 3) { StartCoroutine(WaveThreeEnd()); }
        if (cutSceneID == 4) { StartCoroutine(WaveFourEnd()); }
        if (cutSceneID == 5) { StartCoroutine(WaveFiveEnd()); }
        if (cutSceneID == 6) { StartCoroutine(WaveTwoStart()); }
        if (cutSceneID == 7) { StartCoroutine(WaveThreeStart()); }
        if (cutSceneID == 8) { StartCoroutine(WaveFourStart()); }
        if (cutSceneID == 9) { StartCoroutine(WaveFiveStart()); }
    }

    public IEnumerator IntroDialog()
    {
        SpeakingCharacter.sprite = Characters[0];
        DialogText = "Greer'sa is inside his ship turning everything on";
        Dialog.text = "";
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < DialogText.Length; i++)
        {
            Dialog.text += DialogText[i];
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        SpeakingCharacter.sprite = Characters[1];
        DialogText = "Alright Scarlet, we have a big bounty to catch today!";
        Dialog.text = "";
        for (int i = 0; i < DialogText.Length; i++)
        {
            Dialog.text += DialogText[i];
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        SpeakingCharacter.sprite = Characters[0];
        DialogText = "The ship's computer awakens";
        Dialog.text = "";
        for (int i = 0; i < DialogText.Length; i++)
        {
            Dialog.text += DialogText[i];
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        SpeakingCharacter.sprite = Characters[2];
        DialogText = "New job already? What is the name of today's bounty?";
        Dialog.text = "";
        for (int i = 0; i < DialogText.Length; i++)
        {
            Dialog.text += DialogText[i];
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        SpeakingCharacter.sprite = Characters[1];
        DialogText = "The leader of the Nagradas organization";
        Dialog.text = "";
        for (int i = 0; i < DialogText.Length; i++)
        {
            Dialog.text += DialogText[i];
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        SpeakingCharacter.sprite = Characters[2];
        DialogText = "Nagradas organization, also known as the ‘Back Alley Bounty.’ they are an illegal bounty hunter group which are most known to hunt political officials. They are suspected to have killed the Dependency Theta president.";
        Dialog.text = "";
        for (int i = 0; i < DialogText.Length; i++)
        {
            Dialog.text += DialogText[i];
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        SpeakingCharacter.sprite = Characters[1];
        DialogText = "Scarlet you are doing it again. I don’t need to know their entire history. Do you have any information about their leader?";
        Dialog.text = "";
        for (int i = 0; i < DialogText.Length; i++)
        {
            Dialog.text += DialogText[i];
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        SpeakingCharacter.sprite = Characters[2];
        DialogText = "Not at the current moment. perhaps if we get some information on their leader if we engaged his lackeys.";
        Dialog.text = "";
        for (int i = 0; i < DialogText.Length; i++)
        {
            Dialog.text += DialogText[i];
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        SpeakingCharacter.sprite = Characters[1];
        DialogText = "Guess I shouldn't be too surprised that one knows anything about this guy if he killed a president.";
        Dialog.text = "";
        for (int i = 0; i < DialogText.Length; i++)
        {
            Dialog.text += DialogText[i];
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        SpeakingCharacter.sprite = Characters[2];
        DialogText = "Nagradas was last seen near Dependency Eta. that would be a good place to start.";
        Dialog.text = "";
        for (int i = 0; i < DialogText.Length; i++)
        {
            Dialog.text += DialogText[i];
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        SpeakingCharacter.sprite = Characters[1];
        DialogText = "Alright, time to show what a bounty hunter truly Hunt’s!";
        Dialog.text = "";
        for (int i = 0; i < DialogText.Length; i++)
        {
            Dialog.text += DialogText[i];
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        DialogBox.SetActive(false);
        yield return new WaitForSeconds(1f);
        GetComponent<GameController>().NextWave();
        
    }

    IEnumerator WaveOneEnd()
    {
        SpeakingCharacter.sprite = Characters[2];
        DialogText = "I haven't gotten enough information yet. Let's look around here a bit more before we move on.";
        Dialog.text = "";
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < DialogText.Length; i++)
        {
            Dialog.text += DialogText[i];
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        SpeakingCharacter.sprite = Characters[1];
        DialogText = "Alright but let's stop by a nearby planet. Those goons drop some Gems for an upgrade or 2.";
        Dialog.text = "";
        for (int i = 0; i < DialogText.Length; i++)
        {
            Dialog.text += DialogText[i];
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        GetComponent<GameController>().UpgradeMenu.SetActive(true);
        DialogBox.SetActive(false);
    }

    IEnumerator WaveTwoStart()
    {
        SpeakingCharacter.sprite = Characters[1];
        DialogText = "Ok, let’s get this over with.";
        Dialog.text = "";
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < DialogText.Length; i++)
        {
            Dialog.text += DialogText[i];
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        SpeakingCharacter.sprite = Characters[2];
        DialogText = "New enemy approaching! Its ship parts seem very weak but have a powerful shield. So take them a bit seriously.";
        Dialog.text = "";
        for (int i = 0; i < DialogText.Length; i++)
        {
            Dialog.text += DialogText[i];
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        SpeakingCharacter.sprite = Characters[1];
        DialogText = "Orange beetle ships? Brings back a painful memory.";
        Dialog.text = "";
        for (int i = 0; i < DialogText.Length; i++)
        {
            Dialog.text += DialogText[i];
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        DialogBox.SetActive(false);
    }

    IEnumerator WaveTwoEnd()
    {
        SpeakingCharacter.sprite = Characters[2];
        DialogText = "That last ship you destroyed had some information that the other ships did not have. There is a fleet of ships in the Verbena system. That should be near Dependency Gamma.";
        Dialog.text = "";
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < DialogText.Length; i++)
        {
            Dialog.text += DialogText[i];
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        SpeakingCharacter.sprite = Characters[1];
        DialogText = "Hopefully someone there has info on their boss. Before we got to the Verbena system let's patch you up.";
        Dialog.text = "";
        for (int i = 0; i < DialogText.Length; i++)
        {
            Dialog.text += DialogText[i];
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        GetComponent<GameController>().UpgradeMenu.SetActive(true);
        DialogBox.SetActive(false);
    }

    IEnumerator WaveThreeStart()
    {
        SpeakingCharacter.sprite = Characters[1];
        DialogText = "They weren't kidding about the name ‘Verbena’.";
        Dialog.text = "";
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < DialogText.Length; i++)
        {
            Dialog.text += DialogText[i];
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        SpeakingCharacter.sprite = Characters[2];
        DialogText = "Warning! A new enemy is approaching. These ships seem to be a bit more mobile than what we have seen so far. So watch for unexpected lasers.";
        Dialog.text = "";
        for (int i = 0; i < DialogText.Length; i++)
        {
            Dialog.text += DialogText[i];
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        SpeakingCharacter.sprite = Characters[1];
        DialogText = "Why can’t some people just accept their death.";
        Dialog.text = "";
        for (int i = 0; i < DialogText.Length; i++)
        {
            Dialog.text += DialogText[i];
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        DialogBox.SetActive(false);
    }

    IEnumerator WaveThreeEnd()
    {
        SpeakingCharacter.sprite = Characters[2];
        DialogText = "One of those ships had some Useful information. The leader's name is: ‘Vold'vel.‘ no information comes up if I search for him. If one of the ships here had his name on file there must be a different ship with his location.";
        Dialog.text = "";
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < DialogText.Length; i++)
        {
            Dialog.text += DialogText[i];
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        SpeakingCharacter.sprite = Characters[1];
        DialogText = "More searching? Fine… let's patch you up first.";
        Dialog.text = "";
        for (int i = 0; i < DialogText.Length; i++)
        {
            Dialog.text += DialogText[i];
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        GetComponent<GameController>().UpgradeMenu.SetActive(true);
        DialogBox.SetActive(false);
    }

    IEnumerator WaveFourStart()
    {
        SpeakingCharacter.sprite = Characters[2];
        DialogText = "I am detecting a high number of enemies. Seems like a full-out attack to destroy you.";
        Dialog.text = "";
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < DialogText.Length; i++)
        {
            Dialog.text += DialogText[i];
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        SpeakingCharacter.sprite = Characters[1];
        DialogText = "Finally! They are taking me seriously. One of these ships must know where Vold’vel is.";
        Dialog.text = "";
        for (int i = 0; i < DialogText.Length; i++)
        {
            Dialog.text += DialogText[i];
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        DialogBox.SetActive(false);
    }

    IEnumerator WaveFourEnd()
    {
        SpeakingCharacter.sprite = Characters[2];
        DialogText = "I have a signal on Vold’vel’s location! He is near the planet: ‘03030 Z also known as the ’Dusty Rose’";
        Dialog.text = "";
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < DialogText.Length; i++)
        {
            Dialog.text += DialogText[i];
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        SpeakingCharacter.sprite = Characters[1];
        DialogText = "Finally, those 400,000 Gems are going to be all mine.";
        Dialog.text = "";
        for (int i = 0; i < DialogText.Length; i++)
        {
            Dialog.text += DialogText[i];
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        GetComponent<GameController>().UpgradeMenu.SetActive(true);
        DialogBox.SetActive(false);
    }

    IEnumerator WaveFiveStart()
    {
        SpeakingCharacter.sprite = Characters[3];
        DialogText = "Who could have thought, A bounty hunter I wanted to hire is now after my bounty.";
        Dialog.text = "";
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < DialogText.Length; i++)
        {
            Dialog.text += DialogText[i];
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        SpeakingCharacter.sprite = Characters[1];
        DialogText = "I am only here for your head, not for small talk.";
        Dialog.text = "";
        for (int i = 0; i < DialogText.Length; i++)
        {
            Dialog.text += DialogText[i];
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        SpeakingCharacter.sprite = Characters[3];
        DialogText = "Straight to the point I see. I liked that about you.";
        Dialog.text = "";
        for (int i = 0; i < DialogText.Length; i++)
        {
            Dialog.text += DialogText[i];
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        SpeakingCharacter.sprite = Characters[2];
        DialogText = "Greer'sa watch out, I am detecting multiple enemy ships. Vold’vel is not here alone. I have also never seen that ship before so try to be as cautious as possible.";
        Dialog.text = "";
        for (int i = 0; i < DialogText.Length; i++)
        {
            Dialog.text += DialogText[i];
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        DialogBox.SetActive(false);
    }

    IEnumerator WaveFiveEnd()
    {
        GetComponent<GameController>().FinishGame();
        SpeakingCharacter.sprite = Characters[1];
        DialogText = "AHAHAHA! Not even Vold’vel is a match for the greatest Bounty Hunter to ever live! Time to party back at Umooran. All the drinks are on ME!";
        Dialog.text = "";
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < DialogText.Length; i++)
        {
            Dialog.text += DialogText[i];
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        SpeakingCharacter.sprite = Characters[1];
        DialogText = "Thought you would say that. I already booked a Reservation.";
        Dialog.text = "";
        for (int i = 0; i < DialogText.Length; i++)
        {
            Dialog.text += DialogText[i];
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        DialogBox.SetActive(false);
    }
}
