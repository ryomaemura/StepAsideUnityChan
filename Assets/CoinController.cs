﻿using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour
{
    //Unityちゃんのオブジェクト
    private GameObject unitychan;

    // Use this for initialization
    void Start ()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find ("unitychan");

        //回転を開始する角度を設定
        this.transform.Rotate (0, Random.Range (0, 360), 0);
    }

    // Update is called once per frame
    void Update ()
    {
        //回転
        this.transform.Rotate (0, 3, 0);

        // アイテムがunityちゃんのz座標より小さくなったら（アイテムをunityちゃんが通り過ぎたら）起動
        if (gameObject.transform.position.z < this.unitychan.transform.position.z - 10) {
            // 通り過ぎたアイテムを削除
            Destroy(gameObject);
        }
    }
}