﻿namespace EntiteFramwork.ViewModels
{
    public class EditViewModel: CreateViewModel
    {
        public int Id { get; set; }
        public string ExistingPhotoPath { get; set; }    
    }
}