using Script.Model;
using UnityEngine;

public class SlideInputController : MonoBehaviour
{
    // Start is called before the first frame update
    public Service service;
    private bool GetInput;
    private int inputRange = 5;
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        //有触摸点，且滑动
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {
            GetInput = true;
        }

        if (GetInput && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
            //获取滑动的距离  Input.GetTouch(0).deltaPosition
            Vector2 touchDelPos = Input.GetTouch(0).deltaPosition;
            //比较两个方向滑动的绝对值的大小，，那个大，认为在那个方向在滑动
            if (Mathf.Abs(touchDelPos.x) > Mathf.Abs(touchDelPos.y)) {
                //滑动距离，，这个值很灵敏，注意不要设置的太小
                if (touchDelPos.x > inputRange) {
                    // a
                    //dieX = 1;
                    GetComponentInChildren<PlayerAudioController>().PlayMoveSE();
                    service.reverseMapService.ReverseCommand(60);
                    GetInput = false;
                } //X方向的作用滑动
                else if (touchDelPos.x < -inputRange) {
                    // d
                    //dieX = -1;
                    GetComponentInChildren<PlayerAudioController>().PlayMoveSE();
                    service.reverseMapService.ReverseCommand(-60);
                    GetInput = false;

                }
            }
            else {
                if (touchDelPos.y > inputRange) {
                    // w
                    //dieY = 1;
                    if(!service.reverseMapService.GetCanJump()) return;
                    service.reverseMapService.ReverseCommand(180); //ReversePlayer();
                    GetComponentInChildren<PlayerAnimController>().PlayJump();
                    GetComponentInChildren<PlayerAudioController>().PlayJumpSE();
                    GetInput = false;

                }
                else if (touchDelPos.y < -inputRange) {
                    // s
                    GetComponentInChildren<PlayerAudioController>().PlayDownSE();
                    service.playerSlideService.OnSlide();
                    GetInput = false;
                }
            }
        }
    }
}
