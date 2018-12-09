using UnityEngine;
using System.Collections;
using Valve.VR.InteractionSystem;

public class Bomb : VRObjectBase{

    public GameObject Effect;
    public float BomTime;
    private bool Picked;
    private bool LetsBom;
    
    public void Update() {
        if (Picked)
        {
            if (device != null)
            {
                if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
                {
                    if (LetsBom)
                    {
                        return;
                    }
                    Invoke("Dokan", BomTime);
                    LetsBom = true;
                }
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                if (LetsBom)
                {
                    return;
                }
                Invoke("Dokan", BomTime);
                LetsBom = true;
            }
        }
    }
    public void BombMoti()
    {
        Debug.Log("爆弾を持った！！！");
        Picked = true;
    }
    public void BombHanasi()
    {
        Debug.Log("爆弾を離した！！！");
        Picked = false;
    }

    private void Dokan() {
        GameObject obj;
        if (Picked) {
            obj=(GameObject)Instantiate(Effect,transform.parent.position,new Quaternion());
            obj.GetComponent<Explosion>().device =device;
            Hand.DetachObject(gameObject);
        }
        else
        {
            obj=(GameObject)Instantiate(Effect,transform.position,new Quaternion());
        }
        
        Destroy(obj,2.1f);
        Destroy(gameObject.GetComponent<MeshRenderer>(),1.0f);
        DestroyImmediate(GetComponent<Throwable>());
        DestroyImmediate(rigidBody);
        Destroy(gameObject,8);
        Destroy(this,10);
    }
}
