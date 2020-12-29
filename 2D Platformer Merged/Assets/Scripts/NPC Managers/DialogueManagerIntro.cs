using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManagerIntro : MonoBehaviour
{
    public Text nameText;
	public Text dialogueText;

	public Animator animator;

	public Queue<string> sentences;

	

	// Use this for initialization
	void Start () {
		
		sentences = new Queue<string>();
		//PlayerPrefs.DeleteAll();
	}

	public void StartDialogue (Dialogue dialogue)
	{
		
		animator.SetBool("IsOpen", true);

		nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence ()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
		//	StartCoroutine(Test());
			dialogueText.text += letter;
			yield return null;
			yield return null;
			yield return null;
			yield return null;
			yield return null;
			yield return null;
			yield return null;
			yield return null;
			yield return null;
			yield return null;
			yield return null;
			
		}
	}

	
    IEnumerator Test()
    {
        yield return new WaitForSecondsRealtime(10000000000000.0f);
        //  Debug.Log("Hi");
        //  anim.SetBool("setAttack", false);
        
        //  anim.SetBool("downAttack",false);
        // Debug.Log("flag 2");
        // SceneManager.LoadScene("Game Over");
    }


	void EndDialogue()
	{
		animator.SetBool("IsOpen", false);
	}
}
