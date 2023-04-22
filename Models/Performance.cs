using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TP2_POO2.Models
{
    public class Performance : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }

        private string _score { get; set; }
        public string? Score
        {
            get { return this._score; }
            set
            {
                if (this._score != value)
                {
                    this._score = value;
                    SetIsValid();
                    this.OnPropertyChanged();
                }
            }
        }

        private string _trainPath { get; set; }
        public string? TrainPath
        {
            get { return this._trainPath; }
            set
            {
                if (this._trainPath != value)
                {
                    this._trainPath = value;
                    SetIsValid();
                    this.OnPropertyChanged();
                }
            }
        }
        private string _testPath { get; set; }
        public string? TestPath
        {
            get { return this._testPath; }
            set
            {
                if (this._testPath != value)
                {
                    this._testPath = value;
                    SetIsValid();
                    this.OnPropertyChanged();
                }
            }
        }
        private int _k { get; set; }
        public int? K
        {
            get { return this._k; }
            set
            {
                if (this._k != value)
                {
                    this._k = (int)value;
                    SetIsValid();
                    this.OnPropertyChanged();
                }
            }
        }


        private bool _isValid;

        public bool IsValid
        {
            get { return this._isValid; }
        }

        private void SetIsValid()
        {
            this._isValid = !string.IsNullOrEmpty(this.TrainPath) && !string.IsNullOrEmpty(this.TestPath) && !string.IsNullOrEmpty(this.Score);
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
