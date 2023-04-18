using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour, IInteractable
{
    [SerializeField] private Lights[] _lights;
    [SerializeField] private MonsterSpawner _monster;
    [SerializeField] private DoorBlock _doorBlock;
    [SerializeField] private Camera _monsterAnnounceCamera;
    [SerializeField] private Player _player;
    [SerializeField] private AudioSource _cameraSound;

    private Coroutine _monsterAnnounce;
    private WaitForSeconds _announceLength = new WaitForSeconds(1.5f);
    private bool _active = true;

    public void OnInteract()
    {
        if (_active)
        {
            LightsOn();
            _doorBlock.gameObject.SetActive(false);

            if (_monster != null)
                _monster.Spawn();

            _monsterAnnounceCamera.gameObject.SetActive(true);
            _player.gameObject.SetActive(false);
            _cameraSound.Play();
            _monsterAnnounce = StartCoroutine(MonsterAnnounce());
        }
        
        _active = false;
    }

     
    public void LightsOn()
    {
        foreach(var light in _lights)
            light.TurnLightsOn();
    }

    private IEnumerator MonsterAnnounce()
    {
        yield return _announceLength;
        _monsterAnnounceCamera.gameObject.SetActive(false);
        _player.gameObject.SetActive(true);
    }
}
