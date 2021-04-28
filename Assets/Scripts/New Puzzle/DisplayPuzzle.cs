using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = System.Random;

public class DisplayPuzzle : MonoBehaviour
{
    [SerializeField] private GameObject unlockFirstButton;
    public PuzzleObject puzzle;
    public PuzzleItemDatabaseObject databaseObject;
    public GameObject puzzlePrefab;
    public int X_START;
    public int Y_START;
    public int X_SPACE_BETWEEN_ITEM;
    public int NUMBER_OF_COLUMN;
    public int Y_SPACE_BETWEEN_ITEMS;
    public List<GameObject> Gates;
    Dictionary<GameObject, PuzzleSlot> itemsDisplayed = new Dictionary<GameObject, PuzzleSlot>();
    Dictionary<PuzzleSlot,int> slotsIndex = new Dictionary<PuzzleSlot, int>();
    Dictionary<int, int[]> scrambles = new Dictionary<int, int[]>();
    //Dictionary<GameObject, int> objIndex = new Dictionary<GameObject, int>();
    public PuzzleSlot selectedSlot;
    public GameObject selectedObject;
    public bool onDown;
    public bool onUp;
    public bool onRight;
    public bool onLeft;
    public int gatesCount = 56;
    public int gateId = -1;
    public bool justUnlocked = false;
    //public TMPro.TextMeshPro unlockMessage;
    public Text unlockMessage;
    // Start is called before the first frame update

    public StatObject statObject;
    public Text goldText;
    public Image goldImg1;
    public Image goldImg2;

    public int selectorNum = 0;

    void Start()
    {
        if (puzzle.database == null)
        {
            puzzle.database = databaseObject;
        }
        CreateSlots();
        CreatePuzzles();
        //Time.timeScale = 0;
        unlockMessage.text = "";
        gameObject.SetActive(false);
        justUnlocked = false;
        goldText.enabled = false;
        goldImg1.enabled = false;
        goldImg2.enabled = false;
        //InputManager.Controls.Player.PuzzleMouse.performed += ctx => moveMouse(ctx.ReadValue<Vector2>());
        InputManager.Controls.Player.SelectInPuzzle.performed += ctx => selectMouse();
        InputManager.Controls.Player.SelectInPuzzle.Disable();
    }

    //void moveMouse(Vector2 vec)
    //{
    //    print("movingMouse");
    //    print(vec);
    //    //Vector3 mousepos = Camera.main.WorldToScreenPoint(Mouse.current.position.ReadValue() + vec);
    //    //InputState.Change(Mouse.current.position, vec);
    //    //Vector2 newPos = (Vector2)Input.mousePosition + vec;
    //    Vector2 mousepos = Mouse.current.position.ReadValue() + vec * 10;
    //    Mouse.current.WarpCursorPosition(mousepos);
    //    InputState.Change(Mouse.current.position, mousepos);
    //}

    void selectMouse()
    {
        print("clickingMouse");

        PuzzleSlot pz = puzzle.Container.Items[selectorNum];
        var keeey = itemsDisplayed.FirstOrDefault(x => x.Value == pz).Key;
        OnClick(keeey);
        selectorNum++;
        if (selectorNum >= 16)
        {
            selectorNum = 0;
        }

        //RaycastHit hit;
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //if (Physics.Raycast(ray, out hit, 100.0f))
        //{
        //    //StartCoroutine(ScaleMe(hit.transform));
        //    Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
        //}
        //Mouse.current.leftButton.IsPressed(0);
        //Mouse.current.leftButton.IsPressed(1);
        //Mouse.current.
        //OnClick();
    }

    public void Activate()
    {
        // Select the controller to the bottom buttons
        InputManager.Controls.Player.SelectInPuzzle.Enable();
        InputManager.Controls.Player.SelectMoveDown.Enable();
        InputManager.Controls.Player.SelectMoveUp.Enable();

        InputManager.Controls.Player.SelectMoveLeft.Enable();

        InputManager.Controls.Player.SelectMoveRight.Enable();

        gameObject.SetActive(true);
        Time.timeScale = 0;
        unlockMessage.text = "";
        justUnlocked = false;
        goldText.enabled = false;
        goldImg1.enabled = false;
        goldImg2.enabled = false;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(unlockFirstButton);
    }

    public void deActivate()
    {
        InputManager.Controls.Player.Enable();
        InputManager.Controls.Player.SelectInPuzzle.Disable();
        gameObject.SetActive(false);
        Time.timeScale = 1;
        goldText.enabled = false;
        goldImg1.enabled = false;
        goldImg2.enabled = false;
    }

    public bool unlocked()
    {
        if (justUnlocked)
        {
            justUnlocked = false;
            return true;
        } else
        {
            return false;
        }
    }

    public void Authenticate()
    {
        int id0 = puzzle.Container.Items[0].ID;
        int id1 = puzzle.Container.Items[1].ID;
        int id2 = puzzle.Container.Items[2].ID;
        int id3 = puzzle.Container.Items[3].ID;
        int id4 = puzzle.Container.Items[4].ID;
        int id5 = puzzle.Container.Items[5].ID;
        int id6 = puzzle.Container.Items[6].ID;
        int id7 = puzzle.Container.Items[7].ID;
        int id8 = puzzle.Container.Items[8].ID;
        int id9 = puzzle.Container.Items[9].ID;
        int id10 = puzzle.Container.Items[10].ID;
        int id11 = puzzle.Container.Items[11].ID;
        int id12 = puzzle.Container.Items[12].ID;
        int id13 = puzzle.Container.Items[13].ID;
        int id14 = puzzle.Container.Items[14].ID;
        int id15 = puzzle.Container.Items[15].ID;

        if (puzzle.database.GetItem[id0].type != PuzzleItemType.Queen || puzzle.database.GetItem[id1].type != PuzzleItemType.Bishop
            || puzzle.database.GetItem[id2].type != PuzzleItemType.Knight || puzzle.database.GetItem[id3].type != PuzzleItemType.Brook)
        {
            //return false;
            unlockMessage.text = "Fail";
            unlockMessage.color = Color.red;
            print("fail");

        }
        else if (puzzle.database.GetItem[id4].type != PuzzleItemType.Queen || puzzle.database.GetItem[id5].type != PuzzleItemType.Bishop
            || puzzle.database.GetItem[id6].type != PuzzleItemType.Knight || puzzle.database.GetItem[id7].type != PuzzleItemType.Brook)
        {
            //return false;
            unlockMessage.text = "Fail";
            unlockMessage.color = Color.red;
            print("fail");
        }
        else if (puzzle.database.GetItem[id8].type != PuzzleItemType.Queen || puzzle.database.GetItem[id9].type != PuzzleItemType.Bishop
            || puzzle.database.GetItem[id10].type != PuzzleItemType.Knight || puzzle.database.GetItem[id11].type != PuzzleItemType.Brook)
        {
            //return false;
            unlockMessage.text = "Fail";
            unlockMessage.color = Color.red;
            print("fail");
        }
        else if (puzzle.database.GetItem[id12].type != PuzzleItemType.Queen || puzzle.database.GetItem[id13].type != PuzzleItemType.Bishop
            || puzzle.database.GetItem[id14].type != PuzzleItemType.Knight || puzzle.database.GetItem[id15].type != PuzzleItemType.Brook)
        {
            //return false;
            unlockMessage.text = "Fail";
            unlockMessage.color = Color.red;
            print("fail");
        }
        else
        {
            unlockMessage.text = "Success!";
            unlockMessage.color = Color.white;
            goldText.enabled = true;
            goldImg1.enabled = true;
            goldImg2.enabled = true;
            print("success");
            if (gateId > -1 && gateId < gatesCount)
            {
                Destroy(Gates[gateId]);
                justUnlocked = true;
                statObject.changeGold(10);
            } 
        }
        //return true;
    }

    void CreatePuzzles()
    {
        Random _random = new Random();
        scrambles = new Dictionary<int, int[]>();
        for (int i = 0; i < gatesCount; i++)
        {
            int[] transforms = new int[8];
            transforms[0] = _random.Next(4);
            transforms[1] = _random.Next(4);
            transforms[2] = _random.Next(4);
            transforms[3] = _random.Next(4);
            transforms[4] = _random.Next(4);
            transforms[5] = _random.Next(4);
            transforms[6] = _random.Next(4);
            transforms[7] = _random.Next(4);
            scrambles.Add(i, transforms);
        }
    }

    public void ScrambleByGate(int id)
    {
        Reset();
        Scramble(scrambles[id][0], scrambles[id][1], scrambles[id][2], scrambles[id][3], scrambles[id][4], scrambles[id][5], scrambles[id][6], scrambles[id][7]);
        gateId = id;
    }

    void Scramble(int up1, int up2, int up3, int up4, int right1, int right2, int right3, int right4 )
    {

        // right 1
        selectedSlot = puzzle.Container.Items[0];
        for (int i = 0; i < right1; i++)
        {
            moveRight();
        }

        // right 2
        selectedSlot = puzzle.Container.Items[4];
        for (int i = 0; i < right2; i++)
        {
            moveRight();
        }

        // right 3
        selectedSlot = puzzle.Container.Items[8];
        for (int i = 0; i < right3; i++)
        {
            moveRight();
        }

        // right 4
        selectedSlot = puzzle.Container.Items[12];
        for (int i = 0; i < right4; i++)
        {
            moveRight();
        }

        // up 1
        selectedSlot = puzzle.Container.Items[0];
        for (int i = 0; i < up1; i++)
        {
            moveUp();
        }

        // up 2
        selectedSlot = puzzle.Container.Items[1];
        for (int i = 0; i < up2; i++)
        {
            moveUp();
        }

        // up 3
        selectedSlot = puzzle.Container.Items[2];
        for (int i = 0; i < up3; i++)
        {
            moveUp();
        }

        // up 4
        selectedSlot = puzzle.Container.Items[3];
        for (int i = 0; i < up4; i++)
        {
            moveUp();
        }

    }

    void Reset()
    {
        CreateSlots();
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateSlots();
        if (InputManager.Controls.Player.SelectMoveDown.triggered && selectedSlot != null && onDown == false)
        {
            onDown = true;
            print("move down -- " + selectedSlot.ID);
            moveDown();
        }
        if (InputManager.Controls.Player.SelectMoveUp.triggered && selectedSlot != null && onUp == false)
        {
            onUp = true;
            print("move up -- " + selectedSlot.ID);
            moveUp();
        }
        if (InputManager.Controls.Player.SelectMoveRight.triggered && selectedSlot != null && onRight == false)
        {
            onRight = true;
            print("move right -- " + selectedSlot.ID);
            moveRight();
        }
        if (InputManager.Controls.Player.SelectMoveLeft.triggered && selectedSlot != null && onLeft == false)
        {
            onLeft = true;
            print("move left -- " + selectedSlot.ID);
            moveLeft();
        }
        if (!InputManager.Controls.Player.SelectMoveDown.triggered)
        {
            onDown = false;
        }
        if (!InputManager.Controls.Player.SelectMoveUp.triggered)
        {
            onUp = false;
        }
        if (!InputManager.Controls.Player.SelectMoveRight.triggered)
        {
            onRight = false;
        }
        if (!InputManager.Controls.Player.SelectMoveLeft.triggered)
        {
            onLeft = false;
        }
    }

    public void moveDown()
    {
        print("move down");
        int index1 = slotsIndex[selectedSlot];
        print("index1 -- " + index1);
        int index2 = (index1 + 4) % 16;
        print("index2 -- " + index2);
        int index3 = (index2 + 4) % 16;
        print("index3 -- " + index3);
        int index4 = (index3 + 4) % 16;
        print("index4 -- " + index4);

        PuzzleSlot slot1 = selectedSlot;
        PuzzleSlot slot2 = puzzle.Container.Items[index2];
        PuzzleSlot slot3 = puzzle.Container.Items[index3];
        PuzzleSlot slot4 = puzzle.Container.Items[index4];

        puzzle.Container.Items[index1] = slot4;
        puzzle.Container.Items[index2] = slot1;
        puzzle.Container.Items[index3] = slot2;
        puzzle.Container.Items[index4]= slot3;

        itemsDisplayed = new Dictionary<GameObject, PuzzleSlot>();
        slotsIndex = new Dictionary<PuzzleSlot, int>();
        for (int i = 0; i < puzzle.Container.Items.Length; i++)
        {
            PuzzleSlot slot = puzzle.Container.Items[i];
            print("id -- " + slot.ID);
            var obj = Instantiate(puzzlePrefab, Vector3.zero, Quaternion.identity, transform);
            obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite = puzzle.database.GetItem[slot.ID].uiDisplay;
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            itemsDisplayed.Add(obj, puzzle.Container.Items[i]);
            slotsIndex.Add(puzzle.Container.Items[i], i);
            AddEvent(obj, EventTriggerType.PointerClick, delegate { OnClick(obj); });
            if (slot.ID == slot4.ID)
            {
                selectedObject = obj;
                selectedSlot = itemsDisplayed[obj];
                obj.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color((float)0.5, (float)0.5, (float)0.5, 1);
            }
        }
    }

    public void moveUp()
    {
        print("move down");
        int index1 = slotsIndex[selectedSlot];
        print("index1 -- " + index1);
        int index2 = (index1 + 4) % 16;
        print("index2 -- " + index2);
        int index3 = (index2 + 4) % 16;
        print("index3 -- " + index3);
        int index4 = (index3 + 4) % 16;
        print("index4 -- " + index4);

        PuzzleSlot slot1 = selectedSlot;
        PuzzleSlot slot2 = puzzle.Container.Items[index2];
        PuzzleSlot slot3 = puzzle.Container.Items[index3];
        PuzzleSlot slot4 = puzzle.Container.Items[index4];

        puzzle.Container.Items[index1] = slot2;
        puzzle.Container.Items[index2] = slot3;
        puzzle.Container.Items[index3] = slot4;
        puzzle.Container.Items[index4] = slot1;

        itemsDisplayed = new Dictionary<GameObject, PuzzleSlot>();
        slotsIndex = new Dictionary<PuzzleSlot, int>();
        for (int i = 0; i < puzzle.Container.Items.Length; i++)
        {
            PuzzleSlot slot = puzzle.Container.Items[i];
            print("id -- " + slot.ID);
            var obj = Instantiate(puzzlePrefab, Vector3.zero, Quaternion.identity, transform);
            obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite = puzzle.database.GetItem[slot.ID].uiDisplay;
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            itemsDisplayed.Add(obj, puzzle.Container.Items[i]);
            slotsIndex.Add(puzzle.Container.Items[i], i);
            AddEvent(obj, EventTriggerType.PointerClick, delegate { OnClick(obj); });
            if (slot.ID == slot2.ID)
            {
                selectedObject = obj;
                selectedSlot = itemsDisplayed[obj];
                obj.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color((float)0.5, (float)0.5, (float)0.5, 1);
            }
        }
    }

    public void moveRight()
    {
        print("move down");
        int index1 = slotsIndex[selectedSlot];
        int baseIndex = (index1 / 4) * 4;
        print("index1 -- " + index1);
        int index2 = baseIndex + (index1 + 1) % 4;
        print("index2 -- " + index2);
        int index3 = baseIndex + (index2 + 1) % 4;
        print("index3 -- " + index3);
        int index4 = baseIndex + (index3 + 1) % 4;
        print("index4 -- " + index4);

        PuzzleSlot slot1 = selectedSlot;
        PuzzleSlot slot2 = puzzle.Container.Items[index2];
        PuzzleSlot slot3 = puzzle.Container.Items[index3];
        PuzzleSlot slot4 = puzzle.Container.Items[index4];

        puzzle.Container.Items[index1] = slot4;
        puzzle.Container.Items[index2] = slot1;
        puzzle.Container.Items[index3] = slot2;
        puzzle.Container.Items[index4] = slot3;

        itemsDisplayed = new Dictionary<GameObject, PuzzleSlot>();
        slotsIndex = new Dictionary<PuzzleSlot, int>();
        for (int i = 0; i < puzzle.Container.Items.Length; i++)
        {
            PuzzleSlot slot = puzzle.Container.Items[i];
            print("id -- " + slot.ID);
            var obj = Instantiate(puzzlePrefab, Vector3.zero, Quaternion.identity, transform);
            obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite = puzzle.database.GetItem[slot.ID].uiDisplay;
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            itemsDisplayed.Add(obj, puzzle.Container.Items[i]);
            slotsIndex.Add(puzzle.Container.Items[i], i);
            AddEvent(obj, EventTriggerType.PointerClick, delegate { OnClick(obj); });
            if (slot.ID == slot4.ID)
            {
                selectedObject = obj;
                selectedSlot = itemsDisplayed[obj];
                obj.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color((float)0.5, (float)0.5, (float)0.5, 1);
            }
        }
    }

    public void moveLeft()
    {
        print("move down");
        int index1 = slotsIndex[selectedSlot];
        int baseIndex = (index1 / 4) * 4;
        print("index1 -- " + index1);
        int index2 = baseIndex + (index1 + 1) % 4;
        print("index2 -- " + index2);
        int index3 = baseIndex + (index2 + 1) % 4;
        print("index3 -- " + index3);
        int index4 = baseIndex + (index3 + 1) % 4;
        print("index4 -- " + index4);


        PuzzleSlot slot1 = selectedSlot;
        PuzzleSlot slot2 = puzzle.Container.Items[index2];
        PuzzleSlot slot3 = puzzle.Container.Items[index3];
        PuzzleSlot slot4 = puzzle.Container.Items[index4];

        puzzle.Container.Items[index1] = slot2;
        puzzle.Container.Items[index2] = slot3;
        puzzle.Container.Items[index3] = slot4;
        puzzle.Container.Items[index4] = slot1;

        itemsDisplayed = new Dictionary<GameObject, PuzzleSlot>();
        slotsIndex = new Dictionary<PuzzleSlot, int>();
        for (int i = 0; i < puzzle.Container.Items.Length; i++)
        {
            PuzzleSlot slot = puzzle.Container.Items[i];
            print("id -- " + slot.ID);
            var obj = Instantiate(puzzlePrefab, Vector3.zero, Quaternion.identity, transform);
            obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite = puzzle.database.GetItem[slot.ID].uiDisplay;
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            itemsDisplayed.Add(obj, puzzle.Container.Items[i]);
            slotsIndex.Add(puzzle.Container.Items[i], i);
            AddEvent(obj, EventTriggerType.PointerClick, delegate { OnClick(obj); });
            if (slot.ID == slot2.ID)
            {
                selectedObject = obj;
                selectedSlot = itemsDisplayed[obj];
                obj.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color((float)0.5, (float)0.5, (float)0.5, 1);
            }
        }
    }

    public void UpdateSlots()
    {
        foreach(KeyValuePair<GameObject, PuzzleSlot> _slot in itemsDisplayed)
        {
            if (_slot.Value.ID >= 0)
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = puzzle.database.GetItem[_slot.Value.item.Id].uiDisplay;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
                
            } else
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0);
            }
         }
    }

    private void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        var eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = type;
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);
    }

    
  
    public void CreateSlots()
    {
        itemsDisplayed = new Dictionary<GameObject, PuzzleSlot>();
        slotsIndex = new Dictionary<PuzzleSlot, int>();
        for (int i = 0; i < puzzle.Container.Items.Length; i++)
        {
            PuzzleSlot slot = puzzle.Container.Items[i];
            var obj = Instantiate(puzzlePrefab, Vector3.zero, Quaternion.identity, transform);
            obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite = puzzle.database.GetItem[i].uiDisplay;
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            itemsDisplayed.Add(obj, puzzle.Container.Items[i]);
            slotsIndex.Add(puzzle.Container.Items[i], i);
            //objIndex.Add(obj, i);
            puzzle.Container.Items[i].ID = i;
            AddEvent(obj, EventTriggerType.PointerClick, delegate { OnClick(obj); } );
            
        }
    }

    public void OnClick(GameObject obj)
    {
        obj.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color( (float)0.5, (float)0.5, (float)0.5, 1);
        if (selectedObject != null)
        {
            selectedObject.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
        }
        selectedObject = obj;
        selectedSlot = itemsDisplayed[obj];
        print("ID -- " + selectedSlot.ID);
        print("Index (slots) -- " + slotsIndex[selectedSlot]);
        //print("Index (objs) -- " + objIndex[obj]);
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + (X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMN)), Y_START + ((-Y_SPACE_BETWEEN_ITEMS * (i / NUMBER_OF_COLUMN))), 0f);
    }

    public void UpdateDisplay()
    {
        
            
    }
}
