﻿using NotesApp.Model;
using NotesApp.ViewModel.Commands;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.ViewModel
{
    public class NotesVM
    {
        public ObservableCollection<Notebook> Notebooks { get; set; }
        private Notebook selectedNotebook;
        public Notebook SelectedNotebook
        {
            get { return selectedNotebook; }
            set
            {
                selectedNotebook = value;
            }
        }

        public ObservableCollection<Note> Notes { get; set; }

        public NewNotebookCommand NewNoteBookCommand { get; set; }
        public NewNoteCommand NewNoteCommand { get; set; }

        public NotesVM()
        {
            NewNoteBookCommand = new NewNotebookCommand(this);
            NewNoteCommand = new NewNoteCommand(this);
            Notebooks = new ObservableCollection<Notebook>();
            Notes = new ObservableCollection<Note>();
            ReadNotebooks();
        }
        public void CreateNotebook()
        {
            Notebook newNote = new Notebook()
            {
                Name = "New notebook",

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
    }
}
