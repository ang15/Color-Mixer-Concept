using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    private Animator _animator;
    public BlenderController Blender;
    public Fruit _fruitPrefab;
    public bool active;
    public bool Status;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
            if (Blender.Status)
            {  Blender.Status = false;
                Blender.OpenBlender();
                _animator.SetTrigger("Go");
                Blender.fruitColors.Add(Instantiate(_fruitPrefab, Blender.transform));
                Blender.fruitColors[Blender.fruitColors.Count - 1].gameObject.SetActive(false);
            }        
    }


    void Update()
    {
        if (active)
        {
            active = false;
            Blender.CloseBlender();
            gameObject.SetActive(false);
            Blender.fruitColors[Blender.fruitColors.Count - 1].gameObject.SetActive(true);
            gameObject.SetActive(true);
        }
    }
}