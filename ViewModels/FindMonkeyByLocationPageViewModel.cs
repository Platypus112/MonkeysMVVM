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
        protected Monkey currentMonkey;
        private readonly MonkeyList monkeys;
        public ICommand FindMonkeyByLocationCommand { get; set; }
        public FindMonkeyByLocationPageViewModel()
        {
            monkeys=new MonkeyList();
            FindMonkeyByLocationCommand = new Command(FindMonkey,()=>entry!=null&&entry!="");
        }
        private void FindMonkey()
        {
            currentMonkey = monkeys.Monkeys.Where(x => x.Location == entry).FirstOrDefault();
            Count = "Monkeys found:" + monkeys.Monkeys.Count(x => x.Location == entry).ToString();
            Entry = "";
            if (count== "Monkeys found:0")
            {
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/9/9a/Trollface_non-free.png";
                Location = entry;
                Name = "no such monkey";
;           }
            else
            {
                ImageUrl = currentMonkey.ImageUrl;
                Location= currentMonkey.Location;
                Name = currentMonkey.Name;
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
