namespace SvTools.Models;

public class LanguageButton
{
    public string Name { get; init; }
    public bool IsChecked {get; set;}

    public LanguageButton(Language language){
        Name = language.Name;
        IsChecked = false;
    }
}