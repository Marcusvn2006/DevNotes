using Microsoft.Maui.Storage;
using System.IO.Enumeration;

namespace notes.ui.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]

public partial class NotePage : ContentPage
{
    //string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");
    public NotePage()
    {
        InitializeComponent();
        //if (File.Exists(_fileName))
        //    txtEditor.Text = File.ReadAllText(_fileName);
        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

        LoadNote(Path.Combine(appDataPath, randomFileName));
    }
    private void LoadNote(string fileName)
    {
        Models.Nota noteModel = new Models.Nota();
        noteModel.FileName = fileName;

        if (File.Exists(fileName))
        {
            noteModel.Date = File.GetCreationTime(fileName);
            noteModel.Text = File.ReadAllText(fileName);
        }
        BindingContext = noteModel;
    }

    public string ItemId
    {
        set
        {
            LoadNote(value);
        }
    }

    private async void Save_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Nota nota)
        {
            File.WriteAllText(nota.FileName, txtEditor.Text);

            await Shell.Current.GoToAsync("..");
        }
    }

    private async void Delete_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Nota nota)
        {
            if (File.Exists(nota.FileName))
                File.Delete(nota.FileName);
        }

        await Shell.Current.GoToAsync("..");

    }
}