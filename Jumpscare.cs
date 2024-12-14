using UnityEngine;
using System.Collections;

public class Jumpscare : MonoBehaviour
{
    [Header("Player")]
    public GameObject gorillaPlayer;
    public new Rigidbody rigidbody;
    public Transform playerTrans;
    public new string tag;

    [Header("Objects")]
    public Transform respawnPoint;
    public AudioSource audioSource;
    public GameObject jumpscare;

    [Header("Time")]
    public float jumpscareTime;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag))
        {
            StartCoroutine(EnableJumpscare());
        }
    }

    IEnumerator EnableJumpscare()
    {
        Collider[] colliders = Object.FindObjectsByType<Collider>(FindObjectsSortMode.None);
        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
        }
        gorillaPlayer.GetComponent<Rigidbody>().isKinematic = true;
        gorillaPlayer.GetComponent<Rigidbody>().useGravity = false;
        gorillaPlayer.transform.position = respawnPoint.transform.position;
        gorillaPlayer.transform.rotation = respawnPoint.transform.rotation;
        audioSource.Play();
        jumpscare.SetActive(true);

        yield return new WaitForSeconds(jumpscareTime);

        DisableJumpscare();
    }

    public void DisableJumpscare()
    {
        Collider[] colliders = Object.FindObjectsByType<Collider>(FindObjectsSortMode.None);
        foreach (Collider collider in colliders)
        {
            collider.enabled = true;
        }
        StopAllCoroutines();
        gorillaPlayer.GetComponent<Rigidbody>().isKinematic = false;
        gorillaPlayer.GetComponent<Rigidbody>().useGravity = true;
        jumpscare.SetActive(false);
        audioSource.Stop();
    }
}

//This script was made by Powerrrr! Discord: PowerVacuum.
//You don't have to give Credits but I would like credits :)
