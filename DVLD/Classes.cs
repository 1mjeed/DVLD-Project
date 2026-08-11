using DVLBLL;
using System;
using System.IO;
using System.Windows.Forms;

namespace DVLD.Classes
{
    internal class clsUtil
    {
         public static string GenerateGUID()
        {
            return Guid.NewGuid().ToString();
        }

         public static bool CreateFolderIfDoesNotExist(string path)
        {
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }

         public static string ReplaceFileNameWithGUID(string sourceFile)
        {
            FileInfo fi = new FileInfo(sourceFile);
            string extn = fi.Extension;
            return GenerateGUID() + extn;
        }

         public static bool CopyImageToProjectImagesFolder(ref string sourceFile)
        {
             string DestinationFolder = @"C:\C#\DVLD\DVLD\People\Image\";

            if (!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }

            string destinationFile = DestinationFolder + ReplaceFileNameWithGUID(sourceFile);

            try
            {
                File.Copy(sourceFile, destinationFile, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            sourceFile = destinationFile;
            return true;
        }
    }
    public static class clsGlobal
    {
        public static ManageUserBLL CurrentUser { get; set; }
    }
}