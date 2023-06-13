using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlateScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float Height = 0;
    public bool ProductAddNow = false;
    public List< GameObject> burger;
    public List<int> Ids;
    public Material[] menus;
    public int MenuNow = 0;
    public GameObject menu;
    public int score = 0;
    public RobotTimerScript robot;
    public int meatMaterial;
    public Text scoreText;

    

    


    public void BurgerEnd()
    {


        CheckBurger();

        burger.ForEach(b => Destroy(b));
        burger.Clear();

        

        Ids.Clear();

        Height= 0;
        meatMaterial= 0;


    }

    void CheckBurger()
    {
        switch (MenuNow)
        {
            case 0:
                {
                    List<int> RightIds1 = new List<int>();
                    RightIds1.Add(0);
                    RightIds1.Add(4);
                    RightIds1.Add(5);
                    RightIds1.Add(6);
                    RightIds1.Add(7);
                    RightIds1.Add(3);
                    RightIds1.Add(2);
                    RightIds1.Add(1);

                    List<int> RightIds2 = new List<int>();
                    RightIds2.Add(0);
                    RightIds2.Add(4);
                    RightIds2.Add(5);
                    RightIds2.Add(7);
                    RightIds2.Add(6);
                    RightIds2.Add(3);
                    RightIds2.Add(2);
                    RightIds2.Add(1);


                    

                    if (Ids.SequenceEqual( RightIds1) || Ids.SequenceEqual(RightIds2) ){

                        

                        if (meatMaterial == 4 || meatMaterial == 5)
                            score -= 5;
                        if (meatMaterial == 6)
                            score -= 15;

                        score += 5 * (Ids.Count() - 2);

                        switch (meatMaterial)
                        {
                            case 0: 
                                {
                                    score += 100;
                                    break;
                                }
                            case 1:
                                {
                                    score += 50;
                                    break;
                                }
                            case 2:
                                {
                                    score -= 25;
                                    break;
                                }

                        }

                        Debug.Log("BurgerOk");
                    }
                    else
                    {
                        score -= 25;
                    }


                    break;
                }
        
            case 1:
                {

                    List<int> RightIds1 = new List<int>();
                    RightIds1.Add(0);
                    RightIds1.Add(4);
                    RightIds1.Add(5);
                    RightIds1.Add(3);
                    RightIds1.Add(7);
                    RightIds1.Add(1);

                    if (Ids.SequenceEqual(RightIds1))
                    {



                        if (meatMaterial == 4 || meatMaterial == 5)
                            score -= 5;
                        if (meatMaterial == 6)
                            score -= 15;

                        score += 5 * (Ids.Count() - 2);

                        switch (meatMaterial)
                        {
                            case 0:
                                {
                                    score += 100;
                                    break;
                                }
                            case 1:
                                {
                                    score += 50;
                                    break;
                                }
                            case 2:
                                {
                                    score -= 25;
                                    break;
                                }

                        }

                        Debug.Log("BurgerOk");
                    }
                    else
                    {
                        score -= 25;
                    }



                    break;
                }

            case 2:
                {

                    List<int> RightIds1 = new List<int>();
                    RightIds1.Add(0);
                    RightIds1.Add(4);
                    RightIds1.Add(5);
                    RightIds1.Add(2);
                    RightIds1.Add(7);
                    RightIds1.Add(6);
                    RightIds1.Add(1);

                    List<int> RightIds2 = new List<int>();
                    RightIds2.Add(0);
                    RightIds2.Add(4);
                    RightIds2.Add(5);
                    RightIds2.Add(2);
                    RightIds2.Add(6);
                    RightIds2.Add(7);
                    
                    RightIds2.Add(1);




                    if (Ids.SequenceEqual(RightIds1) || Ids.SequenceEqual(RightIds2))
                    {
                    



                        if (meatMaterial == 4 || meatMaterial == 5)
                            score -= 5;
                        if (meatMaterial == 6)
                            score -= 15;

                        score += 5 * (Ids.Count() - 2);

                        switch (meatMaterial)
                        {
                            case 0:
                                {
                                    score += 100;
                                    break;
                                }
                            case 1:
                                {
                                    score += 50;
                                    break;
                                }
                            case 2:
                                {
                                    score -= 25;
                                    break;
                                }

                        }

                        Debug.Log("BurgerOk");
                    }
                    else
                    {
                        score -= 25;
                    }



                    break;
                }

            case 3:
                {

                    List<int> RightIds1 = new List<int>();
                    RightIds1.Add(0);
                    RightIds1.Add(4);
                    RightIds1.Add(5);
                    RightIds1.Add(6);
                    RightIds1.Add(1);

                    if (Ids.SequenceEqual(RightIds1))
                    {



                        if (meatMaterial == 4 || meatMaterial == 5)
                            score -= 5;
                        if (meatMaterial == 6)
                            score -= 15;

                        score += 5 * (Ids.Count() - 2);

                        switch (meatMaterial)
                        {
                            case 0:
                                {
                                    score += 100;
                                    break;
                                }
                            case 1:
                                {
                                    score += 50;
                                    break;
                                }
                            case 2:
                                {
                                    score -= 25;
                                    break;
                                }

                        }

                        Debug.Log("BurgerOk");
                    }
                    else
                    {
                        score -= 25;
                    }



                    break;
                }

            case 4:
                {

                    List<int> RightIds1 = new List<int>();
                    RightIds1.Add(0);
                    RightIds1.Add(5);
                    RightIds1.Add(2);
                    RightIds1.Add(3);
                    RightIds1.Add(6);
                    RightIds1.Add(1);

                    if (Ids.SequenceEqual(RightIds1))
                    {



                        if (meatMaterial == 4 || meatMaterial == 5)
                            score -= 5;
                        if (meatMaterial == 6)
                            score -= 15;

                        score += 5 * (Ids.Count() - 2);

                        switch (meatMaterial)
                        {
                            case 0:
                                {
                                    score += 100;
                                    break;
                                }
                            case 1:
                                {
                                    score += 50;
                                    break;
                                }
                            case 2:
                                {
                                    score -= 25;
                                    break;
                                }

                        }

                        Debug.Log("BurgerOk");
                    }
                    else
                    {
                        score -= 25;
                    }



                    break;
                }
            case 5:
                {

                    List<int> RightIds1 = new List<int>();
                    RightIds1.Add(0);
                    RightIds1.Add(3);
                    RightIds1.Add(3);
                    RightIds1.Add(3);
                    RightIds1.Add(3);
                    RightIds1.Add(1);

                    if (Ids.SequenceEqual(RightIds1))
                    {



                        

                        score += 5 * (Ids.Count() - 2);

                        switch (meatMaterial)
                        {
                            case 0:
                                {
                                    score += 100;
                                    break;
                                }
                            case 1:
                                {
                                    score += 50;
                                    break;
                                }
                            case 2:
                                {
                                    score -= 25;
                                    break;
                                }

                        }

                        Debug.Log("BurgerOk");
                    }
                    else
                    {
                        score -= 25;
                    }



                    break;
                }

            case 6:
                {

                    List<int> RightIds1 = new List<int>();
                    RightIds1.Add(0);
                    RightIds1.Add(4);
                    RightIds1.Add(5);
                    RightIds1.Add(3);
                    RightIds1.Add(5);
                    RightIds1.Add(6);
                    RightIds1.Add(7);
                    RightIds1.Add(1);

                    List<int> RightIds2 = new List<int>();
                    RightIds2.Add(0);
                    RightIds2.Add(4);
                    RightIds2.Add(5);
                    RightIds2.Add(3);
                    RightIds2.Add(5);
                    RightIds2.Add(7);
                    RightIds2.Add(6);

                    RightIds2.Add(1);




                    if (Ids.SequenceEqual(RightIds1) || Ids.SequenceEqual(RightIds2))
                    {




                        if (meatMaterial == 4 || meatMaterial == 5)
                            score -= 5;
                        if (meatMaterial == 6)
                            score -= 15;

                        score += 5 * (Ids.Count() - 2);

                        switch (meatMaterial)
                        {
                            case 0:
                                {
                                    score += 100;
                                    break;
                                }
                            case 1:
                                {
                                    score += 50;
                                    break;
                                }
                            case 2:
                                {
                                    score -= 25;
                                    break;
                                }

                        }

                        Debug.Log("BurgerOk");
                    }
                    else
                    {
                        score -= 25;
                    }



                    break;
                }

            case 7:
                {

                    List<int> RightIds1 = new List<int>();
                    RightIds1.Add(0);
                    RightIds1.Add(4);
                    RightIds1.Add(5);
                    RightIds1.Add(2);
                    RightIds1.Add(7);
                    RightIds1.Add(1);

                    if (Ids.SequenceEqual(RightIds1))
                    {



                        if (meatMaterial == 4 || meatMaterial == 5)
                            score -= 5;
                        if (meatMaterial == 6)
                            score -= 15;

                        score += 5 * (Ids.Count() - 2);

                        switch (meatMaterial)
                        {
                            case 0:
                                {
                                    score += 100;
                                    break;
                                }
                            case 1:
                                {
                                    score += 50;
                                    break;
                                }
                            case 2:
                                {
                                    score -= 25;
                                    break;
                                }

                        }

                        Debug.Log("BurgerOk");
                    }
                    else
                    {
                        score -= 25;
                    }



                    break;
                }
        }

        scoreText.text = "Score:\n" + score;



        MenuNow++;
        if(MenuNow == 8) MenuNow= 0;
        menu.GetComponent<Renderer>().material = menus[MenuNow];
        



    }
    
}
