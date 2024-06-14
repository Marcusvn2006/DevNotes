using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notes.ui.Models
{
    internal class AllNotes
    {
        public ObservableCollection<Nota> Notas { get; set; } = new ObservableCollection<Nota>();
        public AllNotes() => LoadNotes();
        public void LoadNotes()
        {
            Notas.Clear();
            string appDataPath = FileSystem.AppDataDirectory;
            IEnumerable<Nota> notas = Directory.EnumerateFiles(appDataPath, "*.notes.txt").Select(filename => new Nota() { FileName = filename, Text = File.ReadAllText(filename), Date = File.GetLastWriteTime(filename) }).OrderBy(nota => nota.Date);
            foreach (Nota nota in notas)
            {
                Notas.Add(nota);
            }
        }
    }
}
