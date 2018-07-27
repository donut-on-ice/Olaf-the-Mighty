using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_card_script_2 : MonoBehaviour
{
	private Animator animator2;

	private int state = 0;
	public bool paused;

	void Start()
	{
		animator2 = GetComponent<Animator>();
		animator2.Play("Card_2_idle_deck");

		state = 0;
		paused = true;
	}

	// Update is called once per frame
	void Update()
	{
		switch (state)
		{
			case 0:
				if (!animator2.GetCurrentAnimatorStateInfo(0).IsName("Card_2_draw"))
				{
					if (paused) Pause();
					animator2.Play("Card_2_draw");
				}
				++state;
				break;

			case 1:
				if (!animator2.GetCurrentAnimatorStateInfo(0).IsName("Card_2_draw"))
				{
					animator2.Play("Card_2_idle_table");
					if (!paused) Pause();
					if (Input.GetKeyDown(KeyCode.Space))
					{
						//Pause();		// unpauses
						++state;
					}
				}
				break;

			case 2:
				if (!animator2.GetCurrentAnimatorStateInfo(0).IsName("Card_2_discard"))
				{
					if (paused) Pause();
					animator2.Play("Card_2_discard");
				}
				++state;
				break;

			case 3:
				if (!animator2.GetCurrentAnimatorStateInfo(0).IsName("Card_2_discard"))
				{
					animator2.Play("Card_2_idle_deck");
					if (!paused) Pause();
					if (Input.GetKeyDown(KeyCode.Space))
					{
						//Pause();		// unpauses
						state = 0;
					}
				}
				break;
		}
	}


	public void Pause()
	{
		paused = !paused;
		if (paused)
		{
			Time.timeScale = 0;
		}
		else if (!paused)
		{
			Time.timeScale = 1;
		}
	}

}
