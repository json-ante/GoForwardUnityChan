using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CubeController : MonoBehaviour
{
    //キューブの移動速度
    private float speed = -12;

    //消滅位置
    private float deadLine = -10;

    //unityちゃんのタグ
    private const string unitychanTagName = "Player";
    //キューブのタグ
    private const string cubeTagName = "Cube";
    //地面のタグ
    private const string groundTagName = "Ground";
    //衝突したときの効果音
    AudioSource hitSound;
    // Start is called before the first frame update
    void Start()
    {
        //キューブオブジェクトにアタッチされているAudioSouceコンポーネント取得
        hitSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);
        //画面外に出たら破棄
        if(transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    //衝突したときの処理
    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnPlayHitSound(collision.gameObject.tag);
    }

    //効果音を流す
    void OnPlayHitSound(string targetTagName)
    {
        //効果音を流す判定処理
        if (!IsPlaySound(targetTagName)) return;
        //効果音を流す
        this.hitSound.Play();
    }

    //衝突したオブジェクトの効果音を流す判定処理
    bool IsPlaySound(string targetTagName)
    {
        if (cubeTagName == targetTagName) return true;
        if (groundTagName == targetTagName) return true;
        return false;
    }
}
