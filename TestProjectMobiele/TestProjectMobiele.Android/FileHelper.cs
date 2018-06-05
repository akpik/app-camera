﻿using System;
using System.IO;
using TestProjectMobiele;
//Gemaakt door Daan Vandebosch
namespace TestProjectMobiele.Droid
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}