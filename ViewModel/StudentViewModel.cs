using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Module02Activity01.Model;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Runtime.CompilerServices;

namespace Module02Activity01.ViewModel
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        private Student _student;

        private string _fullName; //variable for data conversion

        public StudentViewModel()
        {
            //Initialize a sample student model. Coordination with model
            _student = new Student { Firstname="John", Lastname="Doe", Age=23};
            LoadStudentDataCommand = new Command(async () => await LoadStudentDataAsync());

            // Collections
            Students = new ObservableCollection<Student>
            {
                new Student {Firstname="Jane", Lastname="Smith", Age =23},
                new Student {Firstname="Juan", Lastname="Dela Cruz", Age =21},
                new Student {Firstname="Pedro", Lastname="Penduko", Age =19}
            };
        }

        //Setting collection in public
        public ObservableCollection<Student> Students { get; set; }

        public string FullName
        {
            get => _fullName;
            set
            {
                if(_fullName != value)
                {
                    _fullName = value;

                    OnPropertyChanged(nameof(FullName));

                }
            }
        }

        public ICommand LoadStudentDataCommand { get; }

        private async Task LoadStudentDataAsync()
        {
            await Task.Delay(1000); // I/O operation
            FullName = $"{_student.Firstname} {_student.Lastname}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
