using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteController : MonoBehaviour
{
    public enum GunState {NoWeapon,ShortWeapon,LongWeapon};
    public GunState state;

    public GameObject GFX;
    public Sprite[] PlayerSprites;
    void FixedUpdate()
    {
        switch (state) 
        {
            case GunState.NoWeapon:
                GFX.GetComponent<SpriteRenderer>().sprite = PlayerSprites[0];
            break;

            case GunState.ShortWeapon:
                GFX.GetComponent<SpriteRenderer>().sprite = PlayerSprites[1];
            break;

            case GunState.LongWeapon:
                GFX.GetComponent<SpriteRenderer>().sprite = PlayerSprites[2];
            break;
        }
    }
}
