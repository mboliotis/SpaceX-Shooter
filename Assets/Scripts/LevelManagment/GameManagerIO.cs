using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerIO : MonoBehaviour
{

    List<MessageEnum> messageBuff;


    // Start is called before the first frame update
    void Start()
    {
        messageBuff = new List<MessageEnum>();
    }

    // Update is called once per frame
    void Update()
    {
        ReadBuff();
    }


    void ReadBuff()
    {
        foreach (MessageEnum message in messageBuff)
        {
            if(message == MessageEnum.GAME_END)
            {
                this.gameObject.GetComponent<GameMaster>().DisplayOutro();
            }
            else if(message == MessageEnum.MISSION_FAILED)
            {
                this.gameObject.GetComponent<GameMaster>().MissionFailed();
            }
            else
            {
                if(message == MessageEnum.PLAYER_DEAD)
                {
                    
                    this.gameObject.GetComponent<GameMaster>().PlayerDied();
                }
            }
        }
        messageBuff.Clear();
    }

    public void WriteToBuffer(MessageEnum mes)
    {
        messageBuff.Add(mes);
    }

}
