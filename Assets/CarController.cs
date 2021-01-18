using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    //Unityちゃんのオブジェクト
    private GameObject unitychan;

    // Use this for initialization
    void Start ()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find ("unitychan");
    }

    // Update is called once per frame
    void Update ()
    {
        // アイテムがunityちゃんのz座標より小さくなったら（アイテムをunityちゃんが通り過ぎたら）起動
        if (gameObject.transform.position.z < this.unitychan.transform.position.z - 10) {
            // 通り過ぎたアイテムを削除
            Destroy(gameObject);
        }
    }
}
