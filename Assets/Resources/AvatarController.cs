using Photon.Pun;
using UnityEngine;

public class AvatarController : MonoBehaviourPun, IPunObservable
{
    private Vector3 networkPosition;

    private void Update()
    {
        // 自身が生成したオブジェクトのみ動かせる
        if (photonView.IsMine)
        {
            // 入力による移動
            var input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
            transform.Translate(6f * Time.deltaTime * input.normalized);
        }
        else
        {
            // 他プレイヤーのオブジェクトは補間して移動させる（スムーズに同期）
            transform.position = Vector3.Lerp(transform.position, networkPosition, Time.deltaTime * 10f);
        }
    }

    // データを送受信するためのメソッド（Photonがコールする）
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // 自身の位置を送信
            stream.SendNext(transform.position);
        }
        else
        {
            // 他プレイヤーの位置を受信
            networkPosition = (Vector3)stream.ReceiveNext();
        }
    }
}
