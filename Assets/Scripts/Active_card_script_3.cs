using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_card_script_3 : MonoBehaviour
{
	private Animator animator3;

	private int state = 0;
	public bool paused;

	void Start()
	{
		animator3 = GetComponent<Animator>();
		animator3.Play("Card_3_idle_deck");

		state = 0;
		paused = true;
	}

	// Update is called once per frame
	void Update()
	{
		switch (state)
		{
			case 0:
				if (!animator3.GetCurrentAnimatorStateInfo(0).IsName("Card_3_draw"))
				{
					if (paused) Pause();
					animator3.Play("Card_3_draw");
				}
				++state;
				break;

			case 1:
				if (!animator3.GetCurrentAnimatorStateInfo(0).IsName("Card_3_draw"))
				{
					animator3.Play("Card_3_idle_table");
					if (!paused) Pause();
					if (Input.GetKeyDown(KeyCode.Space))
					{
						//Pause();		// unpauses
						++state;
					}
				}
				break;

			case 2:
				if (!animator3.GetCurrentAnimatorStateInfo(0).IsName("Card_3_discard"))
				{
					if (paused) Pause();
					animator3.Play("Card_3_discard");
				}
				++state;
				break;

			case 3:
				if (!animator3.GetCurrentAnimatorStateInfo(0).IsName("Card_3_discard"))
				{
					animator3.Play("Card_3_idle_deck");
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
