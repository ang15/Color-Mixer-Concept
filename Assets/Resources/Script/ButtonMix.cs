using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMix : MonoBehaviour
{
    public BlenderController Blender;
    public GameObject BlenderWater;
    public GameObject BlenderMask;
    public bool status; 
    public bool active;

    public int _percentage;
    public Text WinningPercentageText;
    public Text PercentageText;
    public GameObject Won;
    public GameObject Lost;

    public int _firstfruit;
    public int _secondfruit;
    public int _thirdfruit;

   private void Update()
    {
        if (active )
        {
            if (_percentage >= 70)
            {
                Won.SetActive(true);
                WinningPercentageText.text = "" + _percentage;

            }
            else
            if (_percentage > 0)
            {
                Lost.SetActive(true);
                PercentageText.text = "" + _percentage;
            }
        }
    }

    private void OnMouseDown()
    {
        if (status)
        {
            if (Blender.fruitColors.Count > 0 && Blender.Status == true)
            {
                Blender.Status = false;
                _percentage = WinningPercentage();
                StartCoroutine(CoroutineWater());
                StartCoroutine(CoroutineBlender());
                MixColorWhite();
                foreach (FruitController fruitAnimations in Blender.fruitAnimations)
                {
                    fruitAnimations.gameObject.SetActive(false);
                }
            }
        }
    }

 

    private int WinningPercentage()
    {
        int firstfruit=0;
        int secondfruit=0;
        int thirdfruit=0;
        int result = 0;
        foreach (Fruit fruit in Blender.fruitColors)
        {
            if (fruit._frute == 1)
            {
                firstfruit++;
            }
            else
             if (fruit._frute == 2)
            {
                secondfruit++;
            }
            else
            if (fruit._frute == 3)
            {
                thirdfruit++;
            }
        }
            
        result += Analysis(firstfruit,_firstfruit);
        result += Analysis(secondfruit,_secondfruit);
        result += Analysis(thirdfruit,_thirdfruit);
        return result;
    }

    private int Analysis(int numberfruit,int frute)
    {
        int result = 0;
        if (numberfruit == frute)
        {
            result = 30;
        }
        else
        if (numberfruit > frute )
        {
            result = 20;
        }
        else if (numberfruit < frute && numberfruit > 0)
        {
            result = 20;
        }
        else
        {
            result = 15;
        }
        return result;
    }

    private IEnumerator CoroutineWater()
    {
        status = false;
        for (int i = 0; i < 9; i++)
        {
            yield return new WaitForSeconds(0.3f);
            BlenderMask.transform.position += new Vector3(0, 0.05f, 0);
        }
    }

    private IEnumerator CoroutineBlender()
    {
        for (int i = 0; i < 7; i++)
        {
            yield return new WaitForSeconds(0.1f);
            Blender.transform.rotation = Quaternion.Euler(Blender.transform.rotation.eulerAngles.x, Blender.transform.rotation.eulerAngles.y, -8);
            yield return new WaitForSeconds(0.1f);
            Blender.transform.rotation = Quaternion.Euler(Blender.transform.rotation.eulerAngles.x, Blender.transform.rotation.eulerAngles.y, 0);
            yield return new WaitForSeconds(0.1f);
            Blender.transform.rotation = Quaternion.Euler(Blender.transform.rotation.eulerAngles.x, Blender.transform.rotation.eulerAngles.y, 8);
        }
        yield return new WaitForSeconds(0.1f);
        Blender.transform.rotation = Quaternion.Euler(Blender.transform.rotation.eulerAngles.x, Blender.transform.rotation.eulerAngles.y, 0);
        active = true;
    }

    private void MixColorWhite()
    {
        BlenderWater.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, 0);
        foreach (Fruit fruit in Blender.fruitColors)
        {
            BlenderWater.GetComponent<MeshRenderer>().material.color += fruit.color;
            fruit.gameObject.SetActive(false);
        }
        BlenderWater.GetComponent<MeshRenderer>().material.color /= Blender.fruitColors.Count;
        BlenderWater.GetComponent<MeshRenderer>().material.color = new Color(BlenderWater.GetComponent<MeshRenderer>().material.color.r,
            BlenderWater.GetComponent<MeshRenderer>().material.color.g,
            BlenderWater.GetComponent<MeshRenderer>().material.color.b,
            BlenderWater.GetComponent<MeshRenderer>().material.color.a * Blender.fruitColors.Count);
    }

}
