using UnityEngine;
using UnityEngine.EventSystems;

public class Animation : MonoBehaviour
{
    Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Play()
    {
        anim.Play("NombreDeLaAnimacion");
    }
}
