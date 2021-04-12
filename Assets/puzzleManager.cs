using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class puzzleManager : MonoBehaviour
{
    public ButtonHandler0 handler0;
    public ButtonHandler1 handler1;
    public ButtonHandler2 handler2;
    public ButtonHandler3 handler3;
    public ButtonHandler4 handler4;
    public ButtonHandler5 handler5;
    public ButtonHandler6 handler6;
    public ButtonHandler7 handler7;
    public ButtonHandler8 handler8;
    public ButtonHandler9 handler9;


    // Start is called before the first frame update
    void Start()
    {
        scramble();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void scramble()
    {
        // Button 0 (Left Row 3)
        //handler0.moveRow();

        // Button 1 (Right Row 3)
        //handler1.moveRow();
        //handler1.moveRow();

        // Button 2 (Left Row 2) 
        //handler2.moveRow();
        //handler2.moveRow();

        // Button 2 (Right Row 2) 
        //handler3.moveRow();

        // Button 4 (Up Col 1)
        //handler4.moveCol();

        // Button 5 (Up Col 2)
        //handler5.moveCol();

        // Button 6 (Up Col 3)
        //handler6.moveCol();

        // Button 7 (Up Col 4)
        //handler7.moveCol();

        // Button 8 (Left .. )
        handler8.moveRow();



        /*for(int i = 0; i < 1; i++)
        {
            //handler0.moveRow();
        }*/

    }

    public bool checkCorrect()
    {
        return false;
    }


}
