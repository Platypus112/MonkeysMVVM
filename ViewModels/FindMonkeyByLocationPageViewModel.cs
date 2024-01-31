using MonkeysMVVM.Models;
using MonkeysMVVM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonkeysMVVM.ViewModels
{
    public class FindMonkeyByLocationPageViewModel:ViewModel
    {

        private List<Monkey> locatedMonkeys;
        private readonly MonkeyList service;
        public ICommand FindMonkeyByLocationCommand { get; set; }
        public FindMonkeyByLocationPageViewModel()
        {
            service=new MonkeyList();
            FindMonkeyByLocationCommand = new Command(FindMonkey,()=>!string.IsNullOrEmpty(Entry));
        }
        private void FindMonkey()
        {
            locatedMonkeys = service.FindMonkeysByLocation(entry);
            Count = "Monkeys found:" + locatedMonkeys.Count;
            Entry = "";
            if (locatedMonkeys.Count<=0)
            {
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/9/9a/Trollface_non-free.png";
                Location = entry;
                Name = "no such monkey";
;           }
            else
            {
                ImageUrl = locatedMonkeys[0].ImageUrl;
                Location= locatedMonkeys[0].Location;
                Name = locatedMonkeys[0].Name;
            }
        }

        private string count;
        public string Count
        {
            get { return this.count; }
            set
            {
                this.count = value;
                OnPropertyChanged();
            }
        }
        private string imageUrl;
        public string ImageUrl
        {
            get { return this.imageUrl; }
            set
            {
                this.imageUrl = value;
                OnPropertyChanged();
            }
        }
        private string location;
        public string Location
        {
            get { return this.location; }
            set
            {
                this.location = value;
                OnPropertyChanged();
            }
        }
        private string name;
        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                OnPropertyChanged();
            }
        }

        private string entry;
        public string Entry
        {
            get { return this.entry; }
            set
            {
                this.entry = value;
                ((Command)FindMonkeyByLocationCommand).ChangeCanExecute();
                OnPropertyChanged();
            }
        }

    }
}
