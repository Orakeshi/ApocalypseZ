using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Orakeshi.ApocalypseZ.Game.Weapon
{
    public class Gun : MonoBehaviour
    {
        [Header("Prefab References")]
        public GameObject bullet;
        public GameObject casingPrefab;
        public GameObject muzzleFlashPrefab;

        [Header("Location References")]
        [SerializeField] private Animator gunAnimator;
        [SerializeField] private Transform barrel;
        [SerializeField] private Transform casingExitLocation;
        public Magazine magazine;
        [Tooltip("Specify magazine location on gun")] [SerializeField] public Transform magazineLocation;
        public XRBaseInteractor socketInteractor;

        [Header("Settings")]
        [Tooltip("Specify time to destroy the casing object")] [SerializeField] private float destroyTimer = 2f;
        [Tooltip("Casing Ejection Speed")] [SerializeField] private float ejectPower = 150f;

        public int bulletSpeed = 10;
        public float fireRate = 1f;

        [Header("Audio")]
        [Tooltip("Main gun audio source")] public AudioSource audioSource;
        [Tooltip("Fire Sound")] public AudioClip fireSound;
        [Tooltip("Reload Sound")] public AudioClip reload;
        [Tooltip("No Ammo Sound")] public AudioClip noAmmo;


        private Coroutine current;

        private bool ammoCheck = true;
        private static readonly int Fire1 = Animator.StringToHash("Fire");

        private void AddMagazine(XRBaseInteractable interactable)
        {
            magazine = interactable.GetComponent<Magazine>();
            magazine.transform.parent = magazineLocation;
            audioSource.PlayOneShot(reload);
        }

        private void RemoveMagazine(XRBaseInteractable interactable)
        {
            magazine = null;
            audioSource.PlayOneShot(reload);
        }

        public void Slide()
        {
            audioSource.PlayOneShot(reload);
        }

        private void Start()
        {
            socketInteractor.onSelectEntered.AddListener(AddMagazine);
            socketInteractor.onSelectExited.AddListener(RemoveMagazine);
            gunAnimator = gameObject.GetComponent<Animator>();

        }

        public void BeginFire()
        {
            if (current != null)
            {
                StopCoroutine(current);
            }
            current = StartCoroutine(Fire());
        }

        public void StopFire()
        {
            if (current != null)
            {
                StopCoroutine(current);
            }
        }

        private IEnumerator Fire()
        {
            if (magazine && magazine.NumberOfBullets > 0)
            {
                gunAnimator.SetTrigger(Fire1);
                while (true)
                {
                    magazine.NumberOfBullets--;
                    audioSource.PlayOneShot(fireSound);

                    if (muzzleFlashPrefab)
                    {
                        //Create the muzzle flash
                        var tempFlash = Instantiate(muzzleFlashPrefab, barrel.position, barrel.rotation);

                        //Destroy the muzzle flash effect
                        Destroy(tempFlash, 0.05f);
                    }

                    GameObject spawnedBullet = Instantiate(bullet, barrel.position, barrel.rotation);

                    spawnedBullet.GetComponent<Rigidbody>().velocity = bulletSpeed * barrel.forward;

                    //Destroy(spawnedBullet, 2);
                    CasingRelease();

                    yield return new WaitForSeconds(1f / fireRate);
                }
            }
            else
            {
                audioSource.PlayOneShot(noAmmo);
            }


        }

        //This function creates a casing at the ejection slot
        private void CasingRelease()
        {
            //Cancels function if ejection slot hasn't been set or there's no casing
            if (!casingExitLocation || !casingPrefab)
            { return; }

            //Create the casing
            var position = casingExitLocation.position;
            var tempCasing = Instantiate(casingPrefab, position, casingExitLocation.rotation) as GameObject;
            //Add force on casing to push it out
            tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
            //Add torque to make casing spin in random direction
            tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

            //Destroy casing after X seconds
            Destroy(tempCasing, destroyTimer);
        }

        private void Update()
        {
            if (ammoCheck)
            {
                if (magazine && magazine.NumberOfBullets <= 0)
                {
                    StopFire();
                    audioSource.PlayOneShot(noAmmo);
                    ammoCheck = false;
                }
            }
            if (magazine && magazine.NumberOfBullets > 0)
            {
                ammoCheck = true;
            }

        }

    }
}

