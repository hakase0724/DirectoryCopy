using System;
using System.IO;

namespace Hakase
{
    public static class HakaseUtility
    {
        //ディレクトリのコピー
        public static void DirectoryCopy
        (
            string sourcePath, //コピー元ファイルパス
            string destinationPath //コピー先ファイルパス
        )
        {
            //コピー元が無ければエラー
            if (!Directory.Exists(sourcePath)) 
                throw new IOException();
            //コピー先が無ければ新たに作る
            if (!Directory.Exists(destinationPath)) 
            {
                //フォルダのセキュリティ情報取得
                var access = Directory.GetAccessControl(sourcePath);
                Directory.CreateDirectory(destinationPath,access);
            }
            //ファイルをコピー
            foreach(var file in Directory.GetFiles(sourcePath))
            {
                //ファイルコピー先パスを構築
                var copyto = file.Replace(sourcePath, destinationPath);
                File.Copy(file, copyto);
            }
            //フォルダは再起でコピー
            foreach(var dic in Directory.GetDirectories(sourcePath))
            {
                //フォルダコピー先パスを構築
                var copyto = dic.Replace(sourcePath, destinationPath);
                DirectoryCopy(dic,copyto);
            }
        }
    }
}
