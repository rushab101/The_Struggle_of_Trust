using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCutSceneWorkingDialogue : MonoBehaviour
{
    public Dialogue dialogue;

	public void TriggerDialogue ()
	{
		
		FindObjectOfType<DialogueManagerIntro>().StartDialogue(dialogue);
	}
}
