using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public RectTransform m_JoystickBack;
    public RectTransform m_Joystick;
    public Transform m_Player;

    Vector3 m_vecMove;
    Vector2 m_vecNormal;

    float m_fRadius;
    public float m_fSpeed;
    float m_fSqr = 0f;
    bool m_bTouch = false;


    void Start()
    {
        m_fRadius = m_JoystickBack.rect.width * 0.5f;
    }

    void Update()
    {
        if (m_bTouch)
        {
            m_Player.GetComponent<CharacterController>().Move(-m_vecMove);
        }
    }

    void OnTouch(Vector2 vec2Touch)
    {
        Vector2 vec2 = new Vector2(vec2Touch.x - m_JoystickBack.position.x
                       , vec2Touch.y - m_JoystickBack.position.y);
        vec2 = Vector2.ClampMagnitude(vec2, m_fRadius);
        m_Joystick.localPosition = vec2;
        float fSqr = (m_JoystickBack.position - m_Joystick.position).sqrMagnitude
                     / (m_fRadius * m_fRadius);
        Vector2 vec2Normal = vec2.normalized;
        m_vecMove = new Vector3(vec2Normal.x * m_fSpeed * Time.deltaTime * fSqr
                                , 0f
                                , vec2Normal.y * m_fSpeed * Time.deltaTime * fSqr);
        // m_Player.localEulerAngles = new Vector3(0f, Mathf.Atan2(vec2Normal.x, vec2Normal.y)
        //                                          * Mathf.Rad2Deg, 0f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnTouch(eventData.position);
        m_bTouch = true;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        OnTouch(eventData.position);
        m_bTouch = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        m_Joystick.localPosition = Vector2.zero;
        m_bTouch = false;
    }
}
