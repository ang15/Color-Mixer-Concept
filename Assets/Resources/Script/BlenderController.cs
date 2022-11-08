using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlenderController : MonoBehaviour
{
    private Animator _animator;
    public FruitController[] fruitAnimations;
    public List<Fruit> fruitColors;
    public bool Status;
    public bool Active;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

   
    public void OpenBlender()
    {
            _animator.SetTrigger("Open");
    }

    public void CloseBlender()
    {
            _animator.SetTrigger("Close");
    }
}
