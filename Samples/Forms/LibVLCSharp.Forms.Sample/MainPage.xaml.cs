﻿using LibVLCSharp.Shared;
using System.Diagnostics;
using Xamarin.Forms;

namespace LibVLCSharp.Forms.Sample
{
    public partial class MainPage : ContentPage
    {
        MainViewModel _vm;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            videoView.MediaPlayerChanged += VideoView_MediaPlayerChanged;
            videoView.Loaded += VideoView_Loaded;

            _vm = BindingContext as MainViewModel;
            _vm.PropertyChanged += Vm_PropertyChanged;
            _vm.Initialize();
        }

        private void VideoView_Loaded(object sender, System.EventArgs e)
        {
            _vm.MediaPlayer.Play();
        }

        private void Vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName.Equals(nameof(_vm.MediaPlayer)))
                Trace.WriteLine("MediaPlayer change raised from ViewModel.Propertychanged");
        }

        private void VideoView_MediaPlayerChanged(object sender, MediaPlayerChangedEventArgs e)
        {
            Trace.WriteLine("VideoView_MediaPlayerChanged");
        }
    }
}