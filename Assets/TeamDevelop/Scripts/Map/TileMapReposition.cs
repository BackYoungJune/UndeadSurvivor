using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapReposition : MonoBehaviour
{
    //--------------------------------------------------------					
    // �ܺ� ���� �Լ� & ������Ƽ					
    //--------------------------------------------------------		
    public void TileMapPosition()
    {
        Vector3 playerPos = Player.transform.position;
        Vector3 myPos = transform.position;
        float diffx = Mathf.Abs(playerPos.x - myPos.x);
        float diffy = Mathf.Abs(playerPos.y - myPos.y);

        Vector3 playerDir = Player.inputVec.normalized;
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;

        if (diffx > diffy)
        {
            transform.Translate(Vector3.right * dirX * 40);
        }
        else
        {
            transform.Translate(Vector3.up * dirY * 40);
        }

        //switch (transform.tag)
        //{
        //    case "Ground":
        //        {

        //            break;
        //        }
        //}
    }


    public Player Player;
    //--------------------------------------------------------					
    // ���� �ʵ� ����					
    //--------------------------------------------------------	
    private Collider2D coll;
    void Awake()
    {
        coll = GetComponent<Collider2D>();
    }


}
