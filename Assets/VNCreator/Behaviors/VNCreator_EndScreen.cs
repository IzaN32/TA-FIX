using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace VNCreator
{
    public class VNCreator_EndScreen : MonoBehaviour
    {
        public Button restartButton;
        public Button mainMenuButton;
        [Scene]
        public string mainMenu;

        // Fungsi ini dipanggil saat skrip diinisialisasi
        void Start()
        {
            // Mengassign listener ke event onClick tombol "Restart",
            // yang memanggil fungsi Restart
            restartButton.onClick.AddListener(Restart);

            // Mengassign listener ke event onClick tombol "Main Menu",
            // yang memanggil fungsi MainMenu
            mainMenuButton.onClick.AddListener(MainMenu);
        }

        // Fungsi ini dipanggil saat tombol "Restart" diklik
        void Restart()
        {
            // Memuat ulang data permainan baru dengan nama "MainGame"
            GameSaveManager.NewLoad("MainGame");

            // Memuat ulang scene aktif
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }

        // Fungsi ini dipanggil saat tombol "Main Menu" diklik
        void MainMenu()
        {
            // Memuat ulang scene dengan nama mainMenu
            SceneManager.LoadScene(mainMenu, LoadSceneMode.Single);
        }
    }
}