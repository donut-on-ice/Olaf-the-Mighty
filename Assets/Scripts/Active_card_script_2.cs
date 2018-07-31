using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_card_script_2 : MonoBehaviour
{
	private Animator animator;

	private int state = 0;
	public bool paused;
	//private float timer = 0, timerMax = 0;

	void Start()
	{
		animator = GetComponent<Animator>();
		animator.Play("Card_2_idle_deck");

		state = 0;
		paused = true;
	}

	// Update is called once per frame
	void Update()
	{
		switch (state)
		{
			case 0:
				//if (!Waited(1)) return;
				//StartCoroutine(WaitABit());
				if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Card_2_draw"))
				{
					if (paused) Pause();
					animator.Play("Card_2_draw");
				}
				++state;
				break;

			case 1:
				if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Card_2_draw"))
				{
					animator.Play("Card_2_idle_table");
					if (!paused) Pause();
					if (Input.GetMouseButtonDown(0))
					{
						++state;
					}
				}
				break;

			case 2:
				if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Card_2_discard"))
				{
					if (paused) Pause();
					animator.Play("Card_2_discard");
				}
				++state;
				break;

			case 3:
				if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Card_2_discard"))
				{
					animator.Play("Card_2_idle_deck");
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

	/*private bool Waited(float seconds)
	{
		timerMax = seconds;

		timer += Time.deltaTime;

		if (timer >= timerMax)
		{
			return true; //max reached - waited x - seconds
		}

		return false;
	}*/

	/*private IEnumerator WaitABit()
	{
		yield return new WaitForSeconds(3.0f);
	}*/

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

	/*private void OnMouseDown()
	{
		state = 0;
	}*/

}
