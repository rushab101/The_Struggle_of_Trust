using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTirggerNPC2 : MonoBehaviour
{
    
   public Dialogue dialogue;

	public void TriggerDialogue ()
	{
		
		FindObjectOfType<DialogueManagerNPC2>().StartDialogue(dialogue);
	}
}
