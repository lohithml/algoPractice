using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohiLibrary.Classes.LC.amzOnsite
{
    public class DSIGN_FileSystem_588H
    {
        //Hard
        //588. Design In-Memory File System
        //Design an in-memory file system to simulate the following functions:

        //ls: Given a path in string format.If it is a file path, return a list that only contains this file's name. If it is a directory path, return the list of file and directory names in this directory. Your output (file and directory names together) should in lexicographic order.
        //mkdir: Given a directory path that does not exist, you should make a new directory according to the path.If the middle directories in the path don't exist either, you should create them as well. This function has void return type.
        //addContentToFile: Given a file path and file content in string format.If the file doesn't exist, you need to create that file containing given content. If the file already exists, you need to append given content to original content. This function has void return type.
        //readContentFromFile: Given a file path, return its content in string format.

        //Example:
        //Input: 
        //["FileSystem","ls","mkdir","addContentToFile","ls","readContentFromFile"]
        //[[], ["/"], ["/a/b/c"], ["/a/b/c/d","hello"], ["/"], ["/a/b/c/d"]]
        //Output:
        //[null,[],null,null,["a"],"hello"]

        //Note:
        //You can assume all file or directory paths are absolute paths which begin with / and do not end with / except that the path is just "/".
        //You can assume that all operations will be passed valid parameters and users will not attempt to retrieve file content or list a directory or file that does not exist.
        //You can assume that all directory names and file names only contain lower-case letters, and same names won't exist in the same directory.

        public class FileSystem
        {
            public class doc
            {
                public bool isFile = false;
                public Dictionary<string, doc> docs = new Dictionary<string, doc>();
                public string content = "";
            }
            public doc root;
            public FileSystem()
            {
                root = new doc();
            }

            public IList<string> Ls(string path)
            {
                //Time: O(m+n+klogk) m-length of string,n-depth of last directory,k-entries
                doc d = root;
                var result = new List<string>();
                if (path != "/")
                {
                    //file
                    var files = path.Split('/');
                    for (int i = 1; i < files.Length; i++)
                        d = d.docs[files[i]];
                    if (d.isFile)
                    {
                        result.Add(files[files.Length - 1]);
                        return result;
                    }

                }
                //folder
                result.AddRange(d.docs.Keys.OrderBy(x => x));
                return result;
            }

            public void Mkdir(string path)
            {
                //Time:O(m+n)
                doc dir = root;
                var dirs = path.Split('/');
                for (int i = 1; i < dirs.Length; i++)
                {
                    if (!dir.docs.ContainsKey(dirs[i]))
                        dir.docs.Add(dirs[i], new doc());
                    dir = dir.docs[dirs[i]];
                }
            }

            public void AddContentToFile(string filePath, string content)
            {
                //Time:O(m+n)
                doc f = root;
                var fLoc = filePath.Split('/');
                for (int i = 1; i < fLoc.Length - 1; i++)
                    f = f.docs[fLoc[i]];
                if (!f.docs.ContainsKey(fLoc[fLoc.Length - 1]))
                    f.docs.Add(fLoc[fLoc.Length - 1], new doc());
                f = f.docs[fLoc[fLoc.Length - 1]];
                f.isFile = true;
                f.content = f.content + content;
            }

            public string ReadContentFromFile(string filePath)
            {
                //Time:O(m+n)
                doc r = root;
                var rFile = filePath.Split('/');
                for (int i = 1; i < rFile.Length - 1; i++)
                    r = r.docs[rFile[i]];
                return r.docs[rFile[rFile.Length - 1]].content;
            }
        }

        /**
         * Your FileSystem object will be instantiated and called as such:
         * FileSystem obj = new FileSystem();
         * IList<string> param_1 = obj.Ls(path);
         * obj.Mkdir(path);
         * obj.AddContentToFile(filePath,content);
         * string param_4 = obj.ReadContentFromFile(filePath);
         */

        //ls
        //Time: O(m+n+klogk) m-length of string,n-depth of last directory,k-entries
        //others
        //Time:O(m+n)
    }
}

