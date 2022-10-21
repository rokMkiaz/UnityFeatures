using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RopeCreate : MonoBehaviour
{
    public GameObject ropePrefab;
    public int ropeCnt;//� ������?
    public Rigidbody2D pointRig; //rigidbody���� ����
    public HingeJoint2D exJoint;
    public GameObject princess;
    GameObject lastNode;
    List<GameObject> Nodes = new List<GameObject>();

    LineRenderer lr;
        
    // Start is called before the first frame update
    void Start()
    {

        //set the line renderer
        lr = GetComponent<LineRenderer>();

        //sets princess
        if (princess == null)
            princess = GameObject.FindGameObjectWithTag("Princess");

        //set last node to the hook
        lastNode = transform.gameObject;

        //add it to nodelist
        Nodes.Add(transform.gameObject);



        //set the ropeCnt
        for(int i = 0;i<ropeCnt; i++)
        {
            HingeJoint2D currentJoint = Instantiate(ropePrefab, transform).GetComponent<HingeJoint2D>();
            currentJoint.transform.localPosition = new Vector3(0, (i + 1) * -5.0f, 0);//0.25�� ĸ������ �Ÿ�
            if (i == 0)
                currentJoint.connectedBody = pointRig;
            else
                currentJoint.connectedBody = exJoint.GetComponent<Rigidbody2D>();

            exJoint = currentJoint;

            if(i==ropeCnt-1)
            {
                currentJoint.GetComponent<Rigidbody2D>().mass = 10;
                currentJoint.GetComponent<SpriteRenderer>().enabled = false;
            }
            Nodes.Add(currentJoint.gameObject); // �߰� Nodes�� ����Ʈ ��ġ�� �߰��ϴ� ����
            Debug.Log(Nodes.Count);
        }
    }

    // Update is called once per frame
    void Update()
    {
        RenderLine();
    }

    void RenderLine()
    {
        int i = 0;
        //set vertex count of rope
        lr.positionCount = Nodes.Count+1;  //Nodes Count = Base�� + �� ����Ʈ ��ġ + ���������� ������ġ�� �����ش�

        //each node is a vertes oft the rope
        for(i=0; i<Nodes.Count; i++)
        {
            lr.SetPosition(i, Nodes[i].transform.position);
        }
        
        //sets last vetex of rope to be the player 
        lr.SetPosition(Nodes.Count, princess.transform.position);  //������ ���������̶� �ӽ������� ���� ó��

    }

}
