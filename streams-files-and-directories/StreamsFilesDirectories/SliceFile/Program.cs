﻿using System;
using System.IO;

namespace SliceFile
{
    class Program
    {
        static void Main(string[] args)
        {
            int fileCount = int.Parse(Console.ReadLine());

            using (var reader = new FileStream("sliceMe.txt", FileMode.Open))
            {
                var partLength = Math.Ceiling((double)reader.Length / fileCount);

                for (int i = 1; i <= fileCount; i++)
                {
                    var currentFileName = $"slice-{i}.txt";
                    var currentFileTotalBytes = 0;


                    using (var writer = new FileStream(currentFileName, FileMode.Create))
                    {
                        while (true)
                        {
                            var buffer = new byte[4096]; // 4 KB

                            var totalRead = reader.Read(buffer, 0, buffer.Length);

                            if (totalRead == 0)
                            {
                                break;
                            }

                            currentFileTotalBytes += totalRead;

                            if (currentFileTotalBytes >= partLength)
                            {
                                break;
                            }
                            writer.Write(buffer, 0, totalRead);
                        }
                    }
                }
            }
        }
    }
}
