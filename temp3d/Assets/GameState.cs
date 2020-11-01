public class GameState
{
    public static GameButton mostRecentlyClickedGameButton;

    public static void SetMostRecentlyClickedGameButton(ButtonInfo clickedButton)
    {
        mostRecentlyClickedGameButton = clickedButton.GetGameButton();
    }
}
