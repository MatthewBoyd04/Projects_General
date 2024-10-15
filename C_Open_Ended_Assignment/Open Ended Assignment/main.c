/*H**********************************************************************
* FILENAME :        Open_Ended_assignment
*
* DESCRIPTION :
*       A simple game to demonstrate knowledge of the C programming language.
*
* PUBLIC FUNCTIONS :
*
*
*
* AUTHOR :    Matthew Boyd
* START DATE :    01/05/23
* MAJOR UPDATES: 02/05/23 , 04/05/23 , 05/05/23 , 06/07/23 , 07/07/23
*
* NOTES: The original plan was to use colours instead of numbers, as such there may be references to colours that were'nt removed
*H*/

#include <stdio.h>
#include <stdlib.h>
enum Difficulty{ //enum for difficulty to make it easier to read the program
    Easy,
    Medium,
    Hard,
};

enum DisplayChoice { //enum to make it easier to read the menu display options
    MainMenu,
    ReRunMenu,
    Rules,
    Credits,
    ChooseDifficulty,

};

enum Bool { //to use a bool variable type, for whatever reason the pre-made bool variable type wasnt working and its too late to change it now...
    True,
    False
};

struct PreviousGuesses { //Used to store data about previous guesses
    int CodeGuess[6];
    int CorrectColour;
    int CorrectPosition;
};

int Restart_Game(); //a simple function to get user input back.
void Start_Game(enum Bool keepSettings, enum Difficulty* difficulty); //The function that starts and controls the game
void DisplayMenus(enum DisplayChoice Display); //The function that decides what file to display
void read_and_display_file(const char* filename); //The function that reads the files and outputs to screen
int GetUserInputInt(int LowerBound, int UpperBound); //Gets the user input of type int, used to check the input is valid aswell as obtaining it
enum Difficulty GetDifficulty(); //Allows the user to choose the difficulty, added to make the program easier to read
int* GenerateCode(enum Difficulty difficulty); //The function that generates the code
enum Bool Guess(struct PreviousGuesses guesses[], int num_guesses, int code[], int code_length, int max); //The function made to allow the user to input a guess

int main()
{
    enum Difficulty difficulty; //Declare a variable for difficulty, as originally difficulty was meant to be able to be carried over throughout games,
    int ReRun = 1;
    while (ReRun >= 1) // While loop to re-run the program once its been completed.
    {
        if (ReRun == 1)
        {
            Start_Game(False, &difficulty);
        }
        ReRun = Restart_Game(); //Get the users' choice on if they want to re-run the game
    }

    return 0;
}

int Restart_Game() //a simple function to get user input back.
{
    int UserInput;
    DisplayMenus(ReRunMenu); //Show user the menu
    UserInput = GetUserInputInt(1,2); //Get user input
    UserInput = UserInput - 1; //Adjust user input
    return UserInput;
}

void Start_Game(enum Bool keepSettings, enum Difficulty* difficulty) //The function that starts and controls the game
{
    DisplayMenus(MainMenu); //display main menu
    int MenuDecision = GetUserInputInt(1,3); //get user choice from menu, credits and rules
    switch (MenuDecision)
    {
        case 1: //case menu
            {
                *difficulty = GetDifficulty(); //get user difficulty choice
                struct PreviousGuesses guesses[9999]; //Array length had to be defined so 9999 is used, i doubt that many guesses will ever be used
                enum Bool CodeCorrect = False; //used for a while loop, so the program will re-run until code is correct
                int* code = GenerateCode(*difficulty); //generate the code to be used
                int i = 0; //for iteration purposes
                int CodeLength; //length of code
                int max; //max number for code
                switch (*difficulty) //adjust codelength and max based off of difficulty
                {
                    case Easy: {CodeLength = 4; max = 5; break;}
                    case Medium: {CodeLength = 5; max = 8; break;}
                    case Hard: {CodeLength = 6; max = 11; break;}
                }
                while (CodeCorrect == False) //start the guessing process
                {
                    system("cls"); //clear the console
                    printf("Available Numbers: %d - %d", 0, max);
                    CodeCorrect = Guess(guesses, i, code,CodeLength, max); //get the users guess, also find out if its correct
                    i = i + 1;
                }
                free(code); //Frees the memory allocated for the code
            break;
            }
        case 2:{DisplayMenus(Rules); printf("Enter any number to continue..."); scanf("%d"); system("cls");  break;} //shows the users the rules
        case 3:{DisplayMenus(Credits); printf("Enter any number to continue..."); scanf("%d"); system("cls"); break;} //shows the users the credits
    }
    if (MenuDecision == 2 || MenuDecision == 3) //if any of the non, gameplay options are selected, it will re-run the main menu so the user can play
    {
        Start_Game(keepSettings, difficulty);
    }
}

void DisplayMenus(enum DisplayChoice Display) //The function that decides what file to display
{
    system("cls"); //clears the console everytime before a menu is displayed for presentation purposes
    switch (Display) //displays menus from text files
    {
    case MainMenu:
        {
            read_and_display_file("MainMenu.txt");
            break;
        }
    case Rules:
        {
            read_and_display_file("Rules.txt");
            break;
        }
    case Credits:
        {
            read_and_display_file("Credits.txt");
            break;
        }
    case ChooseDifficulty:
        {
            read_and_display_file("Choose Difficulty.txt");
            break;
        }
    case ReRunMenu:
        {
            read_and_display_file("ReRunMenu.txt");

            break;
        }
    }
}

void read_and_display_file(const char* filename) //The function that reads the files and outputs to screen
{
    FILE* file = fopen(filename, "r");
    if (file == NULL) //for developer purposes, to check the program can find the file
    {
        printf("Failed to open file: %s\n", filename);
        return;
    }

    char buffer[1024];
    while (fgets(buffer, 1024, file) != NULL) //get all the chars from files and then print them
    {
        printf("%s", buffer);
    }
    fclose(file); //close file
    printf("\n"); //keeps presentation neat
}

int GetUserInputInt(int LowerBound, int UpperBound) //Gets the user input of type int, used to check the input is valid aswell as obtaining it
{
    enum Bool Valid = False; //used to check if the user input is valid
    int Input;
    while (Valid == False) //will re-run until user input is valid
    {
        scanf("%d", &Input); //get input
        if (Input >= LowerBound && Input <= UpperBound) //check input
        {
            Valid = True;
        }
        else
        {
            printf("Invalid Input, The input must be between %d and %d, please input again.\n", LowerBound, UpperBound);
        }
    }

    return Input;
}

enum Difficulty GetDifficulty() //Allows the user to choose the difficulty, added to make the program easier to read
{
    enum Difficulty ChosenDifficulty;
    int UserInput;
    DisplayMenus(ChooseDifficulty);
    UserInput = GetUserInputInt(1,3);
    switch (UserInput)
    {
    case 1:{ChosenDifficulty = Easy; break;}
    case 2:{ChosenDifficulty = Medium; break;}
    case 3:{ChosenDifficulty = Hard; break;}
    }
    return ChosenDifficulty;

};

int* GenerateCode(enum Difficulty difficulty) //The function that generates the code
{
    int max, length; //Max as in the number of colours, Length as the length of the code

    //changes max and length based off of difficulty
    if (difficulty == Easy) { max = 6; length = 4; }
    else if (difficulty == Medium) { max = 9; length = 5; }
    else if (difficulty == Hard) { max = 12; length = 6; }

    else{printf("Error Code 2: Invalid Difficulty");} //in case of any weird errors for dev purposes

    // Loop to generate code
    int *code = malloc(length * sizeof(int)); //allocates memory
    int i, j, new_number; //declares needed variables

    srand(time(NULL)); // Seed the random number generator with current time

    for (i = 0; i < length; i++) { //for loop to generate numbers
        new_number = rand() % max;
        for (j = 0; j < i; j++) {
            if (code[j] == new_number) { //checks the numbers arent duplicates
                new_number = rand() % max;
                j = -1;
            }
        }
        code[i] = new_number; //assigns the filtered number to the array
    }



    return code;
}

enum Bool Guess(struct PreviousGuesses guesses[], int num_guesses, int code[], int code_length, int max) //The function made to allow the user to input a guess
{

    //printf("\nCode: %d %d %d %d \n", code[0], code[1], code[2], code[3]); //For testing purposes, displays the easy mode code
    // Print previous guesses + relevant notes to the user
    printf("\nNote: 'Correct number' is 'Correct number - Correct position'");
    printf("\nNote: There are NO duplicated numbers");
    printf("\nCode Length = %d", code_length);
    printf("\nPrevious Guesses:\n");
    for (int i = 0; i < num_guesses; i++) {
        printf("Guess %d: ", i+1);
        for (int j = 0; j < code_length; j++) {
            printf("%d ", guesses[i].CodeGuess[j]);
        }
        printf("  Correct Number: %d  Correct Position: %d\n", guesses[i].CorrectColour, guesses[i].CorrectPosition);
    }
    //end of showing previous guesses
    // Ask user for guess
    enum Bool ValidGuess = False;
    int guess[code_length];

    while (ValidGuess == False) //Code to check a Guess is valid (as in the numbers do not exceed the bounds)
    {
        printf("\nEnter your guess (separated by spaces): ");//Get guess
        for (int i = 0; i < code_length; i++) {
        scanf("%d", &guess[i]);
        }
        ValidGuess = True;

        for (int i =0; i < code_length; i++) //Check guess for validity
        {
            if (guess[i] > max || guess[i] < 0)
            {
                ValidGuess = False;
            }
        }
        if (ValidGuess == False) //if guess isnt valid
        {
            printf("\nInvalid Guess; enter a new guess\n");
        }
    }



    // Evaluate guess
    int correct_colour = 0;
    int correct_position = 0;

    for (int i = 0; i < code_length; i++) {
        for (int j = 0; j < code_length; j++) {
            if (guess[i] == code[j]) {
                if (i == j) {
                    correct_position++; //if its a correct number in correct position
                }
                else {
                    correct_colour++; //if its a correct number in the wrong position, it says colour as the old system was planning to use colours
                }
                break;
            }
        }
    }

    // Store guess in previous guesses array
    struct PreviousGuesses new_guess;
    for (int i = 0; i < code_length; i++) {
        new_guess.CodeGuess[i] = guess[i];
    }
    new_guess.CorrectColour = correct_colour;
    new_guess.CorrectPosition = correct_position;
    guesses[num_guesses] = new_guess;

    // Check if guess is correct
    if (correct_position == code_length) {
        return True;
    }
    else {
        return False;
    }
}

