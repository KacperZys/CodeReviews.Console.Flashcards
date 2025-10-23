using Flashcards.KacperZys.Controller;

namespace Flashcards.KacperZys.View;
internal static class MainMenu
{
    public static void Display()
    {
        MainMenuController mainMenuController = new();
        bool toContinue = true;

        while (toContinue)
        {
            Options selection = SharedMenuOptionsController.SetMenuOptions<Options>();

            switch (selection)
            {
                case Options.Manage_Stacks:
                    StacksMenu stacksMenu = new();
                    stacksMenu.Display();
                    break;
                case Options.Manage_Flashcards:
                    FlashcardsMenu flashcardsMenu = new();
                    flashcardsMenu.Display();
                    break;
                case Options.Study:
                    StudyMenu studyMenu = new();
                    studyMenu.Display();
                    break;
                case Options.View_Study_Session_Data:
                    mainMenuController.ViewStudySessionData();
                    break;
                case Options.Exit:
                    toContinue = false;
                    break;
                default:
                    throw new Exception("Something went wrong. Please try again.");
            }
        }
    }

    private enum Options
    {
        Manage_Stacks,
        Manage_Flashcards,
        Study,
        View_Study_Session_Data,
        Exit
    }
}