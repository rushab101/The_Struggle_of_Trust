using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCutSceneWorkingDialogue : MonoBehaviour
{
     public Dialogue dialogue;

	public void TriggerDialogue ()
	{
		
		FindObjectOfType<DialogueManagerEnd>().StartDialogue(dialogue);
	}
}
