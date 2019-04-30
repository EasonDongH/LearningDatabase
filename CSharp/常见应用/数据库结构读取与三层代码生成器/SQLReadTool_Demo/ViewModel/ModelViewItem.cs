
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace SQLReadTool
{
    public class ModelViewItem : BindableBase
    {
        private string _dataBase;
        public string DataBase
        {
            get { return _dataBase; }
            set
            {
                if (this.SetProperty(ref _dataBase, value))
                {
                    this.OnPropertyChanged("DataBase");
                }
            }
        }

        private string _dataBaseICON;
        public string DataBaseICON
        {
            get { return _dataBaseICON; }
            set
            {
                if (this.SetProperty(ref _dataBaseICON, value))
                {
                    this.OnPropertyChanged("DataBaseICON");
                }
            }
        }

        private string _tabelName;
        public string TabelName
        {
            get { return _tabelName; }
            set
            {
                if (this.SetProperty(ref _tabelName, value))
                {
                    this.OnPropertyChanged("TabelName");
                }
            }
        }

        private string _tabelNameICON;
        public string TabelNameICON
        {
            get { return _tabelNameICON; }
            set
            {
                if (this.SetProperty(ref _tabelNameICON, value))
                {
                    this.OnPropertyChanged("TabelNameICON");
                }
            }
        }

        private ObservableCollection<ModelViewItem> _tableNames
            = new ObservableCollection<ModelViewItem>();

        public ObservableCollection<ModelViewItem> TabelNames
        {
            get { return this._tableNames; }
            set
            {
                if (this.SetProperty(ref _tableNames, value))
                {
                    this.OnPropertyChanged("TabelNames");
                }
            }
        }


     
        

    }
}
