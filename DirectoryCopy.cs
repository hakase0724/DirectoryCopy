using System;
using System.IO;

namespace Hakase
{
    public static class HakaseUtility
    {
        //ディレクトリのコピー
        public static void DirectoryCopy(string sourcePath, string destinationPath)
        {
            //コピー元が無ければエラー
            if (!Directory.Exists(sourcePath)) throw new IOException();
            //コピー先が無ければ新たに作る
            if (!Directory.Exists(destinationPath)) Directory.CreateDirectory(destinationPath, Directory.GetAccessControl(sourcePath));
            //ファイルをコピー
            foreach (var file in Directory.GetFiles(sourcePath))
            {
                File.Copy(file, file.Replace(sourcePath, destinationPath));
            }
            //フォルダは再起でコピー
            foreach (var dic in Directory.GetDirectories(sourcePath))
            {
                DirectoryCopy(dic, dic.Replace(sourcePath, destinationPath));
            }
        }
    }
}