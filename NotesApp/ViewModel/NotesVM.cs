using NotesApp.Model;
using NotesApp.ViewModel.Commands;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.ViewModel
{
    public class NotesVM : INotifyPropertyChanged
    {
        private bool isEditing;

        public bool IsEditing
        {
            get { return isEditing; }
            set
            {
                isEditing = value;
                OnPropertyChanged("IsEditing");
            }
        }


        public ObservableCollection<Notebook> Notebooks { get; set; }
        private Notebook selectedNotebook;

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler SelectedNoteChanged;

        public Notebook SelectedNotebook
        {
            get { return selectedNotebook; }
            set
            {
                selectedNotebook = value;
                
                OnPropertyChanged("SelectedNotebook");
                ReadNotes();
            }
        }

        private Note note;

        public Note SelectedNote

        {
            get { return note; }
            set { note = value;
                SelectedNoteChanged(this, new EventArgs());
                OnPropertyChanged("SelectedNote");
            }
        }


        public ObservableCollection<Note> Notes { get; set; }

        public NewNotebookCommand NewNoteBookCommand { get; set; }
        public NewNoteCommand NewNoteCommand { get; set; }
        public BeginEditComand BeginEditCommand { get; set; }
        public HasEditedCommand HasEditedCommand { get; set; }


        public NotesVM()
        {
            IsEditing = false;

            NewNoteBookCommand = new NewNotebookCommand(this);
            NewNoteCommand = new NewNoteCommand(this);
            BeginEditCommand = new BeginEditComand(this);
            HasEditedCommand = new HasEditedCommand(this);

            Notebooks = new ObservableCollection<Notebook>();
            Notes = new ObservableCollection<Note>();
            ReadNotebooks();
          //  ReadNotes();
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public void CreateNotebook()
        {
            Notebook newNote = new Notebook()
            {
                Name = "New notebook",
                UserId = int.Parse(App.Userid)

            };
            DatabaseHelper.Insert(newNote);
            ReadNotebooks();
        }

        public void CreateNote(int notebookId)
        {
            Note newNote = new Note()
            {
                NotebookId = notebookId,
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now,
                Title = "New note"
            };
            DatabaseHelper.Insert(newNote);
            ReadNotes();
        }


        public void ReadNotebooks()
        {
            using (SQLiteConnection conn = new SQLiteConnection(DatabaseHelper.dbFile))
            {
                var notebooks = conn.Table<Notebook>().ToList();
                Notebooks.Clear();
                foreach (var notebook in notebooks)
                {
                    Notebooks.Add(notebook);
                }
                SelectedNotebook = Notebooks.FirstOrDefault();
            }
        }

        public void ReadNotes()
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(DatabaseHelper.dbFile))
            {
                if (selectedNotebook != null)
                {
                    var notes = conn.Table<Note>().Where(n => n.NotebookId == selectedNotebook.Id).ToList();
                    Notes.Clear();
                    foreach (var note in notes)
                    {
                        Notes.Add(note);
                    }
                }
            }
        }

        public void StartEditing()
        {
            IsEditing = true;
        }
        public void  HasRenamed(Notebook notebook)
        {
            if (notebook != null)
            {
                DatabaseHelper.Update(notebook);
                IsEditing = false;
                ReadNotebooks();
            }
        }

        public void UpdateSelectedNote()
        {
            DatabaseHelper.Update(SelectedNote);
        }
    }
}
