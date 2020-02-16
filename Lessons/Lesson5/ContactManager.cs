using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lesson5
{
    class ContactManager
    {
        private List<ContactEntry> _entries;
        private string _filePath;
        private string _log;

        public ContactManager()
        {
            _entries = new List<ContactEntry>();
            _filePath = "";
        }

        public ContactManager(string filePath)
        {
            _entries = new List<ContactEntry>();
            ReadFromFile(filePath);
        }

        public bool ReadFromFile(string filePath)
        {
            bool retVal = true;
            _filePath = filePath;
            if (!File.Exists(filePath))
            {
                _log += string.Format("{0}\n", "File not found.");
                return false;
            }
                
            StreamReader sr = File.OpenText(_filePath);
            while (!sr.EndOfStream)
            {
                bool result = this.AddEntryFromFileLine(sr.ReadLine());
                if (!result)
                    retVal = false;
            }
            return retVal;
        }

        private bool AddEntryFromFileLine(string line)
        {
            string[] fields = line.Split('|');
            try {
                ContactEntry ce = new ContactEntry();
                ce.LastName = fields[0];
                ce.FirstName = fields[1];
                ce.PhoneNumber = fields[2];
                ce.Email = fields[3];

                _entries.Add(ce);
            }
            catch(Exception ex)
            {
                BusinessLogicExeption blex = new BusinessLogicExeption();
                blex.BusinessLogicMessage = "Index out of range";
                throw blex;
            }

            return true;
        }

        public void AddEntry(ContactEntry contact)
        {
            _entries.Add(contact);
        }

        public void AddEntry(ContactEntry contact, bool forceCommit)
        {
            AddEntry(contact);
            if (forceCommit)
                Commit();
        }

        private void Commit()
        {
            StreamWriter sw = File.CreateText(_filePath);
            foreach(ContactEntry ce in _entries)
            {
                sw.Write(string.Format("{0}|{1}|{2}|{3}"),
                    ce.LastName,
                    ce.FirstName,
                    ce.PhoneNumber,
                    ce.Email);
            }

            sw.Close();
        }

        public ContactEntry SearchForContact(string lastName, string firstName)
        {
            foreach(ContactEntry ce in _entries)
                if (ce.LastName == lastName && ce.FirstName == firstName)
                    return ce;
            return null;
        }

        public void RemoveEntry(ContactEntry contact)
        {
            _entries.Remove(contact);
        }

        public IEnumerable<ContactEntry> Entries
        {
            get { return _entries.AsReadOnly(); }
        }

        public string Log
        {
           get{ return _log; }
        }

    }

    public class BusinessLogicExeption : Exception
    {
        public string BusinessLogicMessage { get; set; }
    }
}
