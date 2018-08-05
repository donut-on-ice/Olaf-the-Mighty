using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCards : MonoBehaviour
{
    private static readonly string IDLE_TABLE = "Idle Table";

    private Animator animator;
    private GameObject cardLeft, cardMiddle, cardRight;
    private Renderer faceLeft, faceMiddle, faceRight;
    private GameEvent eventLeft, eventMiddle, eventRight;
    private TextMesh tagLeft, tagMiddle, tagRight;
    private Renderer tagLeftR, tagMiddleR, tagRightR;

    private static readonly int[] indexes = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}; 
    private static readonly GameEvent[] gameEvents = new GameEvent[] {
    /* 000 */new GameEvent(),

    /* 001 */new GameEvent(0, 0, 5, -20,
            
            "Trade", "Local Market",
            
            "The Nearby villagers\n" +
            "have gathered to Sale\n" +
            "their goods.",

            "Bought some" +
            "food for loot",
            
            "id05m", "BrightBlue Text"),

    /* 002 */new GameEvent(2, -10, 0, 0,

            "Axes", "Outlaws",

            "Some criminals want\n" +
            "to redeeem themselves\n" +
            "in the upcoming raid.\n" +
            "Still your men may\n" +
            "not be too keen about\n" +
            "it.",
            
            "Hired criminals",
            
            "id02m", "DarkRed Text"),

    /* 003 */new GameEvent(3, -15, 0, 0,

            "Axes", "Outlaws",

            "Some criminals want\n" +
            "to redeeem themselves\n" +
            "in the upcoming raid.\n" +
            "Still your men may\n" +
            "not be too keen about\n" +
            "it.",

            "Hired criminals",

            "id02m", "DarkRed Text"),

    /* 004 */new GameEvent(4, -20, 0, 0,

            "Axes", "Outlaws",

            "Some criminals want\n" +
            "to redeeem themselves\n" +
            "in the upcoming raid.\n" +
            "Still your men may\n" +
            "not be too keen about\n" +
            "it.",

            "Hired criminals",

            "id02m", "DarkRed Text"),

    /* 005 */new GameEvent(3, 0, 0, -15,

            "Swords", "Merchenaries",

            "Old and fearsome\n" +
            "worriors answered the" +
            "call to arms. They won't\n" +
            "be cheep.\n",

            "Hired Merchenaries",

            "id02m", "DarkRed Text"),

    /* 006 */new GameEvent(4, 0, 0, -20,

            "Swords", "Merchenaries",

            "Old and fearsome\n" +
            "worriors answered the" +
            "call to arms. They won't\n" +
            "be cheep.\n",

            "Hired Merchenaries",

            "id02m", "DarkRed Text"),

    /* 007 */new GameEvent(5, 0, 0, -25,

            "Swords", "Merchenaries",

            "Old and fearsome\n" +
            "worriors answered the" +
            "call to arms. They won't\n" +
            "be cheep.\n",

            "Hired Merchenaries",

            "id02m", "DarkRed Text"),

    /* 008 */new GameEvent(1, 10, 0, 0,

            "Champ", "Eldric the Young",

            "Eldric, the new\n" +
            "champion of Ultah\n" +
            "wants yo join your\n" +
            "ranks. Your men think\n" +
            "highly of him\n",

            "Joined forces\n" +
            "with Eldric the\n" +
            "Young",

            "id07m", "BrightBlue Text"),

    /* 009 */new GameEvent(-5, 40, 0, 25,

            "Raid", "English Outpost",

            "Local English Earl\n" +
            "tries to gather some\n" +
            "forces. Seems like a\n" +
            "good time to surprise\n" +
            "them. For glory!\n",

            "Raided some English dogs\n",

            "id05m", "BrightRed Text"),
    /* 010 */new GameEvent(0, -5, 20, 75,

            "Raid", "Christian Church",

            "Even though most of\n" +
            "us are Christians\n" +
            "this saxon church\n" +
            "holds many riches,\n" +
            "too many for a man of\n" +
            "the God.",
            
            "Raided some English dogs\n",

            "id08m", "BrightRed Text"),
    };
    
    void Start ()
    {
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
    }

    void Update()
    {
        if (!cardLeft.GetComponent<Animator>().GetBool("AllSet")
                && !cardMiddle.GetComponent<Animator>().GetBool("AllSet")
                && !cardRight.GetComponent<Animator>().GetBool("AllSet"))
        {
            eventLeft = gameEvents[Random.Range(1, 10)];
            do
            {
                eventMiddle = gameEvents[Random.Range(1, 10)];
            } while (eventMiddle == eventLeft);
            do
            {
                eventRight = gameEvents[Random.Range(1, 10)];
            } while (eventRight == eventLeft || eventRight == eventMiddle);

            faceLeft.material = eventLeft.Face;
            faceMiddle.material = eventMiddle.Face;
            faceRight.material = eventRight.Face;
            
            tagLeft.text = eventLeft.Tag;
            tagLeftR.material = eventLeft.TagColor;
            tagMiddle.text = eventMiddle.Tag;
            tagMiddleR.material = eventMiddle.TagColor;
            tagRight.text = eventRight.Tag;
            tagRightR.material = eventRight.TagColor;

            cardLeft.GetComponent<Animator>().SetBool("AllSet", true);
            cardMiddle.GetComponent<Animator>().SetBool("AllSet", true);
            cardRight.GetComponent<Animator>().SetBool("AllSet", true);
        }
        
        if (Input.GetMouseButtonDown(0)
                && cardLeft.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(IDLE_TABLE)
                && cardMiddle.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(IDLE_TABLE)
                && cardRight.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(IDLE_TABLE))
        {
            cardLeft.GetComponent<Animator>().SetBool("ToDiscard", true);
            cardMiddle.GetComponent<Animator>().SetBool("ToDiscard", true);
            cardRight.GetComponent<Animator>().SetBool("ToDiscard", true);
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

        public void SetFace(string name) {
            Face = Resources.Load<Material>("Materials/Cards/" + name);
        }

        public void SetTagColor(string name)
        {
            Face = Resources.Load<Material>("Materials/Fonts/" + name);
        }

        public GameEvent () : this(0, 0, 0, 0, "", "", "", "", "id00m", "DarkRed Text")
        {}

        public GameEvent (int men, int morale, int food, int loot,
                string tag, string title, string description, string logEntry,
                string resName, string colorName)
        {
            ArmySize = men;
            ArmyMorale = morale;
            Food = food;
            Loot = loot;
            Tag = tag;
            Title = title;
            Description = description;
            LogEntry = logEntry;
            SetFace(resName);
            SetTagColor(colorName);
        }
    }
}
