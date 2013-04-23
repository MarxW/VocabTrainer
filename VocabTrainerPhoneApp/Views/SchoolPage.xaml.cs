using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Marx.Wolfgang.VocabTrainer.Common.Interfaces;
using VocabTrainerPhoneApp.Interfaces;
using Marx.Wolfgang.VocabTrainer.Common.ViewModel;

namespace VocabTrainerPhoneApp.Views
{
    public partial class SchoolPage : PhoneApplicationPage
    {
        private IConectivity conn = new IConectivityWP8Impl();
        private School school;

        public SchoolPage()
        {
            InitializeComponent();
            school = new School(conn);
            school.ClassroomsChanged += school_ClassroomsChanged;
            school.LoadingDataError += school_LoadingDataError;
            school.LoadData();
        }

        void school_LoadingDataError(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void school_ClassroomsChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}