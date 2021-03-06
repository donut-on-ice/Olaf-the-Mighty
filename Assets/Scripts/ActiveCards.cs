﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCards : MonoBehaviour
{
    private static readonly string IDLE_TABLE = "Idle Table";

    private readonly Animator animator;
    public static GameObject cardLeft, cardMiddle, cardRight;
    private Renderer faceLeft, faceMiddle, faceRight;
    public static GameEvent eventLeft, eventMiddle, eventRight;
    private TextMesh tagLeft, tagMiddle, tagRight;
    private Renderer tagLeftR, tagMiddleR, tagRightR;

	public static int men, morale, food, loot;

    private int scrollState = 0; 

	Ray ray;
	RaycastHit hit;

	static Material[] FACES;
    static Material[] FONTS;

    static GameEvent[] gameEvents;
    static GameEvent[] debug;

    void Start ()
    {
        FACES = new Material[] {
            Resources.Load<Material>("Cards/id00m"),
            Resources.Load<Material>("Cards/id01m"),
            Resources.Load<Material>("Cards/id02m"),
            Resources.Load<Material>("Cards/id03m"),
            Resources.Load<Material>("Cards/id04m"),
            Resources.Load<Material>("Cards/id05m"),
            Resources.Load<Material>("Cards/id06m"),
            Resources.Load<Material>("Cards/id07m"),
            Resources.Load<Material>("Cards/id08m"),
            Resources.Load<Material>("Cards/id09m"),
            Resources.Load<Material>("Cards/id10m"),
            Resources.Load<Material>("Cards/id11m")
        };
        
        FONTS = new Material[] {
            Resources.Load<Material>("Fonts/DarkRed Text"),
            Resources.Load<Material>("Fonts/DarkPurple Text"),
            Resources.Load<Material>("Fonts/BrightRed Text"),
            Resources.Load<Material>("Fonts/BrightBlue Text")
        };

        gameEvents = new GameEvent[] {
    /* 000 */new GameEvent(),

    /* 001 */new GameEvent(0, 0, 5, -20,

            "Trade", "Local Market",

            "The nearby villagers\n" +
            "have gathered to sell\n" +
            "their goods.",

            "Bought some" +
            "food for loot",

            5, 3),

    /* 002 */new GameEvent(2, -10, 0, 0,

            "Axes", "Outlaws",

            "Some criminals want\n" +
            "to redeem themselves\n" +
            "in the upcoming raid.\n" +
            "Still, your men may\n" +
            "not be too keen about\n" +
            "it.",

            "Hired criminals",

            2, 0),

    /* 003 */new GameEvent(3, -15, 0, 0,

            "Axes", "Outlaws",

            "Some criminals want\n" +
            "to redeem themselves\n" +
            "in the upcoming raid.\n" +
            "Still, your men may\n" +
            "not be too keen about\n" +
            "it.",

            "Hired criminals",

            2, 0),

    /* 004 */new GameEvent(4, -20, 0, 0,

            "Axes", "Outlaws",

            "Some criminals want\n" +
            "to redeem themselves\n" +
            "in the upcoming raid.\n" +
            "Still, your men may\n" +
            "not be too keen about\n" +
            "it.",

            "Hired criminals",

            2, 0),

    /* 005 */new GameEvent(3, 0, 0, -15,

            "Swords", "Mercenaries",

            "Old and fearsome\n" +
            "warriors answered the\n" +
            "call to arms. They won't\n" +
            "be cheap.\n",

            "Hired Mercenaries",

            2, 0),

    /* 006 */new GameEvent(4, 0, 0, -20,

            "Swords", "Mercenaries",

            "Old and fearsome\n" +
            "warriors answered the\n" +
            "call to arms. They won't\n" +
            "be cheap.\n",

            "Hired Mercenaries",

            2, 0),

    /* 007 */new GameEvent(5, 0, 0, -25,

            "Swords", "Mercenaries",

            "Old and fearsome\n" +
            "warriors answered the\n" +
            "call to arms. They won't\n" +
            "be cheap.\n",

            "Hired Mercenaries",

            2, 0),

    /* 008 */new GameEvent(1, 10, 0, 0,

            "Champ", "Eldric the Young",

            "Eldric, the new\n" +
            "champion of Ultah\n" +
            "wants to join your\n" +
            "ranks. Your men think\n" +
            "highly of him\n",

            "Joined forces\n" +
            "with Eldric the\n" +
            "Young",

            7, 3),

    /* 009 */new GameEvent(-5, 40, 0, 25,

            "Raid", "English Outpost",

            "Local English Earl\n" +
            "tries to gather some\n" +
            "forces. Seems like a\n" +
            "good time to surprise\n" +
            "them. For glory!\n",

            "Raided some\n" +
            "English dogs\n",

            4, 2),

    /* 010 */new GameEvent(-5, -5, 20, 75,

            "Raid", "Christian Church",

            "Even though most of\n" +
            "us are Christians,\n" +
            "this Saxon church\n" +
            "holds many riches,\n" +
            "too many for a man of\n" +
            "God.",

            "Raided some\n" +
            "rich church\n",

            8, 2),
    
    /* 011 */new GameEvent(0, 0, -10, -25,

            "Myth", "Old stories",

            "Some men fear that\n" +
            "a demon lurks in the\n" +
            "shadows waiting for\n" +
            "the night to settle in.\n" +
            "We should leave a\n" +
            "gift and sleep\n" +
            "somewhere else.\n",

            "Left gifts for\n" +
            "an old demon\n",

            9, 1),

    /* 012 */new GameEvent(0, 5, -5, 0,

            "Myth", "Old rituals",

            "Your men found a\n" +
            "sacred grave of the\n" +
            "old ways. We are\n" +
            "Christians now,\n" +
            "but some of your men\n" +
            "are not, and wish to\n" +
            "pray.\n",

            "Chanted an old\n" +
            "prayer",

            11, 1),

    /* 013 */new GameEvent(-15, 50, 0, 10,

            "Combat", "English Patrol",

            "Your men found a\n" +
            "well armed patrol.\n" +
            "Your men are ready\n" +
            "to die in glorious\n" +
            "battle\n",

            "Fought Saxon pigs\n",

            1, 3),
    
    /* 014 */new GameEvent(-40, 100, 20, 15,

            "Combat", "English Army",

            "Your men found a\n" +
            "well-rounded Earl's army.\n" +
            "He is probably answering\n" +
            "Harold's call. We should\n" +
            "fight them here and now.\n",

            "Fought Saxon pigs\n",

            1, 3),
    
    /* 015 */new GameEvent(-1, 5, 0, 0,

            "Honor", "Hot headed soldier",

            "One of your men\n" +
            "disagrees with your\n" +
            "decisions and wants\n" +
            "to challange you.\n",

            "Taught a Norseman\n" +
            "his place\n",

            3, 0),

    /* 016 */new GameEvent(0, 20, -5, -25,

            "Honor", "Meet your king",

            "His Highness, Hardrada,\n" +
            "granted you an audience.\n" +
            "You should bring gifts.\n",

            "Met our king\n",

            3, 0),

    /* 017 */new GameEvent(0, 20, -5, -25,

            "Family", "Help your brother",

            "Your brother, Balos, is\n" +
            "pinned down by Saxons.\n" +
            "He could use a hand.\n" +
            "In exchange he will\n" +
            "give us part of the\n" +
            "loot\n",

            "Helped Balos,\n" +
            "your little\n" +
            "brother",

            5, 2),

    /* 018 */new GameEvent(0, -25, 0, 50,

            "Myth", "Elder curse",

            "Your men found an old\n" +
            "treasure burried\n" +
            "under an old oak.\n" +
            "On a closer look, you\n" +
            "find an old inscription:\n" +
            "a curse.\n",

            "Stolen from a\n" +
            "grave",

            10, 1),

		
// debugging events
	    };
        debug = new GameEvent[] {
    /* 019 */new GameEvent(1, 0, 0, 0,

			"q", "Gain one man",

			"",

			"Gained one man",

			0, 0),

	/* 020 */new GameEvent(-1, 0, 0, 0,

			"a", "Lose one man",

			"",

			"Lost one man",

			0, 0),

	/* 021 */new GameEvent(0, 5, 0, 0,

			"w", "Gain 5 morale",

			"",

			"Gained 5 morale",

			0, 0),

	/* 022 */new GameEvent(0, -5, 0, 0,

			"s", "Lose 5 morale",

			"",

			"Lost 5 morale",

			0, 0),

	/* 023 */new GameEvent(0, 0, 5, 0,

			"e", "Gain 5 food",

			"",

			"Gained 5 food",

			0, 0),

	/* 024 */new GameEvent(0, 0, -5, 0,

			"d", "Lose 5 food",

			"",

			"Lost 5 food",

			0, 0),

	/* 025 */new GameEvent(0, 0, 0, 100,

			"r", "Gain 100 loot",

			"",

			"Gained 100 loot",

			0, 0),

	/* 026 */new GameEvent(0, 0, 0, -100,

			"f", "Lose 100 loot",

			"",

			"Lost 100 loot",

			0, 0),
	};

        scrollState = 0;

        cardLeft = GameObject.Find("Card Left");
        cardMiddle = GameObject.Find("Card Middle");
        cardRight = GameObject.Find("Card Right");

        faceLeft = GameObject.Find("Card Left/Face").GetComponent<Renderer>();
        faceMiddle = GameObject.Find("Card Middle/Face").GetComponent<Renderer>();
        faceRight = GameObject.Find("Card Right/Face").GetComponent<Renderer>();
        
        tagLeftR = GameObject.Find("Card Left/Face/Tag").GetComponent<Renderer>();
        tagMiddleR = GameObject.Find("Card Middle/Face/Tag").GetComponent<Renderer>();
        tagRightR = GameObject.Find("Card Right/Face/Tag").GetComponent<Renderer>();

        tagLeft = GameObject.Find("Card Left/Face/Tag").GetComponent<TextMesh>();
        tagMiddle = GameObject.Find("Card Middle/Face/Tag").GetComponent<TextMesh>();
        tagRight = GameObject.Find("Card Right/Face/Tag").GetComponent<TextMesh>();

        string IDLE_DECK = "Idle Deck";

        cardLeft.GetComponent<Animator>().Play(IDLE_DECK);
        cardMiddle.GetComponent<Animator>().Play(IDLE_DECK);
        cardRight.GetComponent<Animator>().Play(IDLE_DECK);

        eventLeft = gameEvents[0];
        eventMiddle = gameEvents[0];
        eventRight = gameEvents[0];

        faceLeft.enabled = true;
        faceMiddle.enabled = true;
        faceRight.enabled = true;

        tagLeftR.enabled = true;
        tagMiddleR.enabled = true;
        tagRightR.enabled = true;

        faceLeft.sharedMaterial = gameEvents[0].Face;
        faceMiddle.sharedMaterial = gameEvents[0].Face;
        faceRight.sharedMaterial = gameEvents[0].Face;

        tagLeftR.sharedMaterial = gameEvents[0].TagColor;
        tagMiddleR.sharedMaterial = gameEvents[0].TagColor;
        tagRightR.sharedMaterial = gameEvents[0].TagColor;
    }

    void Update()
    {
        if (!cardLeft.GetComponent<Animator>().GetBool("AllSet")
                && !cardMiddle.GetComponent<Animator>().GetBool("AllSet")
                && !cardRight.GetComponent<Animator>().GetBool("AllSet"))
        {
            eventLeft = gameEvents[Random.Range(1, gameEvents.Length)];
            do
            {
                eventMiddle = gameEvents[Random.Range(1, gameEvents.Length)];
            } while (eventMiddle == eventLeft);
            do
            {
                eventRight = gameEvents[Random.Range(1, gameEvents.Length)];
            } while (eventRight == eventLeft || eventRight == eventMiddle);

            faceLeft.material = eventLeft.Face;
            faceMiddle.material = eventMiddle.Face;
            faceRight.material = eventRight.Face;


            faceLeft.sharedMaterial = eventLeft.Face;
            faceMiddle.sharedMaterial = eventMiddle.Face;
            faceRight.sharedMaterial = eventRight.Face;

            tagLeftR.sharedMaterial = eventLeft.TagColor;
            tagMiddleR.sharedMaterial = eventMiddle.TagColor;
            tagRightR.sharedMaterial = eventRight.TagColor;

            tagLeft.text = eventLeft.Tag;
            tagMiddle.text = eventMiddle.Tag;
            tagRight.text = eventRight.Tag;

            cardLeft.GetComponent<Animator>().SetBool("AllSet", true);
            cardMiddle.GetComponent<Animator>().SetBool("AllSet", true);
            cardRight.GetComponent<Animator>().SetBool("AllSet", true);
        }

		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit))
		{
            if (hit.collider.name == faceLeft.name)
            {

                // stuff on hover 
                if (scrollState != 1)
                {
                    Scroll.UpdateScroll(eventLeft);
                    scrollState = 1;
                }

                if (Input.GetMouseButtonDown(0)
                        && cardLeft.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(IDLE_TABLE)
                        && cardMiddle.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(IDLE_TABLE)
                        && cardRight.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(IDLE_TABLE))
                {
                    //stuff on click
                    LogTablet.AddEntry(eventLeft);
                    StatusTablet.UpdateStatus(eventLeft);

                    cardLeft.GetComponent<Animator>().SetBool("ToDiscard", true);
                    cardMiddle.GetComponent<Animator>().SetBool("ToDiscard", true);
                    cardRight.GetComponent<Animator>().SetBool("ToDiscard", true);
                }
            }
            else if (hit.collider.name == faceMiddle.name)
            {

                // stuff on hover 
                if (scrollState != 2)
                {
                    Scroll.UpdateScroll(eventMiddle);
                    scrollState = 2;
                }

                if (Input.GetMouseButtonDown(0)
                        && cardLeft.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(IDLE_TABLE)
                        && cardMiddle.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(IDLE_TABLE)
                        && cardRight.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(IDLE_TABLE))
                {
                    //stuff on click
                    LogTablet.AddEntry(eventMiddle);
                    StatusTablet.UpdateStatus(eventMiddle);

                    cardLeft.GetComponent<Animator>().SetBool("ToDiscard", true);
                    cardMiddle.GetComponent<Animator>().SetBool("ToDiscard", true);
                    cardRight.GetComponent<Animator>().SetBool("ToDiscard", true);
                }
            }
            else if (hit.collider.name == faceRight.name)
            {

                // stuff on hover
                if (scrollState != 3)
                {
                    Scroll.UpdateScroll(eventRight);
                    scrollState = 3;
                }

                if (Input.GetMouseButtonDown(0)
                        && cardLeft.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(IDLE_TABLE)
                        && cardMiddle.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(IDLE_TABLE)
                        && cardRight.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(IDLE_TABLE))
                {
                    //stuff on click
                    LogTablet.AddEntry(eventRight);
                    StatusTablet.UpdateStatus(eventRight);

                    cardLeft.GetComponent<Animator>().SetBool("ToDiscard", true);
                    cardMiddle.GetComponent<Animator>().SetBool("ToDiscard", true);
                    cardRight.GetComponent<Animator>().SetBool("ToDiscard", true);
                }
            }
            else
            {
                // stuff on hover
                if (scrollState != 0)
                {
                    Scroll.UpdateScroll(gameEvents[0]);
                    scrollState = 0;
                }
            }
		}
	}
	
	public class GameEvent
    {
        public int ArmySize { get; set; }
        public int ArmyMorale { get; set; }
        public int Food { get; set; }
        public int Loot { get; set; }
        public string Tag { get; set; }         // max 6
        public string Title { get; set; }       // max 15
        public string Description { get; set; } // max 21
        public string LogEntry { get; set; }    // max 15
        public Material Face { get; set; }
        public Material TagColor { get; set; }

        public void SetFace(int id)
        {
            id %= FACES.Length;
            Face = FACES[id];
        }

        public void SetTagColor(int id)
        {
            id %= FONTS.Length;
            TagColor = FONTS[id];
        }

        public GameEvent () : this(0, 0, 0, 0, "", "", "", "", 0, 0)
        {}

        public GameEvent (int men, int morale, int food, int loot,
                string tag, string title, string description, string logEntry,
                int faceId, int fontId)
        {
            ArmySize = men;
            ArmyMorale = morale;
            Food = food;
            Loot = loot;
            Tag = tag;
            Title = title;
            Description = description;
            LogEntry = logEntry;
            SetFace(faceId);
            SetTagColor(fontId);
        }
    }
}
