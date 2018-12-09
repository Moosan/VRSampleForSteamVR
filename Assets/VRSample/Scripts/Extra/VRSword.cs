using UnityEngine;
using System.Collections;
using Valve.VR.InteractionSystem;
public class VRSword : VRObjectBase
{
    //手に持たれてるかどうか
    private bool Picked { get; set; }

    public float KireruHayasa;

    public float KireruTaiseki;

    private bool Sindou;

    public override void Awake()
    {
        base.Awake();
        Picked = false;
        GetComponent<Throwable>().attachEaseIn = true;
    }

    //衝突したら勝手に呼ばれる
    public void OnCollisionEnter(Collision other)
    {
        var trans = other.transform;
        if (trans.tag == "VRItem"&&Picked)
        {
            var sca = trans.lossyScale;
            if (sca.x * sca.y * sca.z >= KireruTaiseki)
            {
                var force = Hand.GetTrackedObjectVelocity();
                var mag = force.magnitude;
                if (mag >= KireruHayasa)
                {
                    var obj0 = other.gameObject;
                    var forward = Velocity.normalized;
                    var right = Vector3.Cross(forward, transform.parent.up).normalized;
                    var direc1 = (forward + right).normalized;
                    var direc2 = (forward - right).normalized;
                    sca *= 0.7f;
                    var mass = obj0.GetComponent<Rigidbody>().mass/2;
                    var obj1 = (GameObject)Instantiate(obj0, trans.position + right * 0.1f, trans.rotation);
                    var obj2 = (GameObject)Instantiate(obj0, trans.position - right * 0.1f, trans.rotation);
                    Destroy(obj0);
                    obj1.GetComponent<Rigidbody>().mass = mass;
                    obj2.GetComponent<Rigidbody>().mass = mass;
                    obj1.GetComponent<Rigidbody>().velocity=direc1 * mag;
                    obj2.GetComponent<Rigidbody>().velocity=direc2 * mag;
                    obj1.transform.localScale = sca;
                    obj2.transform.localScale = sca;

                    //出来てるかわかんないけど振動
                    Sindou = true;
                    Invoke("SindouYameru",0.3f);
                }
            }
        }
    }

    public void KenMoti() {
        Debug.Log("剣を持った！！！");
        Picked = true;
    }
    public void KenHanasi() {
        Debug.Log("剣を離した！！！");
        Picked = false;
    }
    private Vector3 Pos0,Pos1;
    private Vector3 Velocity;
    public void Update() {
        if (Picked) {
            Pos1 = transform.parent.transform.position;
            Velocity = (Pos1 - Pos0) / Time.deltaTime;
        }
        Pos0 = transform.position;
        if (Sindou&&device!=null) {
            device.TriggerHapticPulse(2000);
        }
    }
    private void SindouYameru() {
        Sindou = false;
    }
}
