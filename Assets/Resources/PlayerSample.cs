using UnityEngine;
using Photon.Pun;

public class PlayerSample : MonoBehaviourPun
{
    [SerializeField] GameObject allow = default;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (photonView.IsMine)
        {
            allow.gameObject.SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine) return;
        
    }
}
