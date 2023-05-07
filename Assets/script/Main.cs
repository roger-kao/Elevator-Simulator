using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public static Main Instance;

    public Elevator elevator1 = new Elevator();
    public Elevator elevator2 = new Elevator();
    public float e1timer = 0f;
    public float e2timer = 0f;
    [SerializeField] private InputField e1CurrentFloorInput;
    [SerializeField] private InputField e1GoToFloorInput;
    [SerializeField] private InputField e2CurrentFloorInput;
    [SerializeField] private InputField e2GoToFloorInput;


    [SerializeField] private Text e1Text;
    [SerializeField] private Text e2Text;
    public Button e1go;
    public Button e2go;


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        elevator1.move(0,0);
        elevator2.move(0,0);
        e1go.onClick.AddListener(E1go);
        e2go.onClick.AddListener(E2go);
    }

    // Update is called once per frame
    void Update()
    {
        //計時，每秒移動一個樓層
        e1timer += Time.deltaTime;
        e2timer += Time.deltaTime;
        if(e1timer >= 1f)
        {
            elevator1.move();
            string s = e1Text.text + ',' + e2Text.text;
            e1timer = 0;
        }
        if(e2timer >= 1f)
        {
            elevator2.move();
            string s = e1Text.text + ',' + e2Text.text;
            e2timer = 0;
        }
        e1Text.text = elevator1.display_floor().ToString();
        e2Text.text = elevator2.display_floor().ToString();
    }
    void E1go()
    {
        int current = int.Parse(e1CurrentFloorInput.text);
        int floor = int.Parse(e1GoToFloorInput.text); 
        e1CurrentFloorInput.text = "";
        e1GoToFloorInput.text = "";
        if(current > 10 || current <1 || floor > 10 || floor <1)
        {
            Debug.Log("錯誤的樓層輸入，電梯只能到1~10層");
            return;
        }
        elevator1.move(current,floor);
        e1timer = 0;
    }

    void E2go()
    {
        int current = int.Parse(e2CurrentFloorInput.text);
        int floor = int.Parse(e2GoToFloorInput.text); 
        e2CurrentFloorInput.text = "";
        e2GoToFloorInput.text = "";
        if(current > 10 || current <1 || floor > 10 || floor <1)
        {
            Debug.Log("錯誤的樓層輸入，電梯只能到1~10層");
            return;
        }
        elevator2.move(current,floor);
        e2timer = 0;


    }
    
}
