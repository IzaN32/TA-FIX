using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace VNCreator
{
    public class VNCreator_DisplayUI : DisplayBase
    {
        [Header("Text")]
        public Text characterNameTxt;
        public Text dialogueTxt;
        [Header("Visuals")]
        public Image characterImg;
        public Image backgroundImg;
        [Header("Audio")]
        public AudioSource musicSource;
        public AudioSource soundEffectSource;
        [Header("Buttons")]
        public Button nextBtn;
        public Button previousBtn;
        public Button saveBtn;
        public Button menuButton;
        [Header("Choices")]
        public Button choiceBtn1;
        public Button choiceBtn2;
        public Button choiceBtn3;
        [Header("End")]
        public GameObject endScreen;
        [Header("Main menu")]
        [Scene]
        public string mainMenu;

        // Fungsi ini dipanggil saat skrip diinisialisasi
        void Start()
        {
            // Mengassign listener ke event onClick tombol "Next",
            // dengan delegate yang memanggil fungsi NextNode dengan choiceId 0
            nextBtn.onClick.AddListener(delegate { NextNode(0); });

            // Jika tombol "Previous" ada, mengassign listener ke event onClick-nya
            // yang memanggil fungsi Previous
            if(previousBtn != null)
                previousBtn.onClick.AddListener(Previous);

            // Jika tombol "Save" ada, mengassign listener ke event onClick-nya
            // yang memanggil fungsi Save
            if(saveBtn != null)
                saveBtn.onClick.AddListener(Save);

            // Jika tombol "Menu" ada, mengassign listener ke event onClick-nya
            // yang memanggil fungsi ExitGame
            if (menuButton != null)
                menuButton.onClick.AddListener(ExitGame);

            // Jika tombol pilihan 1, 2, atau 3 ada, mengassign listener ke event onClick-nya
            // yang memanggil fungsi NextNode dengan choiceId yang sesuai
            if(choiceBtn1 != null)
                choiceBtn1.onClick.AddListener(delegate { NextNode(0); });
            if(choiceBtn2 != null)
                choiceBtn2.onClick.AddListener(delegate { NextNode(1); });
            if(choiceBtn3 != null)
                choiceBtn3.onClick.AddListener(delegate { NextNode(2); });

            // Menonaktifkan GameObject layar akhir (end screen)
            endScreen.SetActive(false);

            // Memulai coroutine untuk menampilkan node saat ini
            StartCoroutine(DisplayCurrentNode());
        }

        // Fungsi ini dipanggil ketika berpindah ke node berikutnya dengan choiceId
        protected override void NextNode(int _choiceId)
        {
            // Jika ini adalah node terakhir, mengaktifkan end screen dan mengembalikan fungsi
            if (lastNode)
            {
                endScreen.SetActive(true);
                return;
            }

            // Memanggil fungsi NextNode dari kelas dasar dengan choiceId
            base.NextNode(_choiceId);

            // Memulai coroutine untuk menampilkan node saat ini
            StartCoroutine(DisplayCurrentNode());
        }

        // Coroutine ini menampilkan node saat ini
        IEnumerator DisplayCurrentNode()
        {
            // Menampilkan nama karakter pada teks karakter
            characterNameTxt.text = currentNode.characterName;

            // Jika sprite karakter tidak null, mengubah sprite gambar karakter dan mengatur warnanya menjadi putih
            // Jika sprite karakter null, mengatur warna gambar karakter menjadi transparan
            if (currentNode.characterSpr != null)
            {
                characterImg.sprite = currentNode.characterSpr;
                characterImg.color = Color.white;
            }
            else
            {
                characterImg.color = new Color(1, 1, 1, 0);
            }

            // Jika sprite latar belakang tidak null, mengubah sprite gambar latar belakang
            if(currentNode.backgroundSpr != null)
                backgroundImg.sprite = currentNode.backgroundSpr;

            // Jika jumlah pilihan dalam node <= 1,
            // menampilkan tombol "Next" dan menyembunyikan tombol pilihan lainnya,
            // serta menampilkan tombol "Previous" jika daftar pemutaran (loadList) tidak hanya berisi satu node
            if (currentNode.choices <= 1) 
            {
                nextBtn.gameObject.SetActive(true);

                choiceBtn1.gameObject.SetActive(false);
                choiceBtn2.gameObject.SetActive(false);
                choiceBtn3.gameObject.SetActive(false);

                previousBtn.gameObject.SetActive(loadList.Count != 1);
            }
            // Jika jumlah pilihan dalam node > 1,
            // menyembunyikan tombol "Next" dan menampilkan tombol pilihan,
            // serta mengatur teks tombol pilihan sesuai dengan opsi pilihan dalam node
            else
            {
                nextBtn.gameObject.SetActive(false);

                choiceBtn1.gameObject.SetActive(true);
                choiceBtn1.transform.GetChild(0).GetComponent<Text>().text = currentNode.choiceOptions[0];

                choiceBtn2.gameObject.SetActive(true);
                choiceBtn2.transform.GetChild(0).GetComponent<Text>().text = currentNode.choiceOptions[1];

                // Jika jumlah pilihan dalam node adalah 3,
                // menampilkan tombol pilihan ketiga dan mengatur teks tombolnya sesuai dengan opsi pilihan dalam node
                // Jika jumlah pilihan dalam node bukan 3, menyembunyikan tombol pilihan ketiga
                if (currentNode.choices == 3)
                {
                    choiceBtn3.gameObject.SetActive(true);
                    choiceBtn3.transform.GetChild(0).GetComponent<Text>().text = currentNode.choiceOptions[2];
                }
                else
                {
                    choiceBtn3.gameObject.SetActive(false);
                }
            }

            // Jika musik latar belakang pada node tidak null, memainkan musik tersebut
            if (currentNode.backgroundMusic != null)
                VNCreator_MusicSource.instance.Play(currentNode.backgroundMusic);

            // Jika efek suara pada node tidak null, memainkan efek suara tersebut
            if (currentNode.soundEffect != null)
                VNCreator_SfxSource.instance.Play(currentNode.soundEffect);

            // Mengosongkan teks dialog
            dialogueTxt.text = string.Empty;

            // Jika opsi teks instan diaktifkan,
            // langsung menampilkan seluruh teks dialog saat ini
            // Jika tidak, menampilkan teks dialog per karakter dengan kecepatan yang disesuaikan
            if (GameOptions.isInstantText)
            {
                dialogueTxt.text = currentNode.dialogueText;
            }
            else
            {
                char[] _chars = currentNode.dialogueText.ToCharArray();
                string fullString = string.Empty;
                for (int i = 0; i < _chars.Length; i++)
                {
                    fullString += _chars[i];
                    dialogueTxt.text = fullString;
                    yield return new WaitForSeconds(0.01f / GameOptions.readSpeed);
                }
            }
        }

        // Fungsi ini dipanggil saat tombol "Previous" diklik
        protected override void Previous()
        {
            // Memanggil fungsi Previous dari kelas dasar
            base.Previous();

            // Memulai coroutine untuk menampilkan node saat ini
            StartCoroutine(DisplayCurrentNode());
        }

        // Fungsi ini dipanggil saat tombol "Menu" diklik
        void ExitGame()
        {
            // Memuat ulang scene dengan nama mainMenu
            SceneManager.LoadScene(mainMenu, LoadSceneMode.Single);
        }
    }
}
