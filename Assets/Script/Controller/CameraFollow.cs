using System.Collections.Generic;
using UnityEngine;

namespace Script.Controller {
    public class CameraFollow : MonoBehaviour {

        private Transform target;
        private Vector3 offset;
        private Vector3 velocity;
        
        public List<Renderer> listLastRend = new List<Renderer>();
        
        private void FixedUpdate()
        {
            
        }

        public void LateUpdate() {
            if(target != null)
            {
                //平滑缓冲，游戏物体不是僵硬的移动而是做减速缓冲运动到指定位置
                var position = transform.position;
                var position1 = target.position;
                
                
                float posX = Mathf.SmoothDamp(position.y,
                    //target.position.x - offset.x等于主摄像机的位置坐标
                    position1.x - offset.x, ref velocity.x, 0.05f);
                
                //float posY = Mathf.SmoothDamp(position.y,
                    //target.position.x - offset.x等于主摄像机的位置坐标
                //    position1.y + 2.52f, ref velocity.y, 0.05f);
                float posZ = Mathf.SmoothDamp(position.z,
                    position1.z - offset.z, ref velocity.z, 0.05f);

                //防止很大弧度的屏幕抖动
                //if (posY > transform.position.y) {
                var transform1 = transform;
                transform1.position = new Vector3(posX, 0, posZ); 
                //}
            }
            
            if (target == null && GameObject.FindGameObjectWithTag("Player") != null)
            {
                //查找目标tag标签为Player游戏物体的位置值
                target = GameObject.FindGameObjectWithTag("Player").transform;
                //计算出目标点到摄像机位置的偏移值
                offset = target.position - transform.position;
            }
            
            for (int i = 0; i < listLastRend.Count; i++)
            {
                TransparencySet(listLastRend[i], 1.0f); // 设置半透明
            }
            listLastRend.Clear();
            Vector3 tarDir = (target.position - transform.position).normalized;
            Debug.DrawLine(target.position, transform.position, Color.red);

            float tarDis = Vector3.Distance(target.position, transform.position);
            RaycastHit[] listHitObj = Physics.RaycastAll(transform.position, tarDir, tarDis);
            //Debug.Log(listHitObj.Length);
            for (int i = 0; i < listHitObj.Length; i++)
            {
                RaycastHit hit = listHitObj[i];
                if (hit.transform == target.transform)
                {
                    continue;
                }
                Renderer renderer = hit.collider.GetComponent<Renderer>();

                if (renderer)
                {
                    listLastRend.Add(renderer);
                    TransparencySet(renderer,0.3f);
                }
            }

        }

        void TransparencySet(Renderer renderer,float a)
        {
            try {
                renderer.material.shader = Shader.Find("UI/Lit/Transparent");
                renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, a);
            }
            catch {
            }
        }
    }
}