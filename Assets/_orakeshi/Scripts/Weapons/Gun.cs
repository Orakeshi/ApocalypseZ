using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Orakeshi.ApocalypseZ.Weapon
{
    public class Gun : MonoBehaviour
    {
        [Header("Prefab Refrences")]
        public GameObject bullet;
        public GameObject casingPrefab;
        public GameObject muzzleFlashPrefab;

        [Header("Location Refrences")]
        [SerializeField] private Animator gunAnimator;
        [SerializeField] private Transform barrel;
        [SerializeField] private Transform casingExitLocation;
        public Magazine magazine;
        [Tooltip("Specify magazine location on gun")] [SerializeField] public Transform magazineLocation;
        public XRBaseInteractor socketInteractor;

        [Header("Settings")]
        [Tooltip("Specify time to destory the casing object")] [SerializeField] private float destroyTimer = 2f;
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
        public void AddMagazine(XRBaseInteractable interactable)
        {
            magazine = interactable.GetComponent<Magazine>();
            magazine.transform.parent = magazineLocation;
            audioSource.PlayOneShot(reload);
        }

        public void RemoveMagazine(XRBaseInteractable interactable)
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
            if (magazine && magazine.numberOfBullet > 0)
            {
                gunAnimator.SetTrigger("Fire");
                while (true)
                {
                    magazine.numberOfBullet--;
                    audioSource.PlayOneShot(fireSound);

                    if (muzzleFlashPrefab)
                    {
                        //Create the muzzle flash
                        GameObject tempFlash;
                        tempFlash = Instantiate(muzzleFlashPrefab, barrel.position, barrel.rotation);

                        //Destroy the muzzle flash effect
                        Destroy(tempFlash, 0.1f);
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
        void CasingRelease()
        {
            //Cancels function if ejection slot hasn't been set or there's no casing
            if (!casingExitLocation || !casingPrefab)
            { return; }

            //Create the casing
            GameObject tempCasing;
            tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
            //Add force on casing to push it out
            tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
            //Add torque to make casing spin in random direction
            tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

            //Destroy casing after X seconds
            Destroy(tempCasing, destroyTimer);
        }

        private void Update()
        {
            if (ammoCheck)
            {
                if (magazine && magazine.numberOfBullet <= 0)
                {
                    StopFire();
                    audioSource.PlayOneShot(noAmmo);
                    ammoCheck = false;
                }
            }
            if (magazine && magazine.numberOfBullet > 0)
            {
                ammoCheck = true;
            }

        }

    }
}

