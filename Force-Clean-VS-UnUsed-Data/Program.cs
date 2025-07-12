namespace Force_Clean_VS_UnUsed_Data
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter the root path to search and delete bin/obj folders:");
            string? rootPath = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(rootPath) || !Directory.Exists(rootPath))
            {
                Console.WriteLine("The provided path is invalid or does not exist.");
                Console.ReadKey();
                return;
            }

            try
            {
                Console.WriteLine("\nStarting the cleanup process...");
                // ابتدا تمام پوشه‌های bin و obj را در کل زیرشاخه‌ها پیدا می‌کنیم
                var directoriesToDelete = new List<DirectoryInfo>();
                var rootDir = new DirectoryInfo(rootPath);

                FindBinAndObjFolders(rootDir, directoriesToDelete);

                if (directoriesToDelete.Count == 0)
                {
                    Console.WriteLine("No 'bin' or 'obj' folders found to delete.");
                }
                else
                {
                    // سپس پوشه‌های یافته شده را حذف می‌کنیم
                    foreach (var dir in directoriesToDelete)
                    {
                        try
                        {
                            Console.WriteLine($"Deleting: {dir.FullName}");
                            dir.Delete(true); // true یعنی به صورت بازگشتی تمام محتویات حذف شود
                            Console.WriteLine($"Successfully deleted: {dir.FullName}");
                        }
                        catch (IOException ex)
                        {
                            Console.WriteLine($"Could not delete {dir.FullName}. Reason: {ex.Message}");
                        }
                        catch (UnauthorizedAccessException ex)
                        {
                            Console.WriteLine($"Permission denied for {dir.FullName}. Reason: {ex.Message}");
                        }
                    }
                }

                Console.WriteLine("\nCleanup process finished.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        /// <summary>
        /// این متد به صورت بازگشتی پوشه‌ها را می‌گردد و پوشه‌های bin و obj را به لیست اضافه می‌کند.
        /// </summary>
        /// <param name="currentDir">پوشه فعلی برای جستجو.</param>
        /// <param name="directoriesToDelete">لیستی که پوشه‌های مورد نظر به آن اضافه می‌شوند.</param>
        private static void FindBinAndObjFolders(DirectoryInfo currentDir, List<DirectoryInfo> directoriesToDelete)
        {
            // ابتدا بررسی می‌کنیم که آیا نام پوشه فعلی bin یا obj است یا خیر
            // این کار باعث می‌شود که اگر خود پوشه ریشه هم bin یا obj بود، حذف شود
            if (currentDir.Name.Equals("bin", StringComparison.OrdinalIgnoreCase) ||
                currentDir.Name.Equals("obj", StringComparison.OrdinalIgnoreCase))
            {
                directoriesToDelete.Add(currentDir);
                // وقتی پوشه‌ای برای حذف انتخاب می‌شود، دیگر زیرشاخه‌های آن را نمی‌گردیم
                return;
            }

            try
            {
                // تمام زیرپوشه‌های پوشه فعلی را می‌گیریم و این متد را برای آنها نیز فراخوانی می‌کنیم
                foreach (DirectoryInfo subDir in currentDir.GetDirectories())
                {
                    FindBinAndObjFolders(subDir, directoriesToDelete);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // اگر به پوشه‌ای دسترسی نداشتیم، از آن صرف نظر می‌کنیم
                Console.WriteLine($"Skipping directory due to lack of access: {currentDir.FullName}");
            }
        }
    }
}
