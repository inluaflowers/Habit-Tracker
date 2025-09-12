namespace UserInterface.Menus;

public class MainMenu : Menu
{
    private const string Title = "LMer\nShhh! Be vewy, vewy quiet. We're tracking habits!\nMain Menu";
    private static readonly Selection[] MenuSelections = [new Selection(), new Selection(), new Selection()];
    public UserInterface MenuUi = new(Title, MenuSelections);
    public override Selection SetActive()
    {
        return MenuUi.Show();

    }
}

