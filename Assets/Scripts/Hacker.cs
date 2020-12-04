using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {
    // Game Configuration Data
    string[] level1Passwords = {
        "This",
        "That",
        "Taco",
        "Fish"
    };
    
    string[] level2Passwords = {
        "Password",
        "Finish",
        "Halfway",
        "Passing"
    };
    string[] level3Passwords = {
        "Fantastic",
        "Superbly",
        "Diaphram",
        "Interesting"
    };

    // Game State
    int level;
    enum Screen {MainMenu, Password, Win};
    Screen currentScreen = Screen.MainMenu;
    string password;

    // Start is called before the first frame update
    void Start() {
        ShowMainMenu();
    }

    void ShowMainMenu() {
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the Police Station");
        Terminal.WriteLine("Enter Your Selection:");
    }

    void OnUserInput(string input) {
        if (input == "menu") {
            currentScreen = Screen.MainMenu;
            ShowMainMenu();
        } else if (currentScreen == Screen.MainMenu) {
            RunMainMenu(input);
        } else if (currentScreen == Screen.Password) {
            CheckPassword(input);
        }
    }

    void RunMainMenu (string input) {
        bool isValidLevel = (input == "1" || input == "2" || input == "3");
        if(isValidLevel) {
            level = int.Parse(input);
            StartGame();
        } else if(input == "007") { // easter egg
            Terminal.WriteLine("Please select a level, Mr. Bond");
        } else if(input == "420") { // seedling
            Terminal.WriteLine("Ding Ding Ding... You Win Everything");
            Terminal.WriteLine("Enjoy yourself a smoke break.");
            Terminal.WriteLine("Favorite Stoner Movie of all time?");
            Terminal.WriteLine("'Half Baked' or 'How High' for me");
        } else {
            Terminal.WriteLine("Please enter a selection, 1 - 3 or type 'menu'.");
        }
    }

    void StartGame() {
        Terminal.ClearScreen();
        switch (level)
        {
            case 1:
                password = level1Passwords[0];
                break;
            case 2:
                password = level2Passwords[0];
                break;
            case 3:
                password = level3Passwords[0];
                break;
            default:
                Debug.LogError("Invalid Level Selection");
                break;
        }
        Terminal.WriteLine("Please enter a password");
        currentScreen = Screen.Password;
    }

    void CheckPassword(string input) {
        if (input == password) {
            Terminal.WriteLine("You're in, son!");
        } else {
            Terminal.WriteLine("Please Try Again");
        }
    }
}
