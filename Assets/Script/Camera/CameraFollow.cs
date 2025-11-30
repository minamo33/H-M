using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        //プレイヤー
    public float smoothSpeed = 5f;  //カメラの追従スピード
    public Vector3 offset;          //カメラの位置移動

    private void LateUpdate()
    {
        if (target == null) return;

        //目標位置（ｘだけ追従するタイプ）
        Vector3 desiredPositio = new Vector3(
            target.position.x + offset.x,
            offset.y,
            offset.z
            );

        //現在地から目標値まで移動させる
        transform.position = Vector3.Lerp(
            transform.position,
            desiredPositio,
            smoothSpeed * Time.deltaTime
            );

    }

    
}
