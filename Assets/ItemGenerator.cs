using UnityEngine;
using System.Collections;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;
    //スタート地点
    private int startPos = 80;
    //ゴール地点
    private int goalPos = 360;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    //Unityちゃんのオブジェクト
    private GameObject unitychan;

    // Use this for initialization
    void Start ()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find ("unitychan");

        //一定の距離ごとにアイテムを生成
        for (int i = startPos; i < goalPos; i+=15)
        {
            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range (1, 11);
            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate (conePrefab);
                    cone.transform.position = new Vector3 (4 * j, cone.transform.position.y, i);
                }
            }
            else
            {

                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range (1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置:30%車配置:10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate (coinPrefab);
                        coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, i + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate (carPrefab);
                        car.transform.position = new Vector3 (posRange * j, car.transform.position.y, i + offsetZ);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update ()
    {
        // アイテムがunityちゃんのz座標より小さくなったら（アイテムをunityちゃんが通り過ぎたら）起動
        if (this.carPrefab.transform.position.z < this.unitychan.transform.position.z) {
            // 通り過ぎたアイテムを削除
            Destroy(this.carPrefab);
        }

        // アイテムがunityちゃんのz座標より小さくなったら（アイテムをunityちゃんが通り過ぎたら）起動
        if (this.coinPrefab.transform.position.z == this.unitychan.transform.position.z) {
            // 通り過ぎたアイテムを削除
            Destroy(this.coinPrefab);
        }
    }
}