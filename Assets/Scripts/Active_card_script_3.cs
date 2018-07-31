using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_card_script_3 : MonoBehaviour
{
	private Animator animator;

	private int state = 0;
	public bool paused;

	void Start()
	{
		animator = GetComponent<Animator>();
		animator.Play("Card_3_idle_deck");

		state = 0;
		paused = true;
	}

	// Update is called once per frame
	void Update()
	{
		switch (state)
		{
			case 0:
				//System.Threading.Thread.Sleep(2000);
				if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Card_3_draw"))
				{
					if (paused) Pause();
					animator.Play("Card_3_draw");
				}
				++state;
				break;

			case 1:
				if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Card_3_draw"))
				{
					animator.Play("Card_3_idle_table");
					if (!paused) Pause();
					if (Input.GetMouseButtonDown(0))
					{
						++state;
					}
				}
				break;

			case 2:
				if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Card_3_discard"))
				{
					if (paused) Pause();
					animator.Play("Card_3_discard");
				}
				++state;
				break;

			case 3:
				if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Card_3_discard"))
				{
					animator.Play("Card_3_idle_deck");
					if (!paused) Pause();

					// on click
					/*if (Input.GetMouseButtonDown(0))
					{
						state = 0;
					}*/

					// auto
					state = 0;
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
