
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManagerSample : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        //PhotonNetwork.ConnectToRegion(); // 希望するリージョンを指定（例: "us"）
        // 最適なリージョンを自動的に選択して接続
        //PhotonNetwork.ConnectToRegionMaster();

    }



    public override void OnConnectedToMaster()
    {
        //PhotonNetwork.JoinRandomRoom();

    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        var option = new RoomOptions();
        option.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(null, option);
    }

    public override void OnJoinedRoom()
    {
        Vector3 pos = new Vector3(Random.Range(-3.0f, 3.0f), Random.Range(-3.0f, 3.0f), 0.0f);
        GameObject player = PhotonNetwork.Instantiate("Player", pos, Quaternion.identity);
    }
}
