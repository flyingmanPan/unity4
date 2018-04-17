using UnityEngine;
using System.Collections;
//Done
//Pass
public class CCFlyAction : SSAction
{
    float speed;
    //float gforce;
    //float time;
    Vector3 direction;
    // Use this for initialization
    public override void Start()
    {
        //time = 0;
        //gforce = 10;
        enable = true;
        speed = GameObj.GetComponent<DiskProperties>().speed;
        direction = GameObj.GetComponent<DiskProperties>().direction;
    }

    // Update is called once per frame
    public override void Update()
    {
        //Add G force;
        if(GameObj.activeSelf)
        {
            Trans.Translate(direction * speed * Time.deltaTime);
            if (this.Trans.position.y<-4)
            {
                this.destroy = true;
                this.enable = false;
                this.callback.SSActionEvent(this);
            }
        }
    }
    public static CCFlyAction GetSSAction()
    {
        return ScriptableObject.CreateInstance<CCFlyAction>();
    }
}
