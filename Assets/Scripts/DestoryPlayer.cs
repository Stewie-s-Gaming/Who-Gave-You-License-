using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestoryPlayer : MonoBehaviour
{
    [SerializeField] string tag;
    [SerializeField] string sceneName;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Entered Collision with SideWalk.");
        if (tag == collision.gameObject.tag)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
