namespace WebApplication02.Models;

public static class JEExtensions
{
    public static void FixTempCshtml(string folderName = "Pustok")
    {
        string root = Path.Combine(Directory.GetCurrentDirectory(), $"Views/{folderName}");
        string root2 = Path.Combine(Directory.GetCurrentDirectory(), "_templates");
        string[] fileNames = Directory.GetFiles(root);
        foreach (string fileName in fileNames)
        {
            using (StreamReader sr = new StreamReader(Path.Combine(root, fileName))) 
            {
                string file = sr.ReadToEnd();
                string newFile = "";

                for (int i = 0; i < file.Length; i++)
                {
                    newFile += file[i];

                    if (newFile.EndsWith("href="))
                    {
                        newFile += file[++i];
                        string temp = "";
                        int j = i + 4;

                        while (i < j)
                        {
                            temp += file[++i];
                        }
                        if (!temp.EndsWith("http"))
                        {
                            string temp2 = "";
                            j = 0;
                            for (++i; file[i] != newFile[^1]; i++) 
                            {
                                temp2 += file[i];
                                j++;
                            }

                            if (temp2.EndsWith(".html"))
                            {
                                temp += temp2.Substring(0, j - 5) + file[i];
                            }
                            else
                            {
                                temp = "~/" + temp + temp2 + file[i];
                            }
                        }

                        newFile += temp;
                    }
                    if (newFile.EndsWith("src="))
                    {
                        newFile += file[++i];
                        string temp = "";
                        int j = i + 4;

                        for (; i < j; i++)
                        {
                            temp += file[i];
                        }
                        if (!temp.EndsWith("http")) temp = "~/" + temp;

                        newFile += temp;
                    }
                }
                string fi = Path.Combine(root2, fileName + ".txt");

                if (File.Exists(fi))
                {
                    File.Delete(fi);
                }
                else
                {
                    using (FileStream fs = File.Create(fi)) { }
                }


                using (StreamWriter sw = new StreamWriter(fi))
                {
                    sw.Write(newFile);
                    sw.Close();
                }
                sr.Close();
            }
        }


    }
}
